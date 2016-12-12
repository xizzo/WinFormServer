﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace ServerPanel
{

    class ServerController
    {
        private SvPanel svPanel { get; set; }
        public Thread svMainThread;
        private TcpListener svSocket;
        private TcpClient clSocket;

        public ServerController(SvPanel svPanel)
        {
            this.svPanel = svPanel;
        }

        public void StartMainServerThread()
        {
            svMainThread = new Thread(new ThreadStart(DoMainSvThread));
            svMainThread.Start();
        }

        private void DoMainSvThread()
        {
            try
            {
                svSocket = new TcpListener(new IPEndPoint(IPAddress.Parse(Properties.Settings.Default.hostAddress), Properties.Settings.Default.hostPort));
                clSocket = default(TcpClient);

                svSocket.Start();

                while (true)
                {
                    clSocket = svSocket.AcceptTcpClient();
                    svPanel.logger.log("Connection incoming: " + clSocket.Client.RemoteEndPoint.ToString());
                }
            }
            catch (Exception ex)
            {
                svMainThread.Abort();
            }

        }
        
        private void OnThreadExit()
        {
            svPanel.logger.log("Server main thread has been closed!");
        }
    }
}
