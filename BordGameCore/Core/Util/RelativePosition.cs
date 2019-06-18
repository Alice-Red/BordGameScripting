using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Core.Util
{
    public class Relative
    {
        public static readonly Dictionary<RelativeName, RawColumn> Position = new Dictionary<RelativeName, RawColumn> {
            { RelativeName.UpperLeft,   new RawColumn(-1, -1) },
            { RelativeName.Upper,       new RawColumn(-1, +0) },
            { RelativeName.UpperRight,  new RawColumn(-1, +1) },
            { RelativeName.Right,       new RawColumn(+0, +1) },
            { RelativeName.LowerRight,  new RawColumn(+1, +1) },
            { RelativeName.Lower,       new RawColumn(+1, +0) },
            { RelativeName.LowerLeft,   new RawColumn(+1, -1) },
            { RelativeName.Left,        new RawColumn(+0, -1) },
        };
    }
}
