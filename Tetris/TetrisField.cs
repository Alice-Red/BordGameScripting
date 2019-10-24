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
        public Mino Holding = Mino.None;
        public bool CanHold = false;

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

        private void GenerateMino() {
            Current = new FallingBlock() {
                Mino = Generator.Generate(),
                State = MainPartConfiguration.Generated,
                Position = TetrisUtils.GeneratePosition,
                Rotate = 0
            };
        }

        public bool Fall() {
            bool flg = true;
            Current.State = MainPartConfiguration.Floating;
            var t = Current.Shape().For((i, j, s) => {
                if (s != 0 && Field.FromRC(Current.Position + new RawColumn(i + 1, j)) != 0)
                    flg = false;
            });
            if (flg) {
                Current.Position.Y -= 1;
                return true;
            } else {
                Current.State = MainPartConfiguration.Waiting;
                return false;
            }
        }


        public void Place() {

            Overlapped().ForEach(s => {
                field[s.Raw, s.Column] = (int) Current.Mino;
            });


            Current.State = MainPartConfiguration.Placed;

        }

        public void HardDrop() {
            while (!Fall())
                ;
            Current.State = MainPartConfiguration.Placed;
        }


        public bool Rotate(bool left) {
            var shape = left ? TetrisUtils.RotateAnticlockwise(Current.Shape()) : TetrisUtils.RotateClockwise(Current.Shape());

            RawColumn[] tryList = new RawColumn[] {
                new RawColumn( 0, 0),
                new RawColumn( 1, 0),
                new RawColumn(-2, 0),
            };

            foreach (var item in tryList) {
                if (Canput(Current.Position + item, shape)) {
                    Current.Position += item;
                    Current.Rotate += left ? -1 : 1;
                    return true;
                }
            }

            return false;

        }

        public bool Move(bool left) {
            var diff = left ? RawColumn.New(0, -1) : RawColumn.New(0, 1);
            var t = Overlapped().Select(s => s + diff).ToArray();

            foreach (var item in t) {
                if (Field.FromRC(item) != 0)
                    return false;
            }

            Current.Position += left ? RawColumn.New(0, -1) : RawColumn.New(0, 1);
            return true;
        }

        public void Hold() {
            //Mino t;
            //if(Holding !=Mino.None)
            //    t = 
            //Holding = Current.Mino;

            //Current.State = MainPartConfiguration.Placed;
        }



        // 消せるところ
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

        // ライン消し
        private void EraseLine(params int[] lines) {
            var tmp = field.ToJagged().Reverse();
            var senil = lines.Select(s => TetrisUtils.BackJump(s, 40)).ToArray();

            var result = tmp.Where((s, i) => i.Any(senil));

            int[] empty = new int[] { -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1 };

            for (int i = 0; i < lines.Length; i++) {
                result.Insert(empty);
            }
            field = result.Reverse().To2D();
        }

        private void Obstacle(int line) {
            int index = Util.DICE(10);
            int[] empty = new int[] { -1, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, -1 };
            empty[index + 1] = 0;

            var result = field.ToJagged();
            for (int i = 0; i < line; i++) {
                result.Insert(empty, 40);
            }
            field = result.To2D();
        }

        private List<RawColumn> Surroundings() {
            List<RawColumn> result = new List<RawColumn>();
            Current.Shape().For((i, j, s) => {
                if (s == 1) {
                    foreach (var item in TetrisUtils.Direction4) {
                        if (Current.Shape().FromRC((RawColumn.New(i, j) + item)) != 1)
                            result.AddUnique(Current.Position + RawColumn.New(i, j) + item);
                    }
                }
            });
            return result;
        }
        private List<RawColumn> Surroundings(params RawColumn[] rc) {
            List<RawColumn> result = new List<RawColumn>();
            Current.Shape().For((i, j, s) => {
                if (s == 1)
                    foreach (var item in rc)
                        if (Current.Shape().FromRC((RawColumn.New(i, j) + item)) != 1)
                            result.AddUnique(Current.Position + RawColumn.New(i, j) + item);
            });
            return result;
        }

        private IEnumerable<RawColumn> Overlapped() {
            var t = Current.Shape();

            int FirstDim = t.GetLength(0);
            int SecondDim = t.GetLength(1);

            for (int i = 0; i < FirstDim; i++) {
                for (int j = 0; j < SecondDim; j++) {
                    if (t[i, j] == 1)
                        yield return Current.Position + new RawColumn(i, j);
                }
            }
        }
        public static IEnumerable<RawColumn> Overlapped(RawColumn position, int[,] obj) {

            int FirstDim = obj.GetLength(0);
            int SecondDim = obj.GetLength(1);

            for (int i = 0; i < FirstDim; i++) {
                for (int j = 0; j < SecondDim; j++) {
                    if (obj[i, j] == 1)
                        yield return position + new RawColumn(i, j);
                }
            }
        }

        public bool Canput(RawColumn rc, int[,] shape) {
            return Overlapped(rc, shape).All(s => Field.FromRC(s) == 0);
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
