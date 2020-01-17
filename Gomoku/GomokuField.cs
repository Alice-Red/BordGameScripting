using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib.Core.Base;
using GameLib.Core.Util;
using RUtil;

namespace Gomoku
{
    public class GomokuField : GridField
    {

        public GomokuField() : base(16) {


        }


        public override bool Canput(int r, int c, int t) {
            return (field[r, c] == 0);
        }

        public override int CheckWinner() {
            var t = this.Connected(5);
            if (t.Count() > 0)
                return t.ElementAt(0).Player.ToInt();
            else
                return 0;
        }


        /// <summary>
        /// 1方向を見ます
        /// </summary>
        /// <param name="rc"></param>
        /// <param name="rp"></param>
        /// <returns></returns>
        public IEnumerable<RawColumn> ScanLine(RawColumn rc, RelativeName rp) {
            var start = Get(rc).ToPlayerColor2P();
            if (start.Any(PlayerColor2P.Black, PlayerColor2P.White)) {
                int color = start.ToInt();
                RawColumn current = rc;
                while (InField(current) && Get(current) == color) {
                    yield return current;
                    current += Relative.Position[rp];
                }
            } else {
                int color = start.ToInt();
                RawColumn current = rc;
                while (color == 0 || Get(current).ToPlayerColor2P() != color.ToPlayerColor2P().Reverse()) {
                    yield return current;
                    current += Relative.Position[rp];
                    if (color == 0 && Get(current).Any(1, -1))
                        color = Get(current);
                }
            }
        }


        /// <summary>
        /// 4方向を見ます
        /// </summary>
        /// <param name="rc"></param>
        /// <returns></returns>
        public IEnumerable<GomokuAnalysisBlock> ScanLises(RawColumn rc) {
            //int color = Get(rc);
            var rp = new RelativeName[] {
                RelativeName.Right,
                RelativeName.LowerRight,
                RelativeName.Lower,
                RelativeName.LowerLeft,
            };

            foreach (var item in rp)
                yield return new GomokuAnalysisBlock(ScanLine(rc, item).ToArray(), item, Get(rc).ToPlayerColor2P());

        }

        /// <summary>
        /// 指定されたもしくはすべての数の連結している位置を返します
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public IEnumerable<GomokuAnalysisBlock> Connected(int num = 0) {
            var exists = this.Exists();
            List<GomokuAnalysisBlock> results = new List<GomokuAnalysisBlock>();

            foreach (var item in exists) {
                ScanLises(item).ForEach(s => System.Diagnostics.Debug.WriteLine($"{results.AddGet(s).ToString()}"));

            }
            return results.Where(s => s.Connect == num);
        }


        /// <summary>
        /// 置いたら N連 になる位置を返します
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public IEnumerable<RawColumn> BeConnected(int num) {
            var gab = Connected(num - 1);
            foreach (var item in gab) {
                foreach (var t in item.ValidPosition) {
                    if (InField(t) && Get(t) == 0)
                        yield return t;
                }
            }


        }

        /// <summary>
        /// 置いたら A連からB連 になる位置を返します
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="free">両端が開いてなければならない</param>
        /// <returns></returns>
        public IEnumerable<RawColumn> BeConnected(int a, int b, bool free = false) {
            var gab = Enumerable.Range(Math.Min(a, b), Math.Abs(a - b)).Select(s => Connected(s)).SelectMany(s => s);
            foreach (var item in gab) {
                foreach (var t in item.ValidPosition) {
                    if (InField(t) && Get(t) == 0)
                        yield return t;
                }
            }
        }

        /// <summary>
        /// 置くことができるすべての位置
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RawColumn> CanPutList() {
            for (int r = 0; r < Height; r++)
                for (int c = 0; c < Width; c++)
                    if (Get(r, c) == 0)
                        yield return RawColumn.New(r, c);
        }

        /// <summary>
        /// 置いたら5連になる位置を返します
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RawColumn> BeConnected5() => BeConnected(5, 5, false);


    }
}
