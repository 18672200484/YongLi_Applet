using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMCS.DumblyConcealer.Win
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool notRun;
            using (Mutex mutex = new Mutex(true, Application.ProductName, out notRun))
            {
                if (notRun)
                    Application.Run(new MDIParent());
                else
                    MessageBox.Show("程序正在运行", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
