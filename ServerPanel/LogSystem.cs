using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Automation.Provider;
using System.Windows.Automation.Text;

namespace ServerPanel
{
    public class LogSystem
    {
        public ListBox lstLog { get; set; }

        public LogSystem(ListBox lstLog)
        {
            this.lstLog = lstLog;
        }

        public void log(string txt)
        {
            if (lstLog.Items.Count > 200)
            {
                lstLog.Items.RemoveAt(0);
            }
            String msg = string.Format("[{0:t}] {1}", DateTime.Now, txt);
            if (this.lstLog.InvokeRequired)
            {
                lstLog.Invoke((MethodInvoker)delegate { this.lstLog.Items.Add(msg); lstLog.TopIndex = lstLog.Items.Count - 1; });
            }                
            else
            {
                lstLog.Items.Add(msg);
                lstLog.TopIndex = lstLog.Items.Count - 1;
            }
        }

    }
}

