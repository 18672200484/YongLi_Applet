using CMCS.Common.Enums;
using CMCS.Common.Utilities;
using CMCS.DumblyConcealer.Tasks.LocationUser;
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
    public partial class FrmLocationUser : TaskForm
    {
        RTxtOutputer rTxtOutputer;
        TaskSimpleScheduler taskSimpleScheduler = new TaskSimpleScheduler();
        public static readonly string SysSyncss = ConfigurationManager.AppSettings["FrmLocationUserSS"] ?? "60000";
        public FrmLocationUser()
        {
            InitializeComponent();
        }

        private void FrmLocationUser_Load(object sender, EventArgs e)
        {
            this.Text = "定位人员同步";
            this.rTxtOutputer = new RTxtOutputer(rtxtOutput);
            ExecuteTask();
        }
        void ExecuteTask()
        {
            LocationUserDao locationUserDao = new LocationUserDao();
            taskSimpleScheduler.StartNewTask("定位人员同步", () =>
            {
                locationUserDao.SyncLocationUser(this.rTxtOutputer.Output);
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

        private void FrmLocationUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 注意：必须取消任务
            this.taskSimpleScheduler.Cancal();
        }
    }
}
