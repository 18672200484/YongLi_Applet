using CMCS.Common.Entities.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCS.Common.Entities.UserSync
{
    /// <summary>
    /// 程序配置类
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("JIYISYNCALLUSER")]
    public class JiyiSyncAllUser : EntityBase
    {
        /// <summary>
        /// 人员 Id
        /// </summary>
        public string employeeId { get; set; }
        /// <summary>
        /// 人员类型
        /// </summary>
        public string employeeType { get; set; }
        /// <summary>
        /// 人员姓名,非空，目前最大长度为 4
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 性别，男、女
        /// </summary>
        public string gender { get; set; }
        /// <summary>
        /// 标签 SN，12 位 16进制数
        /// </summary>
        public string sn { get; set; }
        /// <summary>
        /// 门禁卡号，长度不超过 50
        /// </summary>
        public string cardNumber { get; set; }
        /// <summary>
        /// 图标 ID，目前支持1-6，如果不指定，填写“默认”即可
        /// </summary>
        public string iconID { get; set; }
    }
}
