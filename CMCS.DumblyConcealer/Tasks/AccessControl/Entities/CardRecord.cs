using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMCS.DapperDber.Attrs;

namespace CMCS.DumblyConcealer.Tasks.AccessControl.Entities
{
	/// <summary>
	/// 门禁刷卡记录
	/// </summary>
	[DapperBindAttribute("CardRecord")]
	public class CardRecord
	{
		//[DapperPrimaryKey]
		//public int Id { get; set; }

		/// <summary>
		/// 刷卡时间
		/// </summary>
		[DapperPrimaryKey]
		public double DataTime { get; set; }

		/// <summary>
		/// 人员编号
		/// </summary>
		public string PCode { get; set; }

		/// <summary>
		/// 人员名字
		/// </summary>
		public string PName { get; set; }

		/// <summary>
		/// 卡号
		/// </summary>
		public string CardData { get; set; }

		/// <summary>
		/// 门名称
		/// </summary>
		public string EquptName { get; set; }

		/// <summary>
		/// 部门名称
		/// </summary>
		public string DeptName { get; set; }

		/// <summary>
		/// 门禁编号
		/// </summary>
		public string EquptId { get; set; }

		/// <summary>
		/// 通道号
		/// </summary>
		public int PortNum { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int PictureId { get; set; }
	}
}
