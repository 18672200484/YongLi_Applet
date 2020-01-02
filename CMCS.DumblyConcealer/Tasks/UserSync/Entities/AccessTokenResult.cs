using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCS.DumblyConcealer.Tasks.UserSync.Entities
{
    public class AccessTokenResult
    {
        public string status { get; set; }
        public string errorCode { get; set; }
        public string errmsg { get; set; }
        public string data { get; set; }
    }
}
