﻿using System;
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

        public MainPartConfiguration State;

        public int Rotate;

        public Mino[] Nexts;

        public FallingBlock(RawColumn position, Mino mino, int rotate, Mino[] nexts) {
            Position = position;
            Mino = mino;
            State = MainPartConfiguration.None;
            Rotate = rotate;
            Nexts = nexts;
        }

        public void Rotation(int d) {
            var r = Rotate + d;
            Rotate = r.RangeMove(-1, 2);
        }

        public int[,] Shape() {
            var sh = Minos.MinoP[Mino];
            var r = Rotate;

            while (r != 0) {
                if (r < 0) {
                    sh = TetrisUtils.RotateAnticlockwise(sh);
                    r += 1;
                } else if (r > 0) {
                    sh = TetrisUtils.RotateClockwise(sh);
                    r -= 1;
                }
            }
            return sh;
        }

    }
}
