using CMCS.Common.Entities.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCS.Common.Entities.BuildSync
{
    /// <summary>
    /// 程序配置类
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("JIYISYNCBUILD")]
    public class JiyiSyncBuild : EntityBase
    {
        /// <summary>
        /// 建筑ID
        /// </summary>
        public string buildId { get; set; }
        /// <summary>
        /// 建筑名称
        /// </summary>
        public string buildName { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? startTime { get; set; }
        /// <summary>
        /// 截止时间
        /// </summary>
        public DateTime? endTime { get; set; }
        /// <summary>
        /// 当前人数
        /// </summary>
        public int count { get; set; }
    }
}
