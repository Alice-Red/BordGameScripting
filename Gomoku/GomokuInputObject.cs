using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib.API;
using GameLib.Core;

namespace Gomoku
{
    public struct GomokuInputObject : IInputObjectContainer
    {
        public int X { get; set; }
        public int Y { get; set; }

        public GomokuInputObject(int x, int y) {
            X = x;
            Y = y;
        }

        public GomokuInputObject(RawColumn rc) {
            X = rc.GetX();
            Y = rc.GetY();
        }
    }
}
