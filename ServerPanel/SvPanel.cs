using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerPanel
{
    public partial class SvPanel : Form
    {
        public LogSystem logger;

        public bool isActive { get; set; }
        public List<Client> clientList = new List<Client>();

        private ServerController svController;

        public SvPanel()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.logger = new LogSystem(lstLog);
            isActive = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Text = isActive ? "Start" : "Stop";
            this.isActive = !isActive;

            if (isActive)
            {
                logger.log("Server thread has been started");
                svController = new ServerController(this);
                svController.StartMainServerThread();
            }
            else 
            {
                logger.log("Server thread has been terminated");
            }

        }

        public void DisplayConnectedClients()
        {
            if (this.lblClients.InvokeRequired)
                lstLog.Invoke((MethodInvoker)delegate { this.lblClients.Text = clientList.Count.ToString() + " connected client(s)"; });          
            else
                lblClients.Text = clientList.Count.ToString() + " connected client(s)";
        }

    }
}
