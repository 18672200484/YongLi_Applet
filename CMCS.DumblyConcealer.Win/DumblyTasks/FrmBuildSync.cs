using CMCS.Common.Enums;
using CMCS.Common.Utilities;
using CMCS.DumblyConcealer.Tasks.BuildSync;
using CMCS.DumblyConcealer.Win.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMCS.DumblyConcealer.Win.DumblyTasks
{
    public partial class FrmBuildSync : TaskForm
    {
        RTxtOutputer rTxtOutputer;
        TaskSimpleScheduler taskSimpleScheduler = new TaskSimpleScheduler();
        public static readonly string SysSyncss = ConfigurationManager.AppSettings["FrmBuildSyncSS"] ?? "60000";
        public FrmBuildSync()
        {
            InitializeComponent();
        }
        private void FrmBuildSync_Load(object sender, EventArgs e)
        {
            this.Text = "区域人数同步";
            this.rTxtOutputer = new RTxtOutputer(rtxtOutput);
            ExecuteTask();
        }
        void ExecuteTask()
        {
            BuildSyncDao buildSyncDao = new BuildSyncDao();
            taskSimpleScheduler.StartNewTask("区域人数同步", () =>
            {
                buildSyncDao.SyncData(this.rTxtOutputer.Output);
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
        private void FrmBuildSync_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 注意：必须取消任务
            this.taskSimpleScheduler.Cancal();
        }
      
    }
}
