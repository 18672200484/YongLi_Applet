using CMCS.Common.Dao;
using CMCS.Common.Enums;
using CMCS.Common.Utilities;
using CMCS.DumblyConcealer.Tasks.UserSync.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCS.DumblyConcealer.Tasks.PersonSummary
{
   public class PersonSummaryDao
    {
        CommonDAO commonDAO = CommonDAO.GetInstance();
        /// <summary>
        /// 生产区域总人数同步
        /// </summary>
        /// <param name="output"></param>
        /// <returns></returns>
        public int SyncPersonSummary(Action<string, eOutputType> output)
        {
            int res = 0;
            //请求的头部，Authorization 由 appid + secret//appid:定位系统的登录账号.secret：定位系统的前段key
            var header = Md5Helper.Md5(Md5Helper.Md5("client" + "0cb38723f0f744cdb5c8f4c82e312af1")).ToUpper();
            //获取前端的token
            var token = UtilHttpPost.doHttpPost("{\"buildIdList\":[\"200830\"],\"appid\":\"client\"}", "http://192.168.1.251:8085/api/v1/getToken", header);
            var resultToken = JsonConvert.DeserializeObject<AccessTokenResult>(token);

            //生出区域总人数
            var resultToal = UtilHttpPost.doTokenHttpPost("{\"buildId\":\"200830\"}", "http://192.168.1.251:8085/api/v1/yangkou/personSummary", resultToken.data);
            //区域人数
            var resultRegion = UtilHttpPost.doTokenHttpPost("{\"buildId\":\"200830\"}", "http://192.168.1.251:8085/api/v1/yangkou/areaSummary", resultToken.data);

            return res;
        }
    }
}
