using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib.Core.Base;
using GameLib.Core.Util;

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


        //public 


    }
}
