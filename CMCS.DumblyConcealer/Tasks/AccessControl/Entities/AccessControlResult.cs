using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCS.DumblyConcealer.Tasks.AccessControl.Entities
{
    public class AccessControlResult
    {
        /// <summary>
        /// 1:成功其余失败
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 接口调用详情
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 数据集
        /// </summary>
        public List<data> data { get; set; }
    }
    public class data
    {
        /// <summary>
        /// 刷卡时间
        /// </summary>
        public DateTime? EventTime { get; set; }

        /// <summary>
        /// 人员ID
        /// </summary>
        public int EmployeeID { get; set; }

        /// <summary>
        /// 人员GUID
        /// </summary>
        public string EmpID { get; set; }

        /// <summary>
        /// 卡号
        /// </summary>
        public string CardNo { get; set; }

        /// <summary>
        /// 事件类型 1进 0出
        /// </summary>
        public int EventType { get; set; }

        /// <summary>
        /// 人员名称
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// 控制器名称
        /// </summary>
        public string ControlName { get; set; }

        /// <summary>
        /// 人员工号
        /// </summary>
        public string EmployeeCode { get; set; }

        /// <summary>
        /// 门名称
        /// </summary>
        public string DoorName { get; set; }

    }
}
