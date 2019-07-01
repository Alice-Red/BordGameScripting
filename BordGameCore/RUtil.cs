
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

/**
 *      C#7.2 推奨
 *      バージョンが低いと一部機能が使えません
 */

#region Change log
/**
 * Utility : 49
 * 
 * 
 *   --  変更履歴  --
 *  
 *  2018.11.20: 変更履歴を追加
 *  2019.01.27: public static T ToEnum<T>(this int); を追加
 *  2019.01.28: public static IEnumerable<T> GetValues<T>(); を追加
 *               いくつかのコメントを追加
 *  2019.02.10: 配列変形系，以下を追加
 *              public static T[][] ToJagged<T>(this IEnumerable<IEnumerable<T>>);
 *              public static T[][] ToJagged<T>(this T[,]);
 *              public static T[,] To2D<T>(this IEnumerable<IEnumerable<T>>);
 *              public static T[,] To2D<T>(this T[][]);
 *  2019.02.26: public static int Round(this double);
 *              public static bool Range<T>(this T, T, T);
 *              public static T RangeForce<T>(this T, T, T);
 *              public static double RangeMove(this double, int, int);
 *  2019.03.04: 見やすくしたしついでに何個か増やした
 *              
 *              
 *  
 */
#endregion


namespace RUtil
{
    public static class Utility
    {

        /**-------------------------
         * object拡張系
         * -------------------------
         */
        #region object-Abstruction

        /// <summary>
        /// オブジェクトの複製
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="src"></param>
        /// <returns></returns>
        public static T DeepClone<T>(this T src) where T : class {
            using (var memoryStream = new System.IO.MemoryStream()) {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, src);
                memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
                return (T) binaryFormatter.Deserialize(memoryStream);
            }
        }

        /// <summary>
        /// 何でもメソッドチェーン
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="call"></param>
        /// <returns></returns>
        public static T Chain<T>(this T source, Action<T> call) {
            if (source == null)
                return source;
            call(source);
            return source;
        }

        /// <summary>
        /// 何でもメソッドチェーン
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="call"></param>
        /// <returns></returns>
        public static T2 Chain<T1, T2>(this T1 source, Func<T1, T2> call) {
            if (source == null)
                return default(T2);
            return call(source);
        }

