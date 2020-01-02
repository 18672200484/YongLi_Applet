using CMCS.Common;
using CMCS.Common.Dao;
using CMCS.Common.Entities.UserSync;
using CMCS.Common.Enums;
using CMCS.Common.Utilities;
using CMCS.DumblyConcealer.Tasks.UserSync.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCS.DumblyConcealer.Tasks.UserSync
{
	public class UserSyncDao
	{
		CommonDAO commonDAO = CommonDAO.GetInstance();
		public int SyncUser(Action<string, eOutputType> output)
		{
			int addRes = 0;
			//int updateRes = 0;
			////请求的头部，Authorization 由 appid + secret//appid:定位系统的登录账号.secret：定位系统的前段key
			//var header = Md5Helper.Md5(Md5Helper.Md5("client" + commonDAO.appConfig.secret)).ToUpper();
			////获取前端的token
			//var token = UtilHttpPost.doHttpPost("{\"buildIdList\":[\"200864\"],\"appid\":\"client\"}", commonDAO.appConfig.GetTokenUrl, header);
			//var resultToken = JsonConvert.DeserializeObject<AccessTokenResult>(token);

			////获取所有人员
			//var result = UtilHttpPost.doTokenHttpPost("{\"buildId\":\"200864\"}", commonDAO.appConfig.SearchEmployeeUrl, resultToken.data);

			//var allUser = JsonConvert.DeserializeObject<ResponseResult>(result);
			//if (allUser.Status == "ok")
			//{
			//    var jiyiAllUser = commonDAO.GetJiyiAllUser();
			//    if (jiyiAllUser.Count > 0)
			//    {
			JiyiSyncAllUser user;
			//        foreach (var item in allUser.data)
			//        {
			//            var localUser = Dbers.GetInstance().SelfDber.Entity<JiyiSyncAllUser>("where employeeId=:employeeId", new { employeeId = item.employeeId });
			//            if (localUser == null)
			//            {
			//                user = new JiyiSyncAllUser();
			//                user.cardNumber = item.cardNumber;
			//                user.employeeId = item.employeeId;
			//                user.employeeType = item.employeeType;
			//                user.gender = item.gender;
			//                user.iconID = item.iconID;
			//                user.name = item.name;
			//                user.sn = item.sn;
			//                addRes += Dbers.GetInstance().SelfDber.Insert(user);
			//            }
			//            else
			//            {
			//                localUser.cardNumber = item.cardNumber;
			//                //  localUser.employeeId = item.employeeId;
			//                localUser.employeeType = item.employeeType;
			//                localUser.gender = item.gender;
			//                localUser.iconID = item.iconID;
			//                localUser.name = item.name;
			//                localUser.sn = item.sn;
			//                updateRes += Dbers.GetInstance().SelfDber.Update(localUser);
			//            }
			//        }
			//    }
			//    else
			//    {
			//        JiyiSyncAllUser user;
			//        foreach (var item in allUser.data)
			//        {
			//            user = new JiyiSyncAllUser();
			//            user.cardNumber = item.cardNumber;
			//            user.employeeId = item.employeeId;
			//            user.employeeType = item.employeeType;
			//            user.gender = item.gender;
			//            user.iconID = item.iconID;
			//            user.name = item.name;
			//            user.sn = item.sn;
			//            addRes += Dbers.GetInstance().SelfDber.Insert(user);
			//        }
			//    }
			//    output(string.Format("新增用户 {0} 条，修改用户 {1} 条", addRes, updateRes), eOutputType.Normal);
			//}
			//else if (allUser.Status == "error")
			//{
			//    output(string.Format("获取接口error：{0}", allUser.errmsg), eOutputType.Error);
			//}

			return addRes;
		}
	}
}
