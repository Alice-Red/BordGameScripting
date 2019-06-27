using GameLib.API;
using GameLib.Core.Util;
using RUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Core.Base
{

    public abstract class GridField : IField
    {
        private ushort width = 0;
        private ushort height = 0;

        /// <summary>
        /// 盤面のサイズ
        /// </summary>
        internal int Width {
            get { return width; }
        }

        internal int Height {
            get { return height; }
        }

        /// <summary>
        /// 盤面全部
        /// </summary>
        protected SafeArray<int> field;
        public int[,] Field {
            get {
                if (field.Length == 0)
                    field = new SafeArray<int>(Width);
                return field.Array;
            }
        }

        public GridField(int width) {
            this.width = (ushort) width;
            height = (ushort) width;
        }

        public GridField(int width, int height) {
            this.width = (ushort) width;
            this.height = (ushort) height;
        }

        public int this[int raw, int column] {
            get { return field[raw, column]; }
        }

        public int this[RawColumn rc] {
            get { return field[rc.Raw, rc.Column]; }
        }

        public int this[(int, int) value] {
            get { return field[value.Item1, value.Item2]; }
        }


        /// <summary>
        /// 指定座標に置いてあるもの
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Get(int raw, int column) {
            return field[raw, column];
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
        /// 指定座標に置いてあるもの
        /// </summary>
        /// <param name="rc"></param>
        /// <returns></returns>
        public int Get((int, int) value) {
            return field[value.Item1, value.Item2];
        }

        public bool InField(RawColumn rc) {
            return rc.Raw.InBetween(0, Height) && rc.Column.InBetween(0, width);
        }

        public bool InField(int raw, int column) {
            return raw.InBetween(0, Height) && column.InBetween(0, width);
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
        public abstract int CheckWinner();

    }
}