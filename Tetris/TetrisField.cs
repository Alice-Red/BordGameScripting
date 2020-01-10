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

    public class TetrisField : GridField
    {
        public FallingBlock Current;
        //public MinoGenerator Generator;
        public Mino Holding = Mino.None;

        /// <summary>
        /// ホールドができるかどうか
        /// </summary>
        public bool CanHold = false;

        /// <summary>
        /// 高速化
        /// [触らないでください]
        /// </summary>
        public bool SuperFast = false;
        //public bool OnGround = false;

        /// <summary>
        /// 現在のスコア
        /// </summary>
        public int Score = 0;

        public int Lines = 0;

        public Mino[] Nexts;

        public TetrisField() : base(12, 41) {
            field = new int[Height, Width];
            CreateField();
            //Generator = new MinoGenerator();
            //this.GenerateMino();
        }

        private void CreateField() {
            Enumerable.Range(0, 41).ForEach(s => {
                field[s, 0] = -1;
                field[s, 11] = -1;
            });
            Enumerable.Range(0, 12).ForEach(s => {
                field[40, s] = -1;
            });
        }


        public IEnumerable<int[]> GetRect(RawColumn point1, RawColumn point2) {
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
            return GetRect(RawColumn.New(20, 1), RawColumn.New(39, 10)).ToArray();
        }

        public int[][] DrawableField() {
            var tmp = GetShowableField();
            var now = Current.Shape().ToJagged();
            for (int i = 0; i < now.Length; i++) {
                for (int j = 0; j < now[i].Length; j++) {
                    var rc = Current.Position - RawColumn.New(20, 1) + RawColumn.New(i, j);
                    if (rc.Raw.InBetween(0, 19) && rc.Column.InBetween(0, 9) && now[i][j] == 1)
                        tmp[rc.Raw][rc.Column] = now[i][j];
                }
            }
            return tmp;
        }

        internal bool Fall() {
            if (Current.State.Any(MainPartConfiguration.Placed))
                return false;

            bool flg = true;
            Current.State = MainPartConfiguration.Floating;
            var t = Current.Shape().For((i, j, s) => {
                if (s != 0 && field.FromRC(Current.Position + new RawColumn(i + 1, j)) != 0)
                    flg = false;
            });
            if (flg) {
                Current.Position.Y += 1;
                return true;
            } else {
                //Current.State = MainPartConfiguration.Waiting;
                Place();
                return false;
            }
        }

        internal void Place() {

            Overlapped().ForEach(s => {
                field[s.Raw, s.Column] = (int) Current.Mino;
            });


            Current.State = MainPartConfiguration.Placed;
            //CheckWinner();
            //GenerateMino();
        }

        internal void HardDrop() {
            while (Fall())
                ;
            //Current.State = MainPartConfiguration.Placed;
        }

        //public void WaitDrop() {

        //}

        internal bool Rotate(bool right) {
            if (Current.State.Any(MainPartConfiguration.Placed))
                return false;

            var shape = right ? TetrisUtils.RotateAnticlockwise(Current.Shape()) : TetrisUtils.RotateClockwise(Current.Shape());

            RawColumn[] tryList = new RawColumn[] {
                    new RawColumn( 0, 0),
                    new RawColumn( 1, 0),
                    new RawColumn(-2, 0),
                };

            foreach (var item in tryList) {
                if (Canput(Current.Position + item, shape)) {
                    Current.Position += item;
                    Current.Rotate += right ? 1 : -1;
                    Current.State = MainPartConfiguration.Falling;
                    //OnGround = false;
                    return true;
                }
            }
            return false;
        }

        internal bool Move(bool right) {
            var diff = right ? RawColumn.New(0, 1) : RawColumn.New(0, -1);
            var t = Overlapped().Select(s => s + diff).ToArray();
            if (Current.State != MainPartConfiguration.Waiting)
                Current.State = MainPartConfiguration.Falling;

            foreach (var item in t) {
                if (field.FromRC(item) != 0)
                    return false;
            }

            Current.Position += right ? RawColumn.New(0, 1) : RawColumn.New(0, -1);
            //OnGround = false;
            Current.State = MainPartConfiguration.Falling;

            return true;
        }

        internal void Hold() {
            //Mino t;
            //if(Holding !=Mino.None)
            //    t = 
            //Holding = Current.Mino;

            //Current.State = MainPartConfiguration.Placed;
        }

        // 消せるところ
        internal int ScanErase() {
            var eraseList = GetShowableField().Select((s, i) => {
                if (!s.Contains(0))
                    return (i, 1);
                else
                    return (i, 0);
            }).Where(f => f.Item2 == 1).Select(h => h.i).ToArray();

            if (eraseList.Length > 0)
                EraseLine(eraseList);
            return eraseList.Length;
        }

        // ライン消し
        private void EraseLine(params int[] lines) {
            var tmp = field.ToJagged().Reverse();
            var senil = lines.Select(s => TetrisUtils.BackJump(s, 20)).ToArray();

            var result = tmp.Where((s, i) => !i.Any(senil));

            int[] empty = new int[] { -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1 };

            for (int i = 0; i < lines.Length; i++) {
                result = result.Insert(empty);
            }
            Score += (lines.Length * 100 + ((int) Math.Pow(lines.Length - 1, 2) * 10));
            if (lines.Length > 0 && lines[0] + lines.Length <= lines.Last()) {
                Score += 5;
            }
            Lines += lines.Length;
            field = result.Reverse().To2D();
        }

        internal void Obstacle(int line) {
            int index = Util.DICE(10);
            int[] empty = new int[] { -1, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, -1 };
            empty[index + 1] = 0;

            var result = field.ToJagged();
            for (int i = 0; i < line; i++) {
                result = result.Insert(empty, 40).Skip(1).ToArray();
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
            return Overlapped(rc, shape).All(s => field.FromRC(s, -1) == 0);
        }

        public override bool Canput(int r, int c, int t) {
            return false;
        }

        public override int CheckWinner() {
            var deadRect = GetRect(RawColumn.New(0, 4), RawColumn.New(19, 7));
            bool flg = false;
            deadRect.ForEach(f => {
                f.ForEach(h => flg |= h != 0);
            });
            return flg ? -1 : 0;
        }
    }
}
