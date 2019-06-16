using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RUtil;

namespace BordGameCore.GameCore
{

    abstract class GridField
    {
        private ushort width = 0;
        private ushort height = 0;

        /// <summary>
        /// 盤面のサイズ
        /// </summary>
        internal int Width {
            get { return width; }
            set { if (value > 0) { width = (ushort) value; height = (ushort) value; } }
        }

        internal int Height {
            get { return height; }
            set { if (value > 0) { height = (ushort) value; } }
        }

        /// <summary>
        /// 盤面全部
        /// </summary>
        internal SafeArray<int> field;
        public int[,] Field {
            get {
                if (field.Length == 0) {
                    field = new SafeArray<int>(Width);
                }
                return field.Array;
            }
        }

        public GridField() {

        }

        /// <summary>
        /// 指定座標に置いてあるもの
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Get(int x, int y) {
            return field[y, x];
        }

        /// <summary>
        /// 指定座標に置いてあるもの
        /// </summary>
        /// <param name="rc"></param>
        /// <returns></returns>
        public int Get(RawColumn rc) {
            return field[rc.Raw, rc.Column];
        }

        /// <summary>
        /// 指定要素をカウントします
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public int Count(int color) {
            int c = 0;
            foreach (var item in field.Array) {
                if (item == color)
                    c++;
            }
            return c;
        }

        /// <summary>
        /// 指定要素をカウントします
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public int Count(PlayerColor2P color) {
            return Count((int) color);
        }

        /// <summary>
        /// Console.Debug
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="s"></param>
        public void Log<T>(T s) {
            Console.WriteLine(s);
        }

        /// <summary>
        /// 指定座標に置けるかどうか
        /// </summary>
        /// <returns></returns>
        public abstract bool Canput(int r, int c, int t);

        public bool Canput(RawColumn rc, int t) {
            return Canput(rc.Raw, rc.Column, t);
        }

        /// <summary>
        /// ゲームの終了を検知します．
        /// </summary>
        /// <returns>0:試合中，1:1P，-1:2P，2:引き分け，-2:その他終了</returns>
        internal abstract int CheckWinner();

    }
}