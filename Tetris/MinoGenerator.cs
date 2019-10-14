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
            get {
                while (_nexts.Count() < nextCount) {
                    int index = GameLib.API.Util.DICE(Buffer.Length);
                    _nexts.Enqueue(Buffer[index]);
                }
                return _nexts;
            }
            set {

            }
        }


        public Mino[] Nexts => nexts.Select(s => s.ToEnum<Mino>()).ToArray();
        public Mino Current;

        private int nextCount = 0;
        public int NextCount {
            get { return nextCount; }
            private set { nextCount = value; }
        }

        public MinoGenerator(int nextcount) {
            this.nextCount = nextCount;


        }

        public Mino Generate() {

        }


    }
}
