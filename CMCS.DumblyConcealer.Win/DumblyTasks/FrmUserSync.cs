using CMCS.Common.Enums;
using CMCS.Common.Utilities;
using CMCS.DumblyConcealer.Tasks.UserSync;
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
    public partial class FrmUserSync : TaskForm
    {
        RTxtOutputer rTxtOutputer;
        TaskSimpleScheduler taskSimpleScheduler = new TaskSimpleScheduler();
        public static readonly string SysSyncss = ConfigurationManager.AppSettings["FrmUserSyncSS"] ?? "7200000";
        public FrmUserSync()
        {
            InitializeComponent();
        }

        private void FrmUserSync_Load(object sender, EventArgs e)
        {
            this.Text = "人员同步";
            this.rTxtOutputer = new RTxtOutputer(rtxtOutput);
            ExecuteTask();
        }
        void ExecuteTask()
        {
            UserSyncDao userSyncDao = new UserSyncDao();
            taskSimpleScheduler.StartNewTask("人员同步", () =>
            {
                userSyncDao.SyncUser(this.rTxtOutputer.Output);
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

        private void FrmUserSync_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 注意：必须取消任务
            this.taskSimpleScheduler.Cancal();
        }
    }
}
