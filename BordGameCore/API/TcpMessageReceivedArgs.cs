using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.API
{
    public class TcpMessageReceivedArgs
    {
        public string IpAddress { get; }
        public string Message { get; }

        public TcpMessageReceivedArgs(string ipAddress, string message) {
            IpAddress = ipAddress;
            Message = message;
        }
    }
}
