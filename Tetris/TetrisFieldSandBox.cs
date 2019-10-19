using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class TetrisFieldSandBox : TetrisField
    {
        public TetrisFieldSandBox(TetrisField f) {
            this.field = f.Field;
            this.Current = f.Current;
            this.Generator = f.Generator;
        }

        //public void 


    }
}
