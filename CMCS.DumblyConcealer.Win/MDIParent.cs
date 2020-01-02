using BasisPlatform.Util;
using CMCS.DumblyConcealer.Win.Core;
using CMCS.DumblyConcealer.Win.DumblyTasks;
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

namespace CMCS.DumblyConcealer.Win
{
	public partial class MDIParent : Form
	{
		public static readonly string netWork = ConfigurationManager.AppSettings["NetWork1OrNetWork2"] ?? "1";
		public MDIParent()
		{
			InitializeComponent();
		}

		#region 窗体菜单点击事件
		private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.Cascade);
		}

		private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.TileVertical);
		}

		private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LayoutMdi(MdiLayout.TileHorizontal);
		}
		#endregion

		#region 窗体事件
		private void MDIParent_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				if (MessageBox.Show("确认退出系统？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{

				}
				else
				{
					e.Cancel = true;
				}
			}
		}
		private void MDIParent_Shown(object sender, EventArgs e)
		{
			BasisPlatformUtil.StartNewTask("开机延迟启动", () =>
			{
				int minute = 5, surplus = minute;

				while (minute > 0)
				{
					double d = minute - Environment.TickCount / 1000 / 60;
					if (Environment.TickCount < 0 || d <= 0) break;

					System.Threading.Thread.Sleep(60000);

					surplus--;
				}

				// this.InvokeEx(() => { timer1.Enabled = true; });

			});
		}
		#endregion

		/// <summary>
		/// 任务索引
		/// </summary>
		int taskFormIndex = 0;
		private void timer1_Tick(object sender, EventArgs e)
		{
			switch (taskFormIndex)
			{
				case 1:
					//区域人数同步
					tsiBuild_Click(null, null);
					break;
				case 2:
					//人员定位的全部信息
					tsiUserLocation_Click(null, null);
					break;
				case 3:
					//有毒有害气体同步
					//tsiToxicGas_Click(null, null);
					break;
				case 4:
					//DCS数据同步
					tisDcsData_Click(null, null);
					break;
				case 5:
					//门禁数据同步
					tsiAccessControl_Click(null, null);
					break;
			}
			if (taskFormIndex == 6)
			{
				tileHorizontalToolStripMenuItem_Click(null, null);
				timer1.Stop();
			}
			taskFormIndex++;
		}
		/// <summary>
		/// 判断任务窗体是否已开
		/// </summary>
		/// <param name="form"></param>
		/// <param name="parentForm"></param>
		/// <returns></returns>
		private bool HaveOpened(Form form, Form parentForm)
		{
			bool bReturn = true;
			foreach (Form item in parentForm.MdiChildren)
			{
				if (form.GetType().Name == item.GetType().Name)
				{
					item.BringToFront();
					item.Focus();
					bReturn = false;
					break;
				}
			}
			return bReturn;
		}
		/// <summary>
		/// Invoke封装
		/// </summary>
		/// <param name="action"></param>
		public void InvokeEx(Action action)
		{
			if (this.IsDisposed || !this.IsHandleCreated) return;

			this.Invoke(action);
		}


		#region 同步事件

		/// <summary>
		/// 人员定位
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tsiUserLocation_Click(object sender, EventArgs e)
		{
			TaskForm taskForm = new FrmLocationUser();
			if (HaveOpened(taskForm, this))
			{
				taskForm.MdiParent = this;
				taskForm.Show();
			}
		}
		/// <summary>
		/// 有毒有害气体
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tsiToxicGas_Click(object sender, EventArgs e)
		{
			TaskForm taskForm = new FrmToxicGas();
			if (HaveOpened(taskForm, this))
			{
				taskForm.MdiParent = this;
				taskForm.Show();
			}
		}

		/// <summary>
		/// dcs数据同步
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tisDcsData_Click(object sender, EventArgs e)
		{
			TaskForm taskForm = new FrmOpcServerSync();
			if (HaveOpened(taskForm, this))
			{
				taskForm.MdiParent = this;
				taskForm.Show();
			}
		}

		/// <summary>
		/// 区域人数同步
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tsiBuild_Click(object sender, EventArgs e)
		{
			TaskForm taskForm = new FrmBuildSync();
			if (HaveOpened(taskForm, this))
			{
				taskForm.MdiParent = this;
				taskForm.Show();
			}
		}
		/// <summary>
		/// 门禁同步
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tsiAccessControl_Click(object sender, EventArgs e)
		{
			TaskForm taskForm = new FrmAccessControl();
			if (HaveOpened(taskForm, this))
			{
				taskForm.MdiParent = this;
				taskForm.Show();
			}
		}


		#endregion


	}
}
