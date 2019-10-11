using GameLib.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class TetrisUtils
    {
        public static (RawColumn, RawColumn) NomalizeRect(RawColumn point1, RawColumn point2) {
            var topLeft = RawColumn.New(
                Math.Min(point1.Raw, point2.Raw),
                Math.Min(point1.Column, point2.Column)
                );

            var rightBottom = RawColumn.New(
                Math.Max(point1.Raw, point2.Raw),
                Math.Max(point1.Column, point2.Column)
                );

            return (topLeft, rightBottom);
        }
    }
}
