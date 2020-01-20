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
        public static readonly RawColumn GeneratePosition = new RawColumn(16, 4);
        public static readonly int[] BasicScore = new int[] { 0, 40, 100, 300, 1200 };

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

        public static int[,] RotateClockwise(int[,] g) {
            // 引数の2次元配列 g を時計回りに回転させたものを返す
            int rows = g.GetLength(0);
            int cols = g.GetLength(1);
            var t = new int[cols, rows];
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    t[j, rows - i - 1] = g[i, j];
                }
            }
            return t;
        }

        public static int[,] RotateAnticlockwise(int[,] g) {
            // 引数の2次元配列 g を反時計回りに回転させたものを返す
            int rows = g.GetLength(0);
            int cols = g.GetLength(1);
            var t = new int[cols, rows];
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    t[cols - j - 1, i] = g[i, j];
                }
            }
            return t;
        }

        public static int BackJump(int num, int area) {
            return area - num;
        }

        public static RawColumn[] Direction4 = new RawColumn[] {
            RawColumn.New( -1,  0 ),
            RawColumn.New(  0, -1 ),
            RawColumn.New(  1,  0 ),
            RawColumn.New(  0,  1 ),
        };

    }
}
