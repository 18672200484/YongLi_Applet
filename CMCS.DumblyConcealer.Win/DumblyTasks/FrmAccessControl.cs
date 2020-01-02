using CMCS.Common.Enums;
using CMCS.Common.Utilities;
using CMCS.DumblyConcealer.Tasks.AccessControl;
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
	public partial class FrmAccessControl : TaskForm
	{
		RTxtOutputer rTxtOutputer;
		TaskSimpleScheduler taskSimpleScheduler = new TaskSimpleScheduler();
		public static readonly string SysSyncss = ConfigurationManager.AppSettings["FrmAccessControlSS"] ?? "60000";
		public FrmAccessControl()
		{
			InitializeComponent();
		}

		private void FromAccessControl_Load(object sender, EventArgs e)
		{
			this.Text = "门禁数据同步";
			this.rTxtOutputer = new RTxtOutputer(rtxtOutput);
			ExecuteTask();
		}
		void ExecuteTask()
		{
			AccessControlDao accessControlDao = new AccessControlDao();
			taskSimpleScheduler.StartNewTask("门禁数据同步", () =>
			{
				accessControlDao.SyncFCRData(this.rTxtOutputer.Output);
				//accessControlDao.SyncFCRTotalData(this.rTxtOutputer.Output);//由人员定位统计
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

		private void FromAccessControl_FormClosed(object sender, FormClosedEventArgs e)
		{
			// 注意：必须取消任务
			this.taskSimpleScheduler.Cancal();
		}
	}
}
