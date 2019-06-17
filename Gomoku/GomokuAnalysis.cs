using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BordGameCore.GameCore.Base;
using BordGameCore.GameCore.Util;
using RUtil;

namespace Gomoku
{
    public static class GomokuAnalysis
    {

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


        public static IEnumerable<RawColumn[]> Connected(this GomokuField field, int num) {
            var exists = field.Exists();
            List<RawColumn[]>[] results = Enumerable.Range(0, 4).Select(s => new List<RawColumn[]>()).ToArray();

            return results[0];


        }



        public static IEnumerable<RawColumn> BeConnected(this GomokuField field, int num) {
            yield return RawColumn.New(0, 0);

        }

    }
}
