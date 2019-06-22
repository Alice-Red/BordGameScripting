using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static int Ramdom(int a, int b) {
            return Math.Min(a, b) + DICE(Math.Max(a, b) - Math.Min(a, b) + 1) - 1;
        }

        public static T Ramdom<T>(this IEnumerable<T> source) {
            int n = source.Count();
            return source.ElementAt(DICE(n) - 1);
        }

        public static bool Include<T>(this T[] source, T[] target) {
            for (int i = 0; i < target.Length; i++)
                if (!source.Contains(target[i]))
                    return false;
            return true;
        }
    }
}
