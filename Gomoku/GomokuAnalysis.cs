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
    public static class GomokuAnalysis
    {

        /// <summary>
        /// 1方向を見ます
        /// </summary>
        /// <param name="field"></param>
        /// <param name="rc"></param>
        /// <param name="rp"></param>
        /// <returns></returns>
        public static IEnumerable<RawColumn> ScanLine(this GomokuField field, RawColumn rc, RelativeName rp) {
            var start = field.Get(rc).ToPlayerColor2P();
            if (start.Any(PlayerColor2P.Black, PlayerColor2P.White)) {
                int color = start.ToInt();
                RawColumn current = rc;
                while (field.Get(current).ToPlayerColor2P() != color.ToPlayerColor2P().Reverse()) {
                    yield return current;
                    current += Relative.Position[rp];
                }
            } else {
                int color = start.ToInt();
                RawColumn current = rc;
                while (color == 0 || field.Get(current).ToPlayerColor2P() != color.ToPlayerColor2P().Reverse()) {
                    yield return current;
                    current += Relative.Position[rp];
                    if (color == 0 && field.Get(current).Any(1, -1))
                        color = field.Get(current);
                }
            }

        }


        /// <summary>
        /// 4方向を見ます
        /// </summary>
        /// <param name="field"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        public static IEnumerable<RawColumn[]> ScanLises(this GomokuField field, RawColumn rc) {
            int color = field.Get(rc);
            var rp = new RelativeName[] {
                RelativeName.Right,
                RelativeName.LowerRight,
                RelativeName.Lower,
                RelativeName.LowerLeft,
            };

            foreach (var item in rp)
                yield return ScanLine(field, rc, item).ToArray();

        }

        /// <summary>
        /// 指定されたもしくはすべての数の連結している位置を返します
        /// </summary>
        /// <param name="field"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static IEnumerable<RawColumn[]> Connected(this GomokuField field, int num = 0) {
            var exists = field.Exists();
            List<RawColumn[]>[] results = Enumerable.Range(0, 4).Select(s => new List<RawColumn[]>()).ToArray();

            foreach(var item in exists) {



            }


        }


        /// <summary>
        /// 置いたら N連 になる位置を返します
        /// </summary>
        /// <param name="field"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static IEnumerable<RawColumn> BeConnected(this GomokuField field, int num) {



        }

        /// <summary>
        /// 置いたら A連からB連 になる位置を返します
        /// </summary>
        /// <param name="field"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="free">両端が開いてなければならない</param>
        /// <returns></returns>
        public static IEnumerable<RawColumn> BeConnected(this GomokuField field, int a, int b, bool free = false) {

            

        }


        /// <summary>
        /// 置いたら5連になる位置を返します
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public static IEnumerable<RawColumn> BeConnected5(this GomokuField field) => BeConnected(field, 5, 5, false);

    }
}
