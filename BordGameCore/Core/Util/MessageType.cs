﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Core.Util
{
    public enum MessageType
    {
        None = 0,

        Info = 0x01,
        Debug = 0x02,
        Warning = 0x04,
        Error = 0x08,

        Default = 0b1100,
        All = 0b1111,

        Reserved = 0x40,

    }
}
