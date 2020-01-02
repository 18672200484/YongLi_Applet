using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCS.DumblyConcealer.Tasks.ToxicGas.Entities
{
   public class ToxicGasResult
    {
        /// <summary>
        /// 指标名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 数据更新时间
        /// </summary>
        public DateTime? lastUpdateTime { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public float? Value { get; set; }
    }
}
