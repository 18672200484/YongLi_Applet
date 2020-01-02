using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMCS.Common.Enums
{
    /// <summary>
    /// 门禁枚举
    /// </summary>
    public enum EBuildSyncType
    {
        /// <summary>
        /// 厂内总人数
        /// </summary>
        [Description("厂内总人数")]
        ZS,
        /// <summary>
        /// 烷化车间
        /// </summary>
        [Description("烷化车间")]
        w,
        /// <summary>
        /// 抗一车间
        /// </summary>
        [Description("抗一车间")]
        K1,
        /// <summary>
        /// 抗二车间
        /// </summary>
        [Description("抗二车间")]
        K2,
        /// <summary>
        /// 控制中心
        /// </summary>
        [Description("控制中心")]
        KZ,
        /// <summary>
        /// 生产管理
        /// </summary>
        [Description("生产管理")]
        SC,
        /// <summary>
        /// 设备品控
        /// </summary>
        [Description("设备品控")]
        s,
        /// <summary>
        /// 外协施工
        /// </summary>
        [Description("外协施工")]
        WX,
        /// <summary>
        /// 外来临时
        /// </summary>
        [Description("外来临时")]
        W,
        /// <summary>
        /// 办公人员
        /// </summary>
        [Description("办公人员")]
        BG,
        /// <summary>
        /// 参观人员
        /// </summary>
        [Description("参观人员")]
        CG,
        /// <summary>
        /// 成品备货
        /// </summary>
        [Description("成品备货")]
        CP,
        /// <summary>
        /// 装卸班
        /// </summary>
        [Description("装卸班")]
        cc

    }
}

