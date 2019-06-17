using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BordGameCore.GameCore.Util;
using RUtil;

namespace BordGameCore.GameCore.Base
{
    public static class FieldAnalyzer
    {

        /// <summary>
        /// 何かがある座標一覧
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public static IEnumerable<RawColumn> Exists(this GridField field) {
            for (int r = 0; r < field.Height; r++)
                for (int c = 0; c < field.Width; c++)
                    if (field.Get(r, c) != 0)
                        yield return RawColumn.New(r, c);
        }



        /// <summary>
        /// 指定座標から全8方向に見える座標を返します
        /// </summary>
        /// <param name="field"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        public static RawColumn[][] ScanRayRC(this GridField field, RawColumn rc) {
            RawColumn[][] result = new RawColumn[8][];
            for (int i = 0; i < Relative.Position.Count(); i++) {
                List<RawColumn> t = new List<RawColumn>();
                result[i] = new RawColumn[0];
                int k = 1;
                while (true) {
                    var tmpRC = rc + (Relative.Position.ElementAt(i).Value * k);
                    if (field.InField(tmpRC)) {
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
        public static PlayerColor2P[][] ScanRayColor(this GridField field, RawColumn rc) {
            PlayerColor2P[][] result = new PlayerColor2P[8][];
            for (int i = 0; i < Relative.Position.Count(); i++) {
                List<PlayerColor2P> t = new List<PlayerColor2P>();
                result[i] = new PlayerColor2P[0];
                int k = 1;
                while (true) {
                    var tmpRC = rc + (Relative.Position.ElementAt(i).Value * k);
                    if (field.InField(tmpRC)) {
                        t.Add(field.Get(tmpRC).ToPlayerColor2P());
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
        public static RawColumn RelativePosition(this GridField field, RawColumn rc, RelativeName rp, int c) {
            RawColumn t = rc + (Relative.Position[rp] * c);
            if (field.InField(t))
                return t;
            else
                return field.RelativePosition(rc, rp, c - 1);

        }

        /// <summary>
        /// 指定した位置が枠内に収まっているか判定
        /// </summary>
        /// <param name="field"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        public static bool InField(this GridField field, RawColumn rc) => field.InField(rc.Raw, rc.Column);

        /// <summary>
        /// 指定した位置が枠内に収まっているか判定
        /// </summary>
        /// <param name="field"></param>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool InField(this GridField field, int r, int c) => !(r < 0 || c < 0 || r >= field.Width || c >= field.Width);


    }
}
