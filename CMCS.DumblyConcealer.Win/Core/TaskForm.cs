using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMCS.DumblyConcealer.Win.Core
{
    public partial class TaskForm : Form
    {
        public TaskForm()
        {
            InitializeComponent();
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(564, 332);
            this.Name = "TaskForm";
            this.ResumeLayout(false);
        }
    }
}
