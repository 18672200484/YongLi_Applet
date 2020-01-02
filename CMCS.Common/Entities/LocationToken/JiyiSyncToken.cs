using CMCS.Common.Entities.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCS.Common.Entities.LocationToken
{
    /// <summary>
    /// 程序配置类
    /// </summary>
    [CMCS.DapperDber.Attrs.DapperBind("JIYISYNCTOKEN")]
    public class JiyiSyncToken : EntityBase
    {
        public string RefreshToken { get; set; }
        public string Token { get; set; }
        public Int32 Expiresin { get; set; }
        public DateTime? StartTime { get; set; }

    }
}
