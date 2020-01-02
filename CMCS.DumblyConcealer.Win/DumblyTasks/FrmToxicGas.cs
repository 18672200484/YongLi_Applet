using CMCS.Common.Enums;
using CMCS.Common.Utilities;
using CMCS.DumblyConcealer.Tasks.ToxicGas;
using CMCS.DumblyConcealer.Win.Core;
using Modbus.Device;
using NModbus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IModbusMaster = Modbus.Device.IModbusMaster;

namespace CMCS.DumblyConcealer.Win.DumblyTasks
{
    public partial class FrmToxicGas : TaskForm
    {
        RTxtOutputer rTxtOutputer;
        TaskSimpleScheduler taskSimpleScheduler = new TaskSimpleScheduler();
        public static readonly string SysSyncss = ConfigurationManager.AppSettings["FrmToxicGasSS"] ?? "60000";
        public FrmToxicGas()
        {
            InitializeComponent();
        }
        private void FrmToxicGas_Load(object sender, EventArgs e)
        {
            this.Text = "有毒有害气体同步";
            this.rTxtOutputer = new RTxtOutputer(rtxtOutput);
            ExecuteTask();
        }
        void ExecuteTask()
        {
            ToxicGasDao toxicGasDao = new ToxicGasDao();
            taskSimpleScheduler.StartNewTask("有毒有害气体同步", () =>
            {
                toxicGasDao.SyncData(this.rTxtOutputer.Output);
            }, int.Parse(SysSyncss), OutputError);
        }
        /// <summary>
        /// 输出异常信息
        /// </summary>
        /// <param name="text"></param>
        /// <param name="ex"></param>
        void OutputError(string text, Exception ex)
        {
            this.rTxtOutputer.Output(text + Environment.NewLine + ex.Message, eOutputType.Error);

            Log4Neter.Error(text, ex);
        }
        private void FrmToxicGas_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 注意：必须取消任务
            this.taskSimpleScheduler.Cancal();
        }

    }
}
