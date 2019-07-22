using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.API
{
    class TcpConnecter
    {
        public delegate void TcpMessageReceivedHundler(object sender, TcpMessageReceivedArgs e);
        public event TcpMessageReceivedHundler TcpMessageReceived;


    }
}
