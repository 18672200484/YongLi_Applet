using CMCS.Common;
using CMCS.Common.Dao;
using CMCS.Common.Entities.AccessControl;
using CMCS.Common.Entities.BuildSync;
using CMCS.Common.Enums;
using CMCS.Common.Utilities;
using CMCS.DumblyConcealer.Tasks.BuildSync.Entities;
using CMCS.DumblyConcealer.Tasks.UserSync.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CMCS.DumblyConcealer.Tasks.BuildSync
{
	public class BuildSyncDao
	{
		CommonDAO commonDAO = CommonDAO.GetInstance();
		public int SyncData(Action<string, eOutputType> output)
		{
			int res = 0;

			//获取定位人员区域信息
			var json = UtilHttpPost.PostWebApi("", commonDAO.appConfig.SearchAreaUrl + "?username=" + commonDAO.appConfig.LocationUserName + "&password=" + commonDAO.appConfig.LocationPassWord);

			var result = JsonConvert.DeserializeObject<LocationAreaResult>(json);
			if (result.status == "0")
				output("接口调用正常", eOutputType.Normal);
			else if (result.status == "1")
			{
				output("接口调用异常,异常信息:" + result.msginfo, eOutputType.Warn);
				return res;
			}
			if (result.data != null)
			{
				commonDAO.SelfDber.DeleteBySQL<StaffDuty_Area>();
				foreach (var item in result.data)
				{
					if (string.IsNullOrEmpty(item.areaName.Trim()))
						item.areaName = "区域外";
					//StaffDuty_Area area_entity = commonDAO.SelfDber.Entity<StaffDuty_Area>("where BuildName=:BuildName", new { BuildName = item.areaName });
					//if (area_entity != null)
					//{
					//	area_entity.Count = item.personList.Count;
					//	res += commonDAO.SelfDber.Update(area_entity);
					//}
					//else
					//{
					StaffDuty_Area area_entity = new StaffDuty_Area();
					area_entity.BuildId = item.areaId;
					area_entity.BuildName = item.areaName;
					area_entity.Count = item.personList.Count;
					res += commonDAO.SelfDber.Insert(area_entity);
					//}
				}
				StaffDuty_Area area_Total = new StaffDuty_Area();
				area_Total.BuildId = "";
				area_Total.BuildName = "区域总人数";
				area_Total.Count = result.data.Select(a => a.personList.Count()).ToList().Sum();
				res += commonDAO.SelfDber.Insert(area_Total);
			}

			output(string.Format("同步区域人数成功 {0} 条", res), eOutputType.Normal);

			return res;
		}
	}
}
