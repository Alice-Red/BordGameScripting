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
            var tfield = GetShowableField().Reverse().ToArray();
            var hts = Heights().ToArray();
            for (int i = 0; i < hts.Length; i++) {
                int counter = 0;
                for (int j = 0; j < hts[i]; j++)
                    if (tfield[i][j] == 0) {
                        counter++;
                    }
                yield return counter;
            }
        }

        public int[] ScanFlat(int size) {
            var hts = Heights().ToArray();
            List<int> result = new List<int>();
            for (int i = 0; i < hts.Length - (size - 1); i++) {
                int a = hts[i];
                bool flg = true;
                for (int j = i + 1; j < size - 1; j++) {
                    if (hts[j] != a) {
                        flg = false;
                        break;
                    }
                }
                if (flg)
                    result.Add(i);
            }
            return result.ToArray();

        }

        public int[] ScanUndulation(int[] depth) {
            var hts = Heights().ToArray();
            List<int> result = new List<int>();
            for (int i = 0; i < hts.Length - (depth.Length - 1); i++) {
                //int a= 
                bool flg = true;
                //int b = 0;
                for(int j = 0; j < depth.Length; j++) {
                    if (hts[i + j + 1] != hts[i] + depth[j]) {
                        flg = false;
                        break;
                    }
                }
                if (flg)
                    result.Add(i);
            }
            return result.ToArray();
        }



        //private IEnumerable<int> Void() {
        //    var source = this.GetShowableField();
        //    source
        //}


    }
}
