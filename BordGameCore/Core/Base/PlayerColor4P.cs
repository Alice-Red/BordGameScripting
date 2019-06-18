using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Core.Base
{
    public enum PlayerColor4P
    {
        None = 0,
        Red = 0b0001,
        Blue = 0b0010,
        Green = 0b0100,
        Yellow = 0b1000,
        Disable = 0b00010000
    }
}
