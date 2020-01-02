using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMCS.DapperDber.Attrs;

namespace CMCS.DumblyConcealer.Tasks.AccessControl.Entities
{
	/// <summary>
	/// 人脸识别所有记录
	/// </summary>
	[DapperBindAttribute("dr_record_pass")]
	public class DrRecordPass
	{
		[DapperPrimaryKey]
		public int Id { get; set; }

		/// <summary>
		/// 刷卡时间
		/// </summary>
		public DateTime PassTime { get; set; }

		/// <summary>
		/// 人员名字
		/// </summary>
		public string UserName { get; set; }

		/// <summary>
		/// 门名称
		/// </summary>
		public string DoorName { get; set; }

		/// <summary>
		/// 门禁编号
		/// </summary>
		public string DoorId { get; set; }

		/// <summary>
		/// 进出类型 0 进 1 出
		/// </summary>
		public int InType { get; set; }

		/// <summary>
		/// 通行结果
		/// </summary>
		public string PassResultMsg { get; set; }

		public string PassVideoUrl { get; set; }
	}
}
