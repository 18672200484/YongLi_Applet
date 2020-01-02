using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCS.DumblyConcealer.Tasks.UserSync.Entities
{
   public class ResponseResult
    {
        /// <summary>
        /// 成功状态，ok 表示成功，error 表示失败
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 错误码。0，正常，其他不正常
        /// </summary>
        public int errorCode { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string errmsg { get; set; }
        /// <summary>
        ///  具体返回的数据
        /// </summary>
        public List<ResponseUser> data { get; set; }
    }
    public class ResponseUser
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
