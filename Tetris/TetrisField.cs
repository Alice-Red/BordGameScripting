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
namespace Tetris
{

    [GameAddon(ID)]
    public class TetrisField : GridField
    {
        public const string ID = "Tetris";

        public TetrisField() : base(11, 41) {

        }

        public IEnumerable<int[]> GetRect(RawColumn point1, RawColumn point2) {
            var point = TetrisUtils.NomalizeRect(point1, point2);








        }




        public override bool Canput(int r, int c, int t) {
            return false;
        }

        public override int CheckWinner() {

        }
    }
}
