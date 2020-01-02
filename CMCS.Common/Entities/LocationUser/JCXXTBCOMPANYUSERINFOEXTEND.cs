using CMCS.Common.Entities.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCS.Common.Entities.LocationUser
{
	/// <summary>
	/// 人员信息扩展表（系统人员关联定位信标）
	/// </summary>
	[CMCS.DapperDber.Attrs.DapperBind("JCXXTBCOMPANYUSERINFOEXTEND")]
	public class JCXXTBCOMPANYUSERINFOEXTEND : EntityBaseSys
	{
		/// <summary>
		/// 人员ID 
		/// </summary>
		public string UserId { get; set; }
		/// <summary>
		/// 政治面貌
		/// </summary>
		public string POLITICSSTATUS { get; set; }
		/// <summary>
		/// 婚姻情况
		/// </summary>
		public string MARITALSTATUS { get; set; }
		/// <summary>
		/// 身份证号
		/// </summary>
		public string IDCARD { get; set; }
		/// <summary>
		/// 入职日期
		/// </summary>
		public DateTime INWORKTIME { get; set; }
		/// <summary>
		/// 离职日期
		/// </summary>
		public DateTime LEAVETIME { get; set; }
		/// <summary>
		/// 工作性质（正式、试用、兼职）
		/// </summary>
		public string JOBCATEGORY { get; set; }
		/// <summary>
		/// 转正日期
		/// </summary>
		public DateTime POSITIVETIME { get; set; }
		/// <summary>
		/// 家庭地址
		/// </summary>
		public string HOMEADDRESS { get; set; }
		/// <summary>
		/// 毕业院校
		/// </summary>
		public string ACADEMY { get; set; }
		/// <summary>
		/// 专业
		/// </summary>
		public string SPECIALTY { get; set; }
		/// <summary>
		/// 毕业时间
		/// </summary>
		public string GRADUATETIME { get; set; }
		/// <summary>
		/// 学历
		/// </summary>
		public string EDUCATION { get; set; }
		/// <summary>
		/// 备注
		/// </summary>
		public string REMARK { get; set; }
		/// <summary>
		/// 职位
		/// </summary>
		public string POSITION { get; set; }
		/// <summary>
		/// 工种
		/// </summary>
		public string TYPEWORK { get; set; }
		/// <summary>
		/// 工种code
		/// </summary>
		public string TYPEWORKCODE { get; set; }
		/// <summary>
		/// 信标
		/// </summary>
		public string BEACON { get; set; }
		/// <summary>
		/// 类别
		/// </summary>
		public string TYPE_GZ { get; set; }
	}
}
