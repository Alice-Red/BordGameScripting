﻿using System;
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

        public GomokuField() : base(15) {


        }


        public override bool Canput(int r, int c, int t) {
            return (Field[r, c] == 0);
        }

        public override int CheckWinner() {


            var t = this.Connected(5);
            if (t.Count() > 0)
                return this.Get(t.ElementAt(0)[0]);
            else
                return 0;
        }


        /// <summary>
        /// 1方向を見ます
        /// </summary>
        /// <param name="field"></param>
        /// <param name="rc"></param>
        /// <param name="rp"></param>
        /// <returns></returns>
        public IEnumerable<RawColumn> ScanLine(RawColumn rc, RelativeName rp) {
            var start = Get(rc).ToPlayerColor2P();
            if (start.Any(PlayerColor2P.Black, PlayerColor2P.White)) {
                int color = start.ToInt();
                RawColumn current = rc;
                while (Get(current).ToPlayerColor2P() != color.ToPlayerColor2P().Reverse()) {
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
        /// <param name="field"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        public IEnumerable<RawColumn[]> ScanLises(RawColumn rc) {
            int color = Get(rc);
            var rp = new RelativeName[] {
                RelativeName.Right,
                RelativeName.LowerRight,
                RelativeName.Lower,
                RelativeName.LowerLeft,
            };

            foreach (var item in rp)
                yield return ScanLine(rc, item).ToArray();

        }

        /// <summary>
        /// 指定されたもしくはすべての数の連結している位置を返します
        /// </summary>
        /// <param name="field"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public IEnumerable<RawColumn[]> Connected(int num = 0) {
            var exists = this.Exists();
            List<RawColumn[]>[] results = Enumerable.Range(0, 4).Select(s => new List<RawColumn[]>()).ToArray();

            foreach (var item in exists) {
                for(int i = 0; i < results.Length; i++) {
                    results[i].Add()
                }


            }


        }


        /// <summary>
        /// 置いたら N連 になる位置を返します
        /// </summary>
        /// <param name="field"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public IEnumerable<RawColumn> BeConnected(int num) {



        }

        /// <summary>
        /// 置いたら A連からB連 になる位置を返します
        /// </summary>
        /// <param name="field"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="free">両端が開いてなければならない</param>
        /// <returns></returns>
        public IEnumerable<RawColumn> BeConnected(int a, int b, bool free = false) {



        }


        /// <summary>
        /// 置いたら5連になる位置を返します
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public IEnumerable<RawColumn> BeConnected5() => BeConnected(5, 5, false);


    }
}
