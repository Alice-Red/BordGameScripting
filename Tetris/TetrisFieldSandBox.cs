using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RUtil;

namespace Tetris
{
    public class TetrisFieldSandBox : TetrisField
    {
        public TetrisFieldSandBox(TetrisField f) {
            this.field = f.Field;
            this.Current = f.Current;
        }




        //public int ExistHole() {

        //}


        //private IEnumerable<int> Void() {
        //    var source = this.GetShowableField();
        //    source
        //}


    }
}
