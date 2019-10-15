using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
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
        public MinoGenerator Generator = new MinoGenerator();

        public TetrisField() : base(11, 41) { }

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
