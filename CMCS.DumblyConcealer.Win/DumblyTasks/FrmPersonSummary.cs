using CMCS.Common.Enums;
using CMCS.Common.Utilities;
using CMCS.DumblyConcealer.Tasks.PersonSummary;
using CMCS.DumblyConcealer.Win.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMCS.DumblyConcealer.Win.DumblyTasks
{
    public partial class FrmPersonSummary : TaskForm
    {
        RTxtOutputer rTxtOutputer;
        TaskSimpleScheduler taskSimpleScheduler = new TaskSimpleScheduler();
        public FrmPersonSummary()
        {
            InitializeComponent();
        }

        private void FrmPersonSummary_Load(object sender, EventArgs e)
        {
            this.Text = "生产区总人数同步";
            this.rTxtOutputer = new RTxtOutputer(rtxtOutput);
            ExecuteTask();
        }
        void ExecuteTask()
        {
            PersonSummaryDao personSummaryDao = new PersonSummaryDao();
            taskSimpleScheduler.StartNewTask("生产区总人数同步", () =>
            {
                personSummaryDao.SyncPersonSummary(this.rTxtOutputer.Output);
            }, 5000, OutputError);
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
        private void FrmPersonSummary_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 注意：必须取消任务
            this.taskSimpleScheduler.Cancal();
        }
    }
}
