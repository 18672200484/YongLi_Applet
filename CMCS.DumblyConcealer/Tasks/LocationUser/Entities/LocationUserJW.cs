using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCS.DumblyConcealer.Tasks.LocationUser.Entities.LocationUserJW
{
	/// <summary>
	/// 人员经纬度请求结果
	/// </summary>
	public class LocationUserJW
	{
		/// <summary>
		/// 0表示正常，1表示异常
		/// </summary>
		public string status { get; set; }

		/// <summary>
		/// 调用结果提示信息
		/// </summary>
		public string msginfo { get; set; }

		public List<data> data { get; set; }
	}
	public class data
	{
		/// <summary>
		/// 员工姓名
		/// </summary>
		public string empName { get; set; }
		/// <summary>
		/// 员工工号 访客、承包商无工号，null
		/// </summary>
		public string empNo { get; set; }
		/// <summary>
		/// 设备编号（Mac地址）
		/// </summary>
		public string deviceNo { get; set; }
		/// <summary>
		/// 时间
		/// </summary>
		public DateTime dateTime { get; set; }
		/// <summary>
		/// X轴坐标
		/// </summary>
		public double crossX { get; set; }
		/// <summary>
		/// Y轴坐标
		/// </summary>
		public double crossY { get; set; }
		/// <summary>
		/// 人员卡类型 0:员工，1:访客，2:承包商
		/// </summary>
		public string specifictype { get; set; }
		/// <summary>
		/// 楼层数
		/// </summary>
		public string layer { get; set; }
		/// <summary>
		/// 区域id 0为其它区域
		/// </summary>
		public string area { get; set; }
		/// <summary>
		/// 轨迹信息
		/// </summary>
		public List<astarPointList> astarPointList { get; set; }
	}

	public class astarPointList
	{
		public double x { get; set; }

		public double y { get; set; }

		/// <summary>
		/// 经度
		/// </summary>
		public double longitude { get; set; }

		/// <summary>
		/// 维度
		/// </summary>
		public double latitude { get; set; }
	}
}
