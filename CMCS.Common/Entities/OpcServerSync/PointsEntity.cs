using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCS.Common.Entities.OpcServerSync
{
    public class PointsEntity
    {
        /// <summary>
        /// 点名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 点名描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime? LastUpdateTime { get; set; }
    }
}
