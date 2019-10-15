using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RUtil;
using GameLib.API;
using GameLib.Core.Util;

namespace Tetris
{
    public struct FallingBlock
    {
        public RawColumn Position;

        public Mino Mino;

        public int Rotate;

        public FallingBlock(RawColumn position, Mino mino, int rotate) {
            Position = position;
            Mino = mino;
            Rotate = rotate;
        }

        public void Rotation(int d) {
            var r = Rotate + d;
            Rotate = r.RangeMove(-1, 2);
        }

        public int[,] Shape() {
            var sh = Minos.MinoP[Mino];
            var r = Rotate;

            while (r == 0) {
                if (r < 0)
                    sh = Tetris.TetrisUtils.RotateAnticlockwise(sh);
                else if (r > 0)
                    sh = Tetris.TetrisUtils.RotateClockwise(sh);
            }
            return sh;
        }





    }
}
