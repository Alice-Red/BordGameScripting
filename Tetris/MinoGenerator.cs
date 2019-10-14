using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RUtil;

namespace Tetris
{
    public class MinoGenerator
    {

        private int[] buffer = new int[0];
        private int[] Buffer {
            get {
                if (buffer.Length == 0) 
                    buffer = Enumerable.Range(1, 7).ToArray();
                return buffer;
            }
        }

        private Queue<int> _nexts;
        private Queue<int> nexts {
            get { }
            set {

            }
        }


        public Mino[] Nexts => nexts.Select(s => s.ToEnum<Mino>()).ToArray();
        public Mino Current;

        public MinoGenerator(int nextcount) {
        }

        public Mino Generate() {

        }


    }
}
