using CMCS.Common;
using CMCS.Common.Dao;
using CMCS.Common.Entities.AccessControl;
using CMCS.Common.Enums;
using CMCS.Common.Utilities;
using CMCS.DumblyConcealer.Tasks.AccessControl.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CMCS.DumblyConcealer.Tasks.AccessControl
{
	public class AccessControlDao
	{
		CommonDAO commonDAO = CommonDAO.GetInstance();

		/// <summary>
		/// 同步人脸识别数据
		/// </summary>
		/// <param name="output"></param>
		/// <returns></returns>
		public int SyncFCRData(Action<string, eOutputType> output)
		{
			int res = 0;
			//减少数据库请求  只查询今日最新的20条数据  同步程序不能长时间关闭
			IList<DrRecordPass> list = Dbers.GetInstance().MySqlDber.TopEntities<DrRecordPass>(20, "where to_days(PassTime) = to_days(now()) order by PassTime desc");
			foreach (DrRecordPass item in list)
			{
				var staffDuty_MJ = Dbers.GetInstance().SelfDber.Entity<StaffDuty_MJ>("where DoorName=:DoorName and ActionTime=:ActionTime", new { DoorName = item.DoorId, ActionTime = item.PassTime });
				if (staffDuty_MJ == null)
				{
					StaffDuty_MJ mjModel = new StaffDuty_MJ();
					mjModel.InOutMode = "人脸识别";
					mjModel.InOutType = item.InType == 0 ? "进" : "出";
					mjModel.ActionTime = item.PassTime;
					mjModel.DoorCode = item.DoorName;
					mjModel.DoorName = item.DoorId;
					mjModel.UserId = string.IsNullOrEmpty(item.UserName) ? "未注册人员" : item.UserName;
					res += Dbers.GetInstance().SelfDber.Insert(mjModel);
				}

				var staffDuty_JC = Dbers.GetInstance().SelfDber.Entity<StaffDuty_MJ>("where DoorName=:DoorName and ActionTime=:ActionTime", new { DoorName = item.DoorId, ActionTime = item.PassTime });
				if (staffDuty_MJ == null)
				{
					StaffDuty_MJ mjModel = new StaffDuty_MJ();
					mjModel.InOutMode = "人脸识别";
					mjModel.InOutType = item.InType == 0 ? "进" : "出";
					mjModel.ActionTime = item.PassTime;
					mjModel.DoorCode = item.DoorName;
					mjModel.DoorName = item.DoorId;
					mjModel.UserId = string.IsNullOrEmpty(item.UserName) ? "未注册人员" : item.UserName;
					res += Dbers.GetInstance().SelfDber.Insert(mjModel);
				}
			}
			output(string.Format("同步门禁数据 {0} 条", res), eOutputType.Normal);
			return res;
		}

		/// <summary>
		/// 同步区域人数
		/// </summary>
		/// <param name="output"></param>
		/// <returns></returns>
		public int SyncFCRTotalData(Action<string, eOutputType> output)
		{
			int res = 0;
			//区域总人数
			DataTable TotalData = Dbers.GetInstance().MySqlDber.ExecuteDataTable("select count(*) from (select count(UserName) from dr_record_pass where TO_DAYS(PassTime)=TO_DAYS(NOW()) group by Username  ) t");
			if (TotalData != null && TotalData.Rows.Count > 0 && TotalData.Rows[0][0] != DBNull.Value)
			{
				int TotalPerson = Convert.ToInt32(TotalData.Rows[0][0]);
				StaffDuty_Area TotalPerson_entity = commonDAO.SelfDber.Entity<StaffDuty_Area>("where BuildName='区域总人数'");
				if (TotalPerson_entity != null)
				{
					TotalPerson_entity.Count = TotalPerson;
					res += commonDAO.SelfDber.Update(TotalPerson_entity);
				}
				else
				{
					TotalPerson_entity = new StaffDuty_Area();
					TotalPerson_entity.BuildName = "区域总人数";
					TotalPerson_entity.Count = TotalPerson;
					res += commonDAO.SelfDber.Insert(TotalPerson_entity);
				}
				output("区域总人数:" + TotalPerson, eOutputType.Normal);
			}
			//厂内人数

			//出厂人数

			return res;
		}

		/// <summary>
		/// 同步门禁数据  Access数据 数据已包含在人脸识别数据中 不用再同步
		/// </summary>
		/// <param name="output"></param>
		/// <returns></returns>
		public int SyncDoorData(Action<string, eOutputType> output)
		{
			int res = 0;
			IList<CardRecord> list = Dbers.GetInstance().DoorSqlDber.TopEntities<CardRecord>(50, "where PictureId=0");
			foreach (CardRecord item in list)
			{
				var staffDuty_MJ = Dbers.GetInstance().SelfDber.Entity<StaffDuty_MJ>("where DoorName=:DoorName and ActionTime=:ActionTime", new { DoorName = item.EquptName, ActionTime = DoubleToTime(item.DataTime) });
				if (staffDuty_MJ == null)
				{
					StaffDuty_MJ mjModel = new StaffDuty_MJ();
					mjModel.InOutMode = "刷卡";
					mjModel.InOutType = item.PortNum == 1 ? "进" : "出";
					mjModel.ActionTime = DoubleToTime(item.DataTime);
					mjModel.DoorCode = item.EquptId;
					mjModel.DoorName = item.EquptName;
					mjModel.UserId = item.PName;
					res += Dbers.GetInstance().SelfDber.Insert(mjModel);
					item.PictureId = 1;
					Dbers.GetInstance().DoorSqlDber.Update(item);
				}
			}
			output(string.Format("同步门禁数据 {0} 条", res), eOutputType.Normal);
			return res;
		}

		/// <summary>
		/// double转换为DateTime
		/// </summary>
		/// <param name="time"></param>
		/// <returns></returns>
		public DateTime DoubleToTime(double time)
		{
			return DateTime.FromOADate(time);
		}
	}
}
