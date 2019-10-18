using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLib.API;
using GameLib.Core.Base;
using GameLib.Core.Util;
using RUtil;

namespace Tetris
{

    [GameAddon(ID)]
    public class TetrisField : GridField
    {
        public const string ID = "Tetris";
        public FallingBlock Current;
        public MinoGenerator Generator;

        public TetrisField() : base(11, 41) {
            Generator = new MinoGenerator();
        }

        internal IEnumerable<int[]> GetRect(RawColumn point1, RawColumn point2) {
            var point = TetrisUtils.NomalizeRect(point1, point2);
            var tmp = new List<int>();

            for (int i = point.Item1.Raw; i <= point.Item2.Raw; i++) {
                for (int j = point.Item1.Column; j <= point.Item2.Column; j++) {
                    tmp.Add(field[i, j]);
                }
                yield return tmp.ToArray();
                tmp = new List<int>();
            }
        }

        public int[][] GetShowableField() {
            return GetRect(RawColumn.New(1, 20), RawColumn.New(10, 39)).ToArray();
        }


        public int[,] DrawableField() {
            var tmp = GetShowableField();
            var now = Current.Shape().ToJagged();

            for (int i = 0; i < 4; i++) {
                for (int j = 0; j < 4; j++) {
                    tmp[Current.Position.Raw + i][Current.Position.Column + j] = now[i][j];
                }
            }

            return tmp.To2D();
        }

        public void ScanErase() {
            var eraseList = GetShowableField().Select((s, i) => {
                if (!s.Contains(0))
                    return (i, 1);
                else
                    return (i, 0);
            }).Where(f => f.Item2 == 1).Select(h => h.i).ToArray();

            if (eraseList.Length > 0)
                EraseLine(eraseList);
        }

        private void EraseLine(params int[] lines) {

        }




        private void GenerateMino() {
            Current = new FallingBlock() {
                Mino = Generator.Generate(),
                State = MainPartConfiguration.Generated,
                Position = new RawColumn(4, 16),
                Rotate = 0
            };
        }


        public void Fall() {
            bool flg = true;
            Current.State = MainPartConfiguration.Floating;
            var t = Current.Shape().For((i, j, s) => {
                if (s != 0 && Field.FromRC(Current.Position + new RawColumn(i + 1, j)) != 0)
                    flg = false;
            });
            if (flg)
                Current.Position.Y -= 1;
            else
                Current.State = MainPartConfiguration.Waiting;
        }

        public void Place() {
            var hitPlaces = Current.Shape().Columns().Join("").LastIndexOf("1");

        }



        public override bool Canput(int r, int c, int t) {
            return false;
        }

        public override int CheckWinner() {
            var deadRect = GetRect(RawColumn.New(4, 0), RawColumn.New(7, 19));
            bool flg = false;
            deadRect.ForEach(f => {
                f.ForEach(h => flg = h.Any((int[]) Enum.GetValues(typeof(Mino))));
            });
            return flg ? -1 : 0;
        }
    }
}
