using CMCS.Common.Entities.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCS.Common.Entities.AccessControl
{
    /// <summary>
    /// 门禁中间库
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("JIYISYNCACCESSCONTROL")]
    public class JiyiSyncAccessControl : EntityBase
    {
        /// <summary>
        /// 用户门禁卡ID
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime? ActionTime { get; set; }
        /// <summary>
        /// 进出识别方式
        /// </summary>
        public string InOutMode { get; set; }
        /// <summary>
        /// 进或出类型
        /// </summary>
        public int InOutType { get; set; }
        /// <summary>
        /// 门禁名称
        /// </summary>
        public string DoorName { get; set; }
        /// <summary>
        /// 门禁编号
        /// </summary>
        public string DoorCode { get; set; }

        /// <summary>
        /// 人员名称
        /// </summary>
        public string EmployeeName { get; set; }
    }
}