        /// <summary>
        /// Contains() の逆
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public static bool Any<T>(this T target, IEnumerable<T> items) {
            foreach (T i in items) {
                if (target.Equals(i))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Contains() の逆
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public static bool Any<T>(this T target, params T[] items) {
            foreach (T i in items) {
                if (target.Equals(i))
                    return true;
            }
            return false;
        }

        #endregion

        /**-------------------------
         * 文字列系
         * -------------------------
         */
        #region around-string
        public enum PadType
        {
            Char,
            Number
        }

        /// <summary>
        /// 文字列を指定数で左詰めします。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <param name="byteCount"></param>
        /// <returns></returns>
        public static string PadLeftInBytes(this string value, PadType type, int byteCount) {
            Encoding enc = Encoding.GetEncoding("Shift_JIS");
            if (byteCount < enc.GetByteCount(value))
                value = value.Substring(0, byteCount);
            switch (type) {
                case PadType.Char:
                    return value.PadRight(byteCount - (enc.GetByteCount(value) - value.Length));
                case PadType.Number:
                    return value.PadLeft(byteCount, '0');
                default:
                    return value.PadLeft(byteCount);
            }
        }

        /// <summary>
        /// 文字列を指定数で右詰めします。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <param name="byteCount"></param>
        /// <returns></returns>
        public static string PadRightInBytes(this string value, PadType type, int byteCount) {
            Encoding enc = Encoding.GetEncoding("Shift_JIS");
            if (byteCount < enc.GetByteCount(value))
                value = value.Substring(0, byteCount);
            switch (type) {
                case PadType.Char:
                    return value.PadLeft(byteCount - (enc.GetByteCount(value) - value.Length));
                case PadType.Number:
                    return value.PadRight(byteCount, '0');
                default:
                    return value.PadRight(byteCount);
            }
        }

        /// <summary>
        /// 文字列を空白文字で部分文字列に分割します。
        /// </summary>
        /// <param name="source"></param>
        /// <param name="isArgs">コマンドライン引数として分割します。""の中に空白があっても無視します</param>
        /// <returns></returns>
        public static string[] Split(this string source, bool isArgs, char separator = ' ', char blocker = '"') {
            List<string> tmpList = new List<string>();
            string tmpStr = "";
            int sw = 0;
            for (int i = 0; i < source.Length; i++) {
                char s = char.Parse(source.Substring(i, 1));
                switch (sw) {
                    case 0:
                        if (s == separator) {
                            tmpList.Add(tmpStr);
                            tmpStr = "";
                        } else if (s == blocker) {
                            if (isArgs) {
                                sw = 1;
                                tmpList.Add(tmpStr);
                                tmpStr = "";
                            } else
                                tmpStr += s;
                        } else
                            tmpStr += s;
                        break;
                    case 1:
                        if (s == blocker) {
                            sw = 0;
                            tmpList.Add(tmpStr);
                            tmpStr = "";
                        } else
                            tmpStr += s;
                        break;
                }
            }
            tmpList.Add(tmpStr);
            var cleanList = tmpList.Where(s => s != "").ToArray();
            return cleanList;
        }

        #endregion

        /**-------------------------
         * メソッドチェーン オーバーライド
         * -------------------------
         */
        #region MethodChain-Override

        /// <summary>
        /// コレクションのメンバーを連結します。各メンバーの間には、指定した区切り記号が挿入されます。
        /// </summary>
        /// <typeparam name="T">source のメンバーの型。</typeparam>
        /// <param name="source">連結するオブジェクトを格納しているコレクション。</param>
        /// <param name="separator">区切り文字として使用する文字列。</param>
        /// <returns>values のメンバーからなる、separator 文字列で区切られた文字列。</returns>
        public static string Join<T>(this IEnumerable<T> source, string separator) => string.Join(separator, source);

        public static string[] Split(this string source, string pattern, RegexOptions option) => Regex.Split(source, pattern, option);

        public static string Replace(this string source, string pattern, string replacement) => Regex.Replace(source, pattern, replacement);

        public static int IndexOf<T>(this T[] source, T value) => Array.IndexOf(source, value);

        /// <summary>
        /// 文字列をそれと等価なintに変換します。
        /// </summary>
        /// <param name="source"></param>
        /// <returns>変換結果のint</returns>
        public static int ParseInt(this string source) {
            if (int.TryParse(source, out int a))
                return a;
            return 0;
        }

        public static string ParseString(this IEnumerable<char> source) {
            return new string(source.ToArray());
        }

        /// <summary>
        /// 文字列をそれと等価なdoubleに変換します。
        /// </summary>
        /// <param name="source"></param>
        /// <returns>変換結果のdouble</returns>
        public static double ParseDouble(this string source) {
            if (double.TryParse(source, out double a))
                return a;
            return 0;
        }

        /// <summary>
        /// Enum.GetValues(Typr enumType) のオーバーライド
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> GetValues<T>() where T : struct {
            return (T[]) Enum.GetValues(typeof(T));
        }

        //public static NAry ToNary(this double value, byte ary) => new NAry(value, ary);

        //public static NAry ToNary(this string value, byte ary) => new NAry(value, ary);

        #endregion

        /**-------------------------
         * コレクション関係
         * -------------------------
         */
        #region around-IEnumerable

        /// <summary>
        /// 1次元列挙型を指定数ずつの2次元列挙型にします。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="chunkSize"></param>
        /// <returns></returns>
        public static IEnumerable<IList<T>> Chunk<T>(this IEnumerable<T> source, int chunkSize) {
            var result = new List<T>(chunkSize);
            foreach (var item in source) {
                result.Add(item);
                if (result.Count < chunkSize)
                    continue;
                yield return result;
                result = new List<T>(chunkSize);
            }
            if (Enumerable.Any(result))
                yield return result;
        }

        /// <summary>
        /// シーケンスに指定アイテムを追加します。同じものがあった場合は追加しません。
        /// </summary>
        /// <typeparam name="T">source のメンバーの型。</typeparam>
        /// <param name="source">オブジェクトを格納しているコレクション。</param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static IList<T> AddUnique<T>(this IList<T> source, T item) {
            if (!source.Contains<T>(item)) {
                source.Add(item);
            }
            return source;
        }

        /// <summary>
        /// シーケンスに指定アイテムを追加します。追加したアイテムを戻り値としています．
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static T AddGet<T>(this IList<T> source, T item) {
            source.Add(item);
            return item;
        }

        /// <summary>
        /// 配列にアイテムを追加します
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static T[] Add<T>(this T[] source, T item) {
            source = source.Concat(new T[] { item }).ToArray();
            return source;
        }

        /// <summary>
        /// 配列にアイテムを追加します。追加したアイテムを戻り値としています．
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static T AddGet<T>(this T[] source, T item) {
            source = source.Concat(new T[] { item }).ToArray();
            return item;
        }

        /// <summary>
        /// シーケンスに指定アイテムを追加します。同じキーがあった場合置き換えます。
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="source"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Dictionary<TKey, TValue> AddOrReplace<TKey, TValue>(this Dictionary<TKey, TValue> source, TKey key, TValue value) {
            source[key] = value;
            return source;
        }

        /// <summary>
        /// シーケンスに指定アイテムを追加します。追加したアイテムを戻り値としています．
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static TValue AddGet<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, TValue value) {
            source[key] = value;
            return value;
        }

