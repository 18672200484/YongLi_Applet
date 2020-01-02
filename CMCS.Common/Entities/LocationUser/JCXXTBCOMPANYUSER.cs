using CMCS.Common.Entities.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCS.Common.Entities.LocationUser
{
    /// <summary>
    /// 人员定位人员信息
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("JCXXTBCOMPANYUSER")]
    public class JCXXTBCOMPANYUSER : EntityBaseSys
    {
		/// <summary>
		/// 姓名
		/// </summary>
        public string username { get; set; }
		/// <summary>
		/// 性别
		/// </summary>
        public string sex { get; set; }
		/// <summary>
		/// 工号
		/// </summary>
        public string jopnum { get; set; }
		/// <summary>
		/// 部门
		/// </summary>
        public string deptname { get; set; }
		/// <summary>
		/// 部门ID
		/// </summary>
        public string deptid { get; set; }
		/// <summary>
		/// 部门编号
		/// </summary>
        public string deptcode { get; set; }
		/// <summary>
		/// 职务
		/// </summary>
        public string duty { get; set; }
		/// <summary>
		/// 岗位
		/// </summary>
        public string post { get; set; }
		/// <summary>
		/// 工种
		/// </summary>
        public string typework { get; set; }
		/// <summary>
		/// 身份证号
		/// </summary>
        public string idcard { get; set; }
		/// <summary>
		/// 电话
		/// </summary>
        public string phone { get; set; }
		/// <summary>
		/// 邮箱
		/// </summary>
        public string email { get; set; }
		/// <summary>
		/// 住址
		/// </summary>
        public string address { get; set; }
		/// <summary>
		/// 入职时间
		/// </summary>
        public DateTime? inttime { get; set; }
		/// <summary>
		/// 离职时间
		/// </summary>
        public DateTime? outtime { get; set; }
		/// <summary>
		/// 信标
		/// </summary>
        public string beacon { get; set; }
		/// <summary>
		/// 所属企业ID
		/// </summary>
        public string compid { get; set; }
		/// <summary>
		/// 所属企业名称
		/// </summary>
        public string compname { get; set; }
		/// <summary>
		/// 所属企业简称
		/// </summary>
        public string shortname { get; set; }
		/// <summary>
		/// 备注
		/// </summary>
        public string remark { get; set; }
		/// <summary>
		/// 区域ID
		/// </summary>
        public string areaid { get; set; }
		/// <summary>
		/// 区域名称
		/// </summary>
        public string areaname { get; set; }
		/// <summary>
		/// 区域编号
		/// </summary>
        public string areacode { get; set; }
		/// <summary>
		/// 工种编号
		/// </summary>
        public string typeworkcode { get; set; }
    }
}
