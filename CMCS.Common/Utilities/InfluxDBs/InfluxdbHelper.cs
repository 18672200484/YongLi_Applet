using InfluxData.Net.Common.Enums;
using InfluxData.Net.InfluxDb;
using InfluxData.Net.InfluxDb.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCS.Common.Utilities.InfluxDBs
{
   public class InfluxdbHelper
    {
        private InfluxDbClient _client;
        public InfluxdbHelper(string infuxUrl, string infuxUser, string infuxPwd)
        {
            _client = new InfluxDbClient(infuxUrl, infuxUser, infuxPwd, InfluxDbVersion.Latest);
        }
    }
}
