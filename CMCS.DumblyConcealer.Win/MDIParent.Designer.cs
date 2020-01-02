namespace CMCS.DumblyConcealer.Win
{
    partial class MDIParent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIParent));
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.任务TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tsiUserLocation = new System.Windows.Forms.ToolStripMenuItem();
			this.tsiToxicGas = new System.Windows.Forms.ToolStripMenuItem();
			this.tisDcsData = new System.Windows.Forms.ToolStripMenuItem();
			this.tsiBuild = new System.Windows.Forms.ToolStripMenuItem();
			this.tsiAccessControl = new System.Windows.Forms.ToolStripMenuItem();
			this.窗口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.tsslblVersion = new System.Windows.Forms.ToolStripStatusLabel();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.menuStrip.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.任务TToolStripMenuItem,
            this.窗口ToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(632, 25);
			this.menuStrip.TabIndex = 1;
			this.menuStrip.Text = "menuStrip1";
			// 
			// 任务TToolStripMenuItem
			// 
			this.任务TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiUserLocation,
            this.tsiBuild,
            this.tsiToxicGas,
            this.tisDcsData,
            this.tsiAccessControl});
			this.任务TToolStripMenuItem.Name = "任务TToolStripMenuItem";
			this.任务TToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
			this.任务TToolStripMenuItem.Text = "任务(T)";
			// 
			// tsiUserLocation
			// 
			this.tsiUserLocation.Name = "tsiUserLocation";
			this.tsiUserLocation.Size = new System.Drawing.Size(218, 22);
			this.tsiUserLocation.Text = "01.人员定位信息同步";
			this.tsiUserLocation.Click += new System.EventHandler(this.tsiUserLocation_Click);
			// 
			// tsiToxicGas
			// 
			this.tsiToxicGas.Name = "tsiToxicGas";
			this.tsiToxicGas.Size = new System.Drawing.Size(218, 22);
			this.tsiToxicGas.Text = "03.有毒有害气体同步";
			this.tsiToxicGas.Click += new System.EventHandler(this.tsiToxicGas_Click);
			// 
			// tisDcsData
			// 
			this.tisDcsData.Name = "tisDcsData";
			this.tisDcsData.Size = new System.Drawing.Size(218, 22);
			this.tisDcsData.Text = "04.DCS数据同步";
			this.tisDcsData.Click += new System.EventHandler(this.tisDcsData_Click);
			// 
			// tsiBuild
			// 
			this.tsiBuild.Name = "tsiBuild";
			this.tsiBuild.Size = new System.Drawing.Size(218, 22);
			this.tsiBuild.Text = "02.人员定位区域人数同步";
			this.tsiBuild.Click += new System.EventHandler(this.tsiBuild_Click);
			// 
			// tsiAccessControl
			// 
			this.tsiAccessControl.Name = "tsiAccessControl";
			this.tsiAccessControl.Size = new System.Drawing.Size(218, 22);
			this.tsiAccessControl.Text = "05.人脸识别/门禁数据同步";
			this.tsiAccessControl.Click += new System.EventHandler(this.tsiAccessControl_Click);
			// 
			// 窗口ToolStripMenuItem
			// 
			this.窗口ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascadeToolStripMenuItem,
            this.tileVerticalToolStripMenuItem,
            this.tileHorizontalToolStripMenuItem});
			this.窗口ToolStripMenuItem.Name = "窗口ToolStripMenuItem";
			this.窗口ToolStripMenuItem.Size = new System.Drawing.Size(64, 21);
			this.窗口ToolStripMenuItem.Text = "窗口(W)";
			// 
			// cascadeToolStripMenuItem
			// 
			this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
			this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
			this.cascadeToolStripMenuItem.Text = "层叠(C)";
			this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.cascadeToolStripMenuItem_Click);
			// 
			// tileVerticalToolStripMenuItem
			// 
			this.tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
			this.tileVerticalToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
			this.tileVerticalToolStripMenuItem.Text = "垂直平铺(V)";
			this.tileVerticalToolStripMenuItem.Click += new System.EventHandler(this.tileVerticalToolStripMenuItem_Click);
			// 
			// tileHorizontalToolStripMenuItem
			// 
			this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
			this.tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
			this.tileHorizontalToolStripMenuItem.Text = "水平平铺(H)";
			this.tileHorizontalToolStripMenuItem.Click += new System.EventHandler(this.tileHorizontalToolStripMenuItem_Click);
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.tsslblVersion});
			this.statusStrip.Location = new System.Drawing.Point(0, 396);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(632, 22);
			this.statusStrip.TabIndex = 3;
			this.statusStrip.Text = "StatusStrip";
			// 
			// toolStripStatusLabel
			// 
			this.toolStripStatusLabel.Name = "toolStripStatusLabel";
			this.toolStripStatusLabel.Size = new System.Drawing.Size(44, 17);
			this.toolStripStatusLabel.Text = "版本：";
			// 
			// tsslblVersion
			// 
			this.tsslblVersion.Name = "tsslblVersion";
			this.tsslblVersion.Size = new System.Drawing.Size(45, 17);
			this.tsslblVersion.Text = "1.0.0.0";
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 2000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// MDIParent
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(632, 418);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.menuStrip);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip;
			this.Name = "MDIParent";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "集中管控后台处理程序";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MDIParent_FormClosing);
			this.Shown += new System.EventHandler(this.MDIParent_Shown);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem 任务TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 窗口ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsiUserLocation;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileHorizontalToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel tsslblVersion;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem tsiBuild;
        private System.Windows.Forms.ToolStripMenuItem tsiAccessControl;
        private System.Windows.Forms.ToolStripMenuItem tsiToxicGas;
        private System.Windows.Forms.ToolStripMenuItem tisDcsData;
    }
}