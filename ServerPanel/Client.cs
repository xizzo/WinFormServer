using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ServerPanel
{
    public class Client
    {
        public TcpClient clSocket { get; set; }
        public int clID { get; set; }

        public Client(int clID, TcpClient clSocket)
        {
            this.clID = clID;
            this.clSocket = clSocket;
        }
    }
}
