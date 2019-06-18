using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib.API;
using GameLib.Core.Util;

namespace Gomoku
{
    public struct GomokuInputObject : IInputObjectContainer
    {
        public int Raw { get; set; }
        public int Column { get; set; }

        public GomokuInputObject(int x, int y) {

            Raw = y;
            Column = x;
        }

        public GomokuInputObject(RawColumn rc) {
            Raw = rc.Raw;
            Column = rc.Column;
        }
    }
}
