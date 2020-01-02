using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCS.DumblyConcealer.Tasks.BuildSync.Entities
{
    public class BuildLedSyncResult
    {
        /// <summary>
        /// 返回结果 1正常
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 返回消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 数据集
        /// </summary>
        public List<Data> Data { get; set; }
    }
    public class Data
    {
        public string name { get; set; }
        public int top { get; set; }
        public int left { get; set; }
        public string value { get; set; }
        public int GroupID { get; set; }
        public int MapType { get; set; }
        public int ShowMode { get; set; }
        public string Key { get; set; }
        public string LabelName { get; set; }
    }
}
