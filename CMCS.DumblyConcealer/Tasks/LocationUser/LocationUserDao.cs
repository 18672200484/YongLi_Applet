using CMCS.Common;
using CMCS.Common.Dao;
using CMCS.Common.Entities.LocationUser;
using CMCS.Common.Enums;
using CMCS.Common.Utilities;
using CMCS.Common.Utilities.InfluxDBs;
using CMCS.Common.Utilities.RedisLib;
using CMCS.DumblyConcealer.Tasks.LocationUser.Entities;
using InfluxData.Net.InfluxDb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCS.DumblyConcealer.Tasks.LocationUser
{
	public class LocationUserDao
	{
		CommonDAO commonDAO = CommonDAO.GetInstance();

		/// <summary>
		/// 同步人员坐标信息
		/// </summary>
		/// <param name="output"></param>
		/// <returns></returns>
		public int SyncLocationUser(Action<string, eOutputType> output)
		{
			int res = 0;

			//获取定位人员信息
			var json = UtilHttpPost.PostWebApi("", commonDAO.appConfig.Locationlicence + "?username=" + commonDAO.appConfig.LocationUserName + "&password=" + commonDAO.appConfig.LocationPassWord);

			var result = JsonConvert.DeserializeObject<LocationUserResult>(json);
			if (result.status == "0")
				output("接口调用正常", eOutputType.Normal);
			else if (result.status == "1")
			{
				output("接口调用异常,异常信息:" + result.msginfo, eOutputType.Warn);
				return res;
			}
			//原点经纬度
			double lon = commonDAO.appConfig.Xcoor;
			double lat = commonDAO.appConfig.Ycoor;
			//左下角经纬度
			double leftDownx = commonDAO.appConfig.LeftDownXcoor;
			double leftDowny = commonDAO.appConfig.LeftDownYcoor;
			//右上角经纬度
			double rightUpx = commonDAO.appConfig.RightUpXcoor;
			double rightUpy = commonDAO.appConfig.RightUpYcoor;

			//左边框长度
			double leftLength = MissionPlanner.GetDistance(lat, lon, leftDowny, leftDownx);

			//上边框框长度
			double upLength = MissionPlanner.GetDistance(lat, lon, rightUpy, rightUpx);

			#region 直接进业务库相关

			#endregion

			RedisHelper redis = new RedisHelper(commonDAO.appConfig.UserRedisDatabase);
			InfluxDBSdkHelper client = new InfluxDBSdkHelper(commonDAO.appConfig.InfluxDbUrlAndPort, commonDAO.appConfig.InfluxDbUser, commonDAO.appConfig.InfluxDbPwd);

			if (result.data != null)
			{
				var keyList = result.data.Select(t => redis.AddSysCustomKey(t.empName)).ToList();
				//获取所有人员的redisKey并判断redisKey在获取的当前实时数据是否存在，不存在删除当前redisKey
				var redisKeys = redis.GetAllKeys();
				foreach (var item in redisKeys)
				{
					if (!keyList.Contains(item))
					{
						redis.KeyDel(item);
					}
				}

				//删除定位人员表
				Dbers.GetInstance().SelfDber.DeleteBySQL<Staffduty_Position>("where 1=1 ");
				foreach (var item in result.data)
				{
					#region 坐标换算
					ST_GPS_POINT gps = new ST_GPS_POINT();
					//var xlength = item.crossX / 1000;
					//var ylength = item.crossY / 1000;
					var xlength = item.crossX / 10;
					var ylength = item.crossY / 10;
					//如果人员定位系统的X坐标大于地图X坐标长度
					if (xlength > upLength)
					{
						xlength = Convert.ToInt32(upLength - commonDAO.appConfig.TempLength);
					}
					//如果人员定位系统的Y坐标大于地图Y坐标长度
					if (ylength > leftLength)
					{
						ylength = Convert.ToInt32(leftLength - commonDAO.appConfig.TempLength);
					}
					//如果人员的Y坐标小于设定值，强行增加多少米
					if (ylength < commonDAO.appConfig.TempLength2)
					{
						ylength = Convert.ToInt32(ylength + commonDAO.appConfig.TempLength);
					}
					gps.sgp_lon = lon + 0.00001141 * xlength;
					gps.sgp_lat = lat - (0.00000899 * ylength);
					#endregion

					//#region 直接进业务库

					////通过信标地址查询人员
					var usermodel = commonDAO.SelfDber.Entity<JCXXTBCOMPANYUSERINFOEXTEND>("where BEACON=:BEACON", new { BEACON = item.deviceNo });
					Staffduty_Position staffduty_Position = new Staffduty_Position();
					staffduty_Position.BuildId = item.area;
					staffduty_Position.FloorNo = item.layer;
					staffduty_Position.Name = item.empName;
					staffduty_Position.Xcoor = gps.sgp_lon;
					staffduty_Position.Ycoor = gps.sgp_lat;
					staffduty_Position.Zcoor = commonDAO.appConfig.Zcoor;
					staffduty_Position.LastUpdateTime = DateTime.Now;
					staffduty_Position.Id = usermodel == null ? "" : usermodel.UserId;

					Dbers.GetInstance().SelfDber.Insert(staffduty_Position);
					//#endregion

					#region 存redis数据库
					redis.HashSet(item.empName, "name", item.empName);
					redis.HashSet(item.empName, "lastUpdateTime", DateTimeOffset.UtcNow.ToLocalTime());
					redis.HashSet(item.empName, "x-Coor", gps.sgp_lon);
					redis.HashSet(item.empName, "y-Coor", gps.sgp_lat);
					redis.HashSet(item.empName, "floorNo", item.layer);
					redis.HashSet(item.empName, "buildId", item.area);
					redis.HashSet(item.empName, "status", "");
					#endregion

					#region 存时序数据库
					var point_model = new Point()
					{
						Name = commonDAO.appConfig.InfluxDbLocationUserTableName,//表名
						Tags = new Dictionary<string, object>() { { "userId", item.empName } },
						Fields = new Dictionary<string, object>() { { "x-Coor", gps.sgp_lon }, { "y-Coor", gps.sgp_lat }, { "floorNo", item.layer }, { "buildId", item.area }, { "status", "" } },
						Timestamp = DateTime.UtcNow
					};
					client.Write(commonDAO.appConfig.InfluxDbName, point_model);
					#endregion

					res++;
				}
			}
			output(string.Format("同步实时定位人员{0} 条", res), eOutputType.Normal);
			return res;
		}
	}
}
