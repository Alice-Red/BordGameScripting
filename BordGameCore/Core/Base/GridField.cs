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

    public abstract class GridField : GameField
    {
        private ushort width = 0;
        private ushort height = 0;

        /// <summary>
        /// 盤面のサイズ
        /// </summary>
        public int Width {
            get { return width; }
        }

        public int Height {
            get { return height; }
        }

        /// <summary>
        /// 盤面全部
        /// </summary>
        protected int[,] field;
        public int[,] Field {
            get {
                if (field == null || field.Length == 0)
                    field = new int[height, width];
                return field.DeepClone();
            }
        }
        protected GridField() {

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
            return rc.Raw.InBetween(0, Height - 1) && rc.Column.InBetween(0, Width - 1);
        }

        public bool InField(int raw, int column) {
            return raw.InBetween(0, Height - 1) && column.InBetween(0, Width - 1);
        }

        /// <summary>
        /// 問答無用で上書きします
        /// </summary>
        public void OverWrite(RawColumn point, int value) {
            field[point.Raw, point.Column] = value;
        }

        /// <summary>
        /// 指定要素をカウントします
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public int Count(int color) {
            int c = 0;
            foreach (var item in field) {
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
        /// 何かがある座標一覧
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public IEnumerable<RawColumn> Exists() {
            for (int r = 0; r < Height; r++)
                for (int c = 0; c < Width; c++)
                    if (Get(r, c) != 0)
                        yield return RawColumn.New(r, c);
        }

        /// <summary>
        /// 指定座標から全8方向に見える座標を返します
        /// </summary>
        /// <param name="field"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        public RawColumn[][] ScanRayRC(RawColumn rc) {
            RawColumn[][] result = new RawColumn[8][];
            for (int i = 0; i < Relative.Position.Count(); i++) {
                List<RawColumn> t = new List<RawColumn>();
                result[i] = new RawColumn[0];
                int k = 1;
                while (true) {
                    var tmpRC = rc + (Relative.Position.ElementAt(i).Value * k);
                    if (InField(tmpRC)) {
                        t.Add(tmpRC);
                        k++;
                    } else {
                        result[i] = t.ToArray();
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 指定座標から全8方向に見える物を返します
        /// </summary>
        /// <param name="field"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        public PlayerColor2P[][] ScanRayColor(RawColumn rc) {
            PlayerColor2P[][] result = new PlayerColor2P[8][];
            for (int i = 0; i < Relative.Position.Count(); i++) {
                List<PlayerColor2P> t = new List<PlayerColor2P>();
                result[i] = new PlayerColor2P[0];
                int k = 1;
                while (true) {
                    var tmpRC = rc + (Relative.Position.ElementAt(i).Value * k);
                    if (InField(tmpRC)) {
                        t.Add(Get(tmpRC).ToPlayerColor2P());
                        k++;
                    } else {
                        result[i] = t.ToArray();
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 指定座標から指定した方向に指定した数移動した位置を返します。
        /// </summary>
        /// <param name="field"></param>
        /// <param name="rc"></param>
        /// <param name="rp"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public RawColumn RelativePosition(RawColumn rc, RelativeName rp, int c) {
            RawColumn t = rc + (Relative.Position[rp] * c);
            if (InField(t))
                return t;
            else
                return RelativePosition(rc, rp, c - 1);
        }

        /// <summary>
        /// ゲームの終了を検知します．
        /// </summary>
        /// <returns>0:試合中，1:1P，-1:2P，2:引き分け，-2:その他終了</returns>
        public abstract int CheckWinner();

    }
}