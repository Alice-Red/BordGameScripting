using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BordGameCore.GameCore.Util
{
    public enum MessageType
    {
        None = 0,

        Info = 0x01,
        Debug = 0x02,
        Warning = 0x04,
        Error = 0x08,

        Reserved = 0x40
    }
}
