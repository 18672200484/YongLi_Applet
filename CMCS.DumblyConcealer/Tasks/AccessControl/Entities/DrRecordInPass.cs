using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMCS.DapperDber.Attrs;

namespace CMCS.DumblyConcealer.Tasks.AccessControl.Entities
{
	/// <summary>
	/// 人脸识别入厂记录
	/// </summary>
	[DapperBindAttribute("dr_record_inpass")]
	public class DrRecordInPass
	{
		[DapperPrimaryKey]
		public int Id { get; set; }

		/// <summary>
		/// 刷卡时间
		/// </summary>
		public DateTime InTime { get; set; }

		/// <summary>
		/// 人员Nid
		/// </summary>
		public string UserNid { get; set; }

		/// <summary>
		/// 人员名字
		/// </summary>
		public string UserName { get; set; }

		/// <summary>
		/// 人员GUID
		/// </summary>
		public string UserGid { get; set; }

		/// <summary>
		/// 卡号
		/// </summary>
		public string CardSN { get; set; }

		/// <summary>
		/// 控制器名称
		/// </summary>
		public string UnitName { get; set; }

		/// <summary>
		/// 人员工号
		/// </summary>
		public string CardSN_10 { get; set; }

		/// <summary>
		/// 门名称
		/// </summary>
		public string DoorName { get; set; }

		/// <summary>
		/// 门禁编号
		/// </summary>
		public string DoorId { get; set; }
	}
}