        /// <summary>
        /// シーケンスの指定されたキーを返します。シーケンスに要素が含まれていない場合は既定値を返します。
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="source"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TKey GetKey<TKey, TValue>(this Dictionary<TKey, TValue> source, TValue value) {
            if (source.ContainsValue(value)) {
                var key = source.First(x => x.Value.Equals(value)).Key;
                return key;
            } else
                return default(TKey);
        }

        /// <summary>
        /// シーケンスの指定された要素を返します。シーケンスに要素が含まれていない場合は既定値を返します。
        /// </summary>
        /// <typeparam name="TKey">dictionary のKeyの型。</typeparam>
        /// <typeparam name="TValue">dictionary のValueの型。</typeparam>
        /// <param name="dictionary"></param>
        /// <param name="key">指定する要素のKey</param>
        /// <returns></returns>
        public static TValue ValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key) {
            dictionary.TryGetValue(key, out TValue result);
            return result;
        }

        /// <summary>
        /// コレクションの指定した要素を削除します
        /// </summary>
        /// <typeparam name="T">source のメンバーの型。</typeparam>
        /// <param name="source">オブジェクトを格納しているコレクション。</param>
        /// <param name="index">削除するオブジェクトのインデックス</param>
        /// <returns></returns>
        public static IEnumerable<T> Remove<T>(this IEnumerable<T> source, int index) {
            return source.Where((s, i) => i != index);
        }

        /// <summary>
        /// コレクションの指定した複数の要素を削除します
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="indexes"></param>
        /// <returns></returns>
        public static IEnumerable<T> Remove<T>(this IEnumerable<T> source, IEnumerable<int> indexes) {
            return source.Where((s, i) => !i.Any(indexes));
        }

        /// <summary>
        /// 指定された数のシーケンス内の要素をバイパスし、残りの要素を返します。
        /// </summary>
        /// <typeparam name="T">source のメンバーの型。</typeparam>
        /// <param name="source">System.Collections.Generic.IEnumerable`1 要素を返します．</param>
        /// <param name="skipCount">最初にスキップする要素の数．</param>
        /// <param name="valueCount">取得する要素の数．</param>
        /// <returns></returns>
        public static IEnumerable<T> Skip<T>(this IEnumerable<T> source, int skipCount, int valueCount) {
            return source.Skip(skipCount).Take(valueCount);
        }

        /// <summary>
        /// どうにかして．
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="func"></param>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> func) {
            foreach (var t in source)
                func(t);
        }

        /// <summary>
        /// sequence内のオブジェクト参照を取得
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static T Reflection<T>(this T value, IEnumerable<T> sequence) {
            int i = 0;
            foreach (var item in sequence) {
                if ((object) value == (object) item) {
                    return sequence.ElementAt(i);
                }
            }
            return default(T);
        }


        /// <summary>
        /// 最後のインデックス値を返します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static int LastIndex<T>(this IEnumerable<T> source) => source.Count() - 1;

        public static int LastIndex<T>(this T[] source) => source.Length - 1;

        #endregion

        /**-------------------------
         * 多次元配列関係
         * -------------------------
         */
        #region around-HighDimensionArray

        /// <summary>
        /// 列を取得します
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static IEnumerable<T> Column<T>(this T[,] source, int index) {
            int FirstDim = source.GetLength(0);
            int SecondDim = source.GetLength(1);
            if (index < SecondDim)
                for (int i = 0; i < FirstDim; i++)
                    yield return source[i, index];
        }

        /// <summary>
        /// 列を取得します
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static IEnumerable<T> Column<T>(this IEnumerable<T[]> source, int index) {
            if (source.Count() >= 1 && source.ElementAt(0).Length > index)
                foreach (var item in source)
                    yield return item[index];
        }

        /// <summary>
        /// 列を取得します
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static IEnumerable<T> Column<T>(this IEnumerable<IEnumerable<T>> source, int index) {
            if (source.Count() >= 1 && source.ElementAt(0).Count() > index)
                foreach (var item in source)
                    yield return item.ElementAt(index);
        }

        /// <summary>
        /// 行を取得します
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static IEnumerable<T> Raw<T>(this T[,] source, int index) {
            int FirstDim = source.GetLength(0);
            int SecondDim = source.GetLength(1);
            if (index < FirstDim)
                for (int i = 0; i < SecondDim; i++)
                    yield return source[index, i];
        }
        /// <summary>
        /// 2次元ジャグ配列に変換します
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T[][] ToJagged<T>(this IEnumerable<IEnumerable<T>> source) {
            return source.Select(s => s.ToArray()).ToArray();
        }

        /// <summary>
        /// 2次元ジャグ配列に変換します
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T[][] ToJagged<T>(this T[,] source) {
            var result = new T[source.GetLength(0)][];
            int SecondDim = source.GetLength(1);
            for (int i = 0; i < result.Length; i++) {
                result[i] = new T[SecondDim];
                for (int j = 0; j < SecondDim; j++)
                    result[i][j] = source[i, j];
            }
            return result;
        }

        /// <summary>
        /// 2次元ジャグ列挙に変換します
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> ToJaggedList<T>(this T[,] source) {
            int FirstDim = source.GetLength(0);
            int SecondDim = source.GetLength(1);
            for (int i = 0; i < FirstDim; i++) {
                yield return source.ToEnumerable().Skip((i * SecondDim), SecondDim);
            }
        }

        /// <summary>
        /// 2次元配列に変換します
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T[,] To2D<T>(this IEnumerable<IEnumerable<T>> source) {
            return source.ToJagged().To2D();
        }

        /// <summary>
        /// 2次元配列に変換します
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T[,] To2D<T>(this T[][] source) {
            int FirstDim = source.Length;
            //if (FirstDim <= 0)
            //    return null;
            int SecondDim = source.Select(s => s.Length).Max();
            var result = new T[FirstDim, SecondDim];
            for (long i = 0; i < FirstDim; i++)
                for (long j = 0; j < SecondDim; j++)
                    if (source[i].Length > j)
                        result[i, j] = source[i][j];
            return result;
        }

        /// <summary>
        /// 2次元配列を列挙します
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<T> ToEnumerable<T>(this T[,] source) {
            foreach (var t in source)
                yield return t;
        }

        /// <summary>
        /// 2次元配列の要素を，どうにかします．
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        public static T[,] ForEach<T>(this T[,] source, Action<T> action) {
            long FirstDim = source.GetLongLength(0);
            long SecondDim = source.GetLongLength(1);
            for (long i = 0; i < FirstDim; i++)
                for (long j = 0; j < SecondDim; j++)
                    action(source[i, j]);
            return source;
        }

        /// <summary>
        /// 転置行列
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="interpolation"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Transposition<T>(this IEnumerable<IList<T>> source, T interpolation = default(T)) {
            return Enumerable.Range(0, source.Max(c => c.Count)).Select(i => source.Select(c => i < c.Count ? c[i] : interpolation));
        }

        /// <summary>
        /// 非効率かもしれない転置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="interpolation"></param>
        /// <param name="optim"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Transposition2<T>(this IEnumerable<IEnumerable<T>> source, T interpolation = default(T), bool optim = false) {
            int FirstDim = source.Max(m => m.Count());
            int SecondDim = source.Count();
            var t = source.ToJagged();
            for (int i = 0; i < FirstDim; i++) {
                List<T> tmp = new List<T>();
                for (int j = 0; j < SecondDim; j++) {
                    try {
                        tmp.Add(t[j][i]);
                    } catch {
                        tmp.Add(interpolation);
                    }
                }
                if (optim) {
                    int effect = tmp.FindLastIndex(s => !s.Equals(interpolation));
                    yield return tmp.Take(effect + 1);
                } else
                    yield return tmp;
            }
        }

        public static IEnumerable<IEnumerable<T>> Transposition<T>(this T[,] source) {
            return Enumerable.Range(0, source.GetLength(1)).Select(i => source.ToJaggedList().Select(c => c.ElementAt(i)));
        }

        public static T[,] TranspositionFast<T>(this T[,] source) {
            int FirstDim = source.GetLength(0);
            int SecondDim = source.GetLength(1);
            var tmp = new T[SecondDim, FirstDim];
            for (int i = 0; i < FirstDim; i++) {
                for (int j = 0; j < SecondDim; j++) {
                    tmp[j, i] = source[i, j];
                }
            }
            return tmp;
        }


        #endregion

        /**-------------------------
         * 数値関係
         * -------------------------
         */
        #region Numbers


        public static int Round(this double value) => (int) (value + 0.5);

        public static int RoundDown(this double value) => (int) (value);

        public static int RoundUp(this double value) => (int) (value + 0.9);

        /// <summary>
        /// 値が指定範囲内にあるか判断します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static bool InBetween<T>(this T value, T min, T max) where T : IComparable<T> {
            if (min.CompareTo(max) <= -1)
                Swap(ref min, ref max);
            return value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0;
        }

        public static bool Range<T>(this T value, T left, T right) where T : IComparable<T> {
            return (value.CompareTo(left) >= 0 && value.CompareTo(right) <= 0);
        }

        public static T RangeForce<T>(this T value, T left, T right) where T : IComparable<T> {
            if (value.CompareTo(right) > 0)
                return right;
            else if (value.CompareTo(left) < 0)
                return left;
            else
                return value;
        }

        //public static double RangeMove(this double value, double left, double right) {
        //    var range = right - left;
        //    if (range == 0)
        //        return left;
        //    while (value < left)
        //        value += range;
        //    while (value > right)
        //        value -= range;
        //    return value;
        //}

        public static T RangeMove<T>(this T value, T left, T right) {
            try {
                if ((dynamic) right < (dynamic) left)
                    Swap(ref left, ref right);
                dynamic range = (dynamic) right - (dynamic) left;
                if (range == 0)
                    return left;
                while ((dynamic) value < (dynamic) left)
                    value += range;
                while ((dynamic) value > (dynamic) right)
                    value -= range;
                return value;
            } catch {
                return value;
            }
        }

        /// <summary>
        /// 割り算と余りを返します
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Tuple<long, long> Div(long left, long right) {
            if (right == 0)
                throw new System.DivideByZeroException();
            return Tuple.Create(left / right, left % right);
        }

        /// <summary>
        /// 割り算と余りを返します
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Tuple<double, double> Div(double left, double right) {
            if (right == 0)
                throw new System.DivideByZeroException();
            return Tuple.Create(left / right, left % right);
        }

        /// <summary>
        /// 角度からラジアンを求めます
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static double ToRadian(this double angle) {
            return (double) (angle * Math.PI / 180);
        }

        /// <summary>
        /// ラジアンから角度を求めます
        /// </summary>
        /// <param name="radian"></param>
        /// <returns></returns>
        public static double ToAngle(double radian) {
            return (double) (radian * 180 / Math.PI);
        }

        /// <summary>
        /// 実数を分数にします
        /// </summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool ToFraction(this double value, out (long Numerator, long Denominator) result) {
            int di = 0;
            string priceString = value.ToString().TrimEnd('0');
            int index = priceString.IndexOf('.');
            if (index != -1)
                di = priceString.Substring(index + 1).Length;
            result.Denominator = (long) Math.Pow(10, di);
            result.Numerator = (long) (value * result.Denominator);
            Console.WriteLine(result.Denominator + " , " + result.Numerator);
            var t = result.Denominator;
            result = Reduction(result.Numerator, result.Denominator);
            if (t == result.Denominator)
                return false;
            return true;
        }

        /// <summary>
        /// 約分
        /// </summary>
        /// <param name="numerator"></param>
        /// <param name="denominator"></param>
        /// <returns></returns>
        public static (long, long) Reduction(long numerator, long denominator) {

            foreach (var p in PrimeNumber(s => s <= Math.Max(numerator, denominator)).Reverse()) {
                if (numerator % p == 0 && denominator % p == 0) {
                    numerator /= p;
                    denominator /= p;
                }
            }
            return (numerator, denominator);
        }

        /// <summary>
        /// 最大公約数
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static long Gcd(long a, long b) {
            if (a < b)
                return Gcd(b, a);
            while (b != 0) {
                var remainder = a % b;
                a = b;
                b = remainder;
            }
            return a;
        }

        /// <summary>
        /// 素数を生成します
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public static IEnumerable<int> PrimeNumber(Func<int, bool> conditions) {
            yield return 2;
            for (int i = 3; conditions(i); i += 2) {
                double sqrtNum = Math.Sqrt(i);
                bool flg = true;
                for (int j = 3; j <= sqrtNum; j += 2) {
                    if (i % j == 0) {
                        flg = false;
                        break;
                    }
                }
                if (flg)
                    yield return i;
            }
        }

        /// <summary>
        /// 2点間の距離
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        public static double Distance(double x1, double y1, double x2, double y2) {
            double a = Math.Max(x1, x2) - Math.Min(x1, x2);
            double b = Math.Max(y1, y2) - Math.Min(y1, y2);
            double c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            return c;
        }

        /// <summary>
        /// 整数をN進数の文字列に変換します
        /// </summary>
        /// <param name="value"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        //public static string IntToNary(this int value, int n) {
        //    List<int> ex = new List<int>();
        //    while (n < value) {
        //        ex.Add(value % n);
        //        value /= n;
        //    }
        //    ex.Add(value % n);
        //    ex.Reverse();
        //    var NAryNumber = ex.Select(s => NAry.dic[s]);
        //    return string.Join("", NAryNumber);
        //}

        /// <summary>
        /// N進数の文字列を整数に変換します
        /// </summary>
        /// <param name="value" ></param>
        /// <param name="n"></param>
        /// <returns></returns>
        //public static int NaryToInt(this string value, int n) {
        //    List<int> ex = new List<int>();
        //    var tmp = value.Select(s => NAry.dic.IndexOf(s.ToString())).Reverse();
        //    int k = 1;
        //    for (int i = 0; i < tmp.Count(); i++) {
        //        ex.Add(tmp.ElementAt(i) * k);
        //        k *= n;
        //    }
        //    return ex.Sum();
        //}


        #endregion

        /**-------------------------
         * 値関係
         * -------------------------
         */
        #region Values

        /// <summary>
        /// オブジェクトの入れ替えを行います
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void Swap<T>(ref T a, ref T b) {
            T c = a;
            a = b;
            b = c;
        }

        /// <summary>
        /// Toggleゲート ( <- ? )
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool Toggle(ref this bool value) {
            value = !value;
            return value;
        }

        /// <summary>
        /// Notゲート ( <- ? )
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool Not(this bool value) => !value;

        //public static bool And(params bool[] values) {
        //    if (values.Length == 1)
        //        return values[0];
        //}

        //public static bool Or(params bool[] values) => values.Any(s => s);

        //public static bool Xor(params bool[] values) {

        //}
        #endregion

        /**-------------------------
         * リフレクション関係
         * -------------------------
         */
        #region Reflection

        /// <summary>
        /// クラスオブジェクトにおいて、文字列と一致するフィールドの値を取得します。
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="source"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static TValue GetFieldValue<TValue>(this object source, string name) {
            try {
                var property = source.GetType().GetProperty(name);
                return (TValue) property.GetValue(source);
            } catch {
                return default(TValue);
            }
        }

        /// <summary>
        /// フィールドの値一覧を返します
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <returns></returns>
        public static IDictionary<string, string> GetValues<T>(this T target) {
            Dictionary<string, string> field = new Dictionary<string, string>();
            foreach (var s in typeof(T).GetFields())
                //field[s.Name] = Convert.ChangeType(s.GetValue(target), s.FieldType).ToString();
                field[s.Name] = s.GetValue(target).ToString();
            return field;
        }

        /// <summary>
        /// 指定Enumration内の文字列と一致する名前のオブジェクトを返します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this string source) where T : struct {
            if (Enum.IsDefined(typeof(T), source))
                return (T) Enum.Parse(typeof(T), source);
            return default(T);
        }

        /// <summary>
        /// 指定Enumration内で一致する値のオブジェクトを返します。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this int value) where T : struct {
            if (Enum.IsDefined(typeof(T), value))
                return (T) Enum.ToObject(typeof(T), value);
            return default(T);
        }
        #endregion

        /**-------------------------
         * 特殊用途
         * -------------------------
         */
        #region Special-Purpose

        /// <summary>
        /// 順列
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static IEnumerable<T[]> Permutation<T>(this IEnumerable<T> source, int n = -1) {
            int m = source.Count();
            if (n > 0)
                n -= 1;
            if (m == 1 || n == 0) {
                yield return new T[] { source.First() };
                yield break;
            }
            foreach (var item in source) {
                var leftside = new T[] { item };
                var unused = source.Except(leftside);
                foreach (var rightside in Permutation(unused)) {
                    yield return leftside.Concat(rightside).ToArray();
                }
            }
        }

        /// <summary>
        /// 組み合わせ
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Combination<T>(this IEnumerable<T> items, int r, bool overlap) {
            if (r == 1) {
                foreach (var item in items)
                    yield return new T[] { item };
                yield break;
            }
            foreach (var item in items) {
                var leftside = new T[] { item };

                var unused = overlap ? items : items.SkipWhile(e => !e.Equals(item)).Skip(1).ToList();

                foreach (var rightside in Combination(unused, r - 1, overlap)) {
                    yield return leftside.Concat(rightside).ToArray();
                }
            }
        }

        /// <summary>
        /// 組み合わせ(Linq)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="src"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        static IEnumerable<IEnumerable<T>> Combinations<T>(this IList<T> src, int n) => Enumerable.Range(0, n - 1).Aggregate(Enumerable.Range(0, src.Count() - n + 1).Select(num => new List<int>() { num }), (list, _) => list.SelectMany(c => Enumerable.Range(c.Max() + 1, src.Count() - c.Max() - 1).Select(num => new List<int>(c) { num }))).Select(c => c.Select(num => src[num]));

        /// <summary>
        /// Enum値を "名前(指定文字数) + 番号" という文字列に変換します (特殊用途) 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string ToString<T>(this T value, int count) where T : struct {
            Type type = typeof(T);
            if (type.IsEnum)
                return null;
            var values = ((T[]) Enum.GetValues(type)).Select(s => Enum.GetName(type, s)).ToList();
            string name = Enum.GetName(type, value);
            int num = values.IndexOf(name);
            if (name.Length > count)
                return name.Take(count).ToString() + num;
            else
                return name.ToString() + num;
        }


        //public static System.Reflection.MethodInfo[] MethodCount(Type type) {
        //    var items = type.GetMethods();
        //    return items;
        //}


        #endregion

    }

    public static class IO
    {
        public static void FileWriteText(this string source, string fileName, Encoding encode) {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(fileName, false, encode)) {
                sw.Write(source);
                sw.Close();
            }
        }

        /// <summary>
        /// ファイル書き込み
        /// </summary>
        /// <param name="filename">ファイル名</param>
        /// <param name="contents">内容（1行ごと配列）</param>
        public static void WriteFile(string filename, IEnumerable<string> contents) {
            try {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filename, true)) {
                    foreach (var line in contents)
                        sw.WriteLine(line);
                }
            } catch {
                Console.WriteLine("書き込みに失敗しました");
            }
        }

        /// <summary>
        /// ファイル読み込み
        /// </summary>
        /// <param name="filename">ファイル名</param>
        /// <returns>ファイルの内容</returns>
        public static string ReadFile(string filename) {
            try {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(filename)) {
                    return sr.ReadToEndAsync().GetAwaiter().GetResult();
                }
            } catch {
                Console.WriteLine("読み込みに失敗しました");
                return null;
            }
        }

        /// <summary>
        /// CSVを読み込みます
        /// </summary>
        /// <param name="fileName">ファイルネーム</param>
        /// <param name="titleRaw">タイトル行があるかどうか</param>
        /// <returns></returns>
        public static Dictionary<string, List<dynamic>> ReadCSV(string fileName, bool titleRaw) {
            Dictionary<string, List<dynamic>> pairs = new Dictionary<string, List<dynamic>>();
            try {
                string[][] lines;
                int begin;

                using (System.IO.StreamReader sr = new System.IO.StreamReader(fileName))
                    lines = sr.ReadToEnd().Replace("\r\n", "\n").Replace("\r", "\n").Split('\n').Select(s => s.Split(true, ',', '\"')).ToArray();

                if (titleRaw) {
                    begin = 1;
                    lines[0].ForEach(s => pairs.Add(s, new List<dynamic>()));
                } else {
                    begin = 0;
                    Enumerable.Range(0, lines[0].Length).ForEach(s => pairs.Add(s.ToString(), new List<dynamic>()));
                }

                for (int i = begin; i < lines.Length; i++)
                    for (int j = 0; j < lines[i].Length; j++)
                        pairs.ElementAt(j).Value.Add(lines[i][j]);
            } catch { }
            return pairs;
        }

    }

    public struct Decimal32
    {
        private class Digit
        {
            public int Num;
            private Decimal32 P;
            //public Digit Next;
            //public Digit Prev;

            public Digit(Decimal32 p, int num) {
                P = p;
                ArgmentCheck(num);
                Num = num;
            }

            public Digit(Decimal32 p, string value) {
                P = p;
                ArgmentCheck(value);
                Num = value.ParseInt();
            }

            public void Add(int value) {
                Num += value;
                if (Num >= 10) {
                    P.Next(this).Add(Num / 10);
                    Num %= 10;
                }
            }

            public void Add(Digit value) {
                Add(value.Num);
            }

            public void Sub(int value) {
                int tmp = Num;
                for (int i = 0; tmp >= value; i++)
                    tmp += 10;
                tmp /= 10;
                if (Num - value <= -1) {
                    P.Next(this).Sub(1);
                    Num = (Num + 10) - value;
                }
            }

            public void Sub(Digit value) {
                Sub(value.Num);
            }


            private void ArgmentCheck(int value) {
                if (Num >= 10)
                    throw new System.ArgumentException("数値が無効です");
            }

            private void ArgmentCheck(string value) {
                if (value.Length >= 2)
                    throw new System.ArgumentException("値が無効です");
            }

        }

        private List<Digit> Value;
        private long DecPoint;

        public Decimal32(string value) {
            Value = new List<Digit>();
            DecPoint = 0;

            foreach (var s in value.Reverse()) {
                if (int.TryParse(s.ToString(), out int result)) {
                    var tmp = new Digit(this, result);
                    Value.Add(tmp);
                } else if (s == '.') {
                    DecPoint = value.Length - value.IndexOf('.');
                }
            }
        }

        public Decimal32(decimal value) {
            Value = new List<Digit>();
            DecPoint = 0;
            Value.Add(new Digit(this, 0));
            while (value - (int) value != 0) {
                value *= 10;
            }
            Value[0].Add((int) value);

        }

        private Digit GetOrMakeDigit(int n) {
            if (n >= Value.Count) {
                var tmp = new Digit(this, 0);
                Value.Add(tmp);
                return tmp;
            } else
                return Value[n];
        }

        private Digit Next(Digit d) {
            int tmp = Value.IndexOf(d) + 1;
            return GetOrMakeDigit(tmp);
        }

        private Digit Prev(Digit d) {
            int tmp = Value.IndexOf(d) - 1;
            if (tmp > -1)
                return Value[tmp];
            else
                return null;
        }

        private void Nomalization() {
            for (int i = Value.Count - 1; i >= 0; i--) {
                if (Value[i].Num != 0)
                    break;
                else
                    Value.RemoveAt(i);
            }
        }

        public override string ToString() {
            Nomalization();
            return Value.Select(s => s.Num).Reverse().Join("");
        }

        public static Decimal32 operator +(Decimal32 left, Decimal32 right) {
            var tmp = new Decimal32(0);
            for (int i = 0; i < Math.Max(left.Value.Count, right.Value.Count); i++) {
                tmp.GetOrMakeDigit(i).Add(left.GetOrMakeDigit(i));
                tmp.GetOrMakeDigit(i).Add(right.GetOrMakeDigit(i));
            }
            return tmp;
        }

        public static Decimal32 operator +(Decimal32 left, int right) {
            var tmp = new Decimal32(0);
            for (int i = 0; i < left.Value.Count; i++) {
                tmp.GetOrMakeDigit(i).Add(left.Value[i]);
            }
            tmp.Value[0].Add(right);
            return tmp;
        }
    }

}
