using System;
using System.Collections.Generic;
using System.Globalization;
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

        public IEnumerable<int> Heights() {
            var tfield = GetShowableField();
            foreach (var item in tfield.Columns()) {
                int counter = 20;
                foreach (var t2 in item) {
                    if (t2 != 0) {
                        yield return counter;
                        break;
                    }
                    counter--;
                }
            }
        }

        public IEnumerable<int> Holes() {
            var tfield = GetShowableField();
            var hts = Heights().ToArray();
            for (int i = 0; i < hts.Length; i++) {
                int counter = 0;
                for (int j = hts[i]; j < 20; j++)
                    if (tfield[i][j] == 0) {
                        counter++;
                    }
                yield return counter;
            }
        }

        public int[] ScanFlat(int size) {
            var hts = Heights().ToArray();


        }


        //private IEnumerable<int> Void() {
        //    var source = this.GetShowableField();
        //    source
        //}


    }
}
