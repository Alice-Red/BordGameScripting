using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RUtil;

namespace GameLib.Core.Util
{
    public struct SafeArray<T>
    {
        private T[,] array;
        public int Length { get; }

        public T[,] Array {
            get {
                int length = Length;
                return array.ToJagged().Where((s, i) => i != 0 && i != length + 1).Where((d, j) => (j != 0 && j != length + 1)).To2D();
            }
        }

        public SafeArray(int length) {
            Length = length;
            array = Enumerable.Range(0, Length + 2).Select(s => Enumerable.Range(0, length + 2).Select(f => (T) Activator.CreateInstance(typeof(T))).ToArray()).To2D();
        }

        public T this[int x, int y] {
            get {
                Reset();
                //return array[(x + 1).RangeForce(0, this.Length + 1), (y + 1).RangeForce(0, this.Length + 1)];
                return Array[x.RangeForce(0, this.Length - 1), y.RangeForce(0, this.Length - 1)];
            }
            internal set {
                array[(x + 1).RangeForce(0, this.Length + 1), (y + 1).RangeForce(0, this.Length + 1)] = value;
            }
        }

        public string Debug() {
            return array.ToEnumerable().Chunk(Length + 2).Select(s => s.Join(",")).Join("\n");
        }

        private void Reset() {
            for (int i = 0; i <= Length + 1; i++) {
                array[0, i] = default(T);
                array[i, 0] = default(T);
                array[Length + 1, i] = default(T);
                array[i, Length + 1] = default(T);
            }
        }

    }
}
