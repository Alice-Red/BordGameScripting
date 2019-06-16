using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BordGameCore.GameCore.Base;
using BordGameCore.GameCore.Util;

namespace Gomoku
{
    public class GomokuField : GridField
    {


        public override bool Canput(int r, int c, int t) {
            return (Field[r, c] == 0);
        }

        internal override int CheckWinner() {

        }

        public 


    }
}
