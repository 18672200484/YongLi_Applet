using CMCS.Common.Entities.Sys;
using CMCS.DapperDber.Attrs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCS.Common.Entities.AccessControl
{
	/// <summary>
	/// 门禁-进出记录
	/// </summary>
	[CMCS.DapperDber.Attrs.DapperBind("Pos_EgAccessRecord")]
	public class EgAccessRecord
	{
		public EgAccessRecord()
		{
			this.Id = Guid.NewGuid().ToString();
			this.CreationTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
			this.CreatorUserId = 1;
		}
		[DapperPrimaryKey]
		public string Id { get; set; }
		public DateTime CreationTime { get; set; }
		public int CreatorUserId { get; set; }

		/// <summary>
		/// 门禁ID
		/// </summary>
		public string DoorId { get; set; }
		/// <summary>
		/// 人员名称
		/// </summary>
		public string UserName { get; set; }
		/// <summary>
		/// 人员ID
		/// </summary>
		public int UserId { get; set; }
		/// <summary>
		/// 通行类型
		/// </summary>
		public int PassOpenType { get; set; }

		/// <summary>
		/// 结果
		/// </summary>
		public int PassVerificationResult { get; set; }

		/// <summary>
		/// 通行方向
		/// </summary>
		public int PassDirection { get; set; }
	}
}
