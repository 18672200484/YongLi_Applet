using CMCS.Common.Entities.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCS.Common.Entities.LocationUser
{
	/// <summary>
	/// 人员实时位置
	/// </summary>
	[CMCS.DapperDber.Attrs.DapperBind("STAFFDUTY_POSITION")]
	public class Staffduty_Position : EntityBaseSysNoId
	{
		public int IsDeleted { get; set; }
		public int DeleterUserId { get; set; }
		public DateTime? DeletionTime { get; set; }
		/// <summary>
		/// 人员名称
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// （描述）
		/// </summary>
		public string Description { get; set; }
		/// <summary>
		/// （x坐标）
		/// </summary>
		public double? Xcoor { get; set; }
		/// <summary>
		/// （y坐标）
		/// </summary>
		public double? Ycoor { get; set; }
		/// <summary>
		/// （数据更新时间）
		/// </summary>
		public DateTime? LastUpdateTime { get; set; }
		/// <summary>
		/// （楼层号）
		/// </summary>
		public string FloorNo { get; set; }
		/// <summary>
		/// （建筑物ID）
		/// </summary>
		public string BuildId { get; set; }
		/// <summary>
		/// 人员高低
		/// </summary>
		public double? Zcoor { get; set; }
	}
}
