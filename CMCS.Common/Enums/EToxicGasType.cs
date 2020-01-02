using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCS.Common.Enums
{
    /// <summary>
    /// 气体探测器
    /// </summary>
    public enum EToxicGasType
    {
        有毒探测器正常 = 0,//单位ppm
        有毒探测器故障 = 1,//单位ppm
        有毒探测器报警 = 2,//单位ppm
        可燃探测器正常 = 4,//单位lel
        可燃探测器故障 = 5,//单位lel
        可燃探测器报警 = 6,//单位lel
        氧气探测器正常 = 7,//单位ppm
        氧气探测器故障 = 8//单位ppm

    }
}
