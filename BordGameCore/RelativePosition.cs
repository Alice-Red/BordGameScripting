using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BordGameCore
{
    class RelativePosition
    {
        public static readonly Dictionary<Relative, (int, int)> RelativePos = new Dictionary<Relative, (int, int)> {
            { Relative.UpperLeft, (-1, -1) },
            { Relative.Upper, (-1, +0) },
            { Relative.UpperRight, (-1, +1) },
            { Relative.Right, (+0, +1) },
            { Relative.LowerRight, (+1, +1) },
            { Relative.Lower, (+1, +0) },
            { Relative.LowerLeft, (+1, -1) },
            { Relative.Left, (+0, -1) },
        };
    }
}
