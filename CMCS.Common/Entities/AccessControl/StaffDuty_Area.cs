using CMCS.Common.Entities.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCS.Common.Entities.AccessControl
{
	/// <summary>
	/// 门禁区域信息
	/// </summary>
	[CMCS.DapperDber.Attrs.DapperBind("StaffDuty_Area")]
	public class StaffDuty_Area : EntityBaseSys
	{
		/// <summary>
		/// 建筑ID
		/// </summary>
		public string BuildId { get; set; }
		/// <summary>
		/// 建筑名字
		/// </summary>
		public string BuildName { get; set; }
		/// <summary>
		/// 开始时间
		/// </summary>
		public DateTime StartTime { get; set; }
		/// <summary>
		/// 结束时间
		/// </summary>
		public DateTime EndTime { get; set; }
		/// <summary>
		/// 人员数量
		/// </summary>
		public int Count { get; set; }

	}
}
