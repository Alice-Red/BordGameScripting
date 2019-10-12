using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RUtil;

namespace GameLib.API
{
    public static class Util
    {
        public static int DICE(int f) {
            if (f == 0)
                return 0;
            byte[] buffer = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rand = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rand.GetBytes(buffer);
            Int32 tmp = System.BitConverter.ToInt32(buffer, 0);
            tmp = Math.Abs(tmp);
            if (tmp > f)
                tmp -= f;
            return (tmp % f) + 1;
        }

        public static int Random(int a, int b) {
            return Math.Min(a, b) + DICE(Math.Max(a, b) - Math.Min(a, b) + 1) - 1;
        }

        public static T Random<T>(this IEnumerable<T> source) {
            int n = source.Count();
            return source.ElementAt(DICE(n) - 1);
        }

        public static T[] Shuffle<T>(this T[] source) {
            var result = new List<T>();
            for(int i = 1; i < source.Length; i++) {
                int a = DICE(source.Length) - 1;
                result.Add(source[a]);
                source = source.Remove(a).ToArray();
            }
            result.Add(source.First());
            return result.ToArray();
        }

        public static bool Include<T>(this T[] source, T[] target, bool strict = false) {
            var sequence = source.ToList();
            for (int i = 0; i < target.Length; i++) {
                if (!sequence.Contains(target[i]))
                    return false;
                sequence.Remove(target[i]);
            }

            return true;
        }
    }
}
