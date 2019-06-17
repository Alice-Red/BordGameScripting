using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BordGameCore.GameCore.Base;
using RUtil;


namespace BordGameCore.GameCore.Util
{
    public static class Converter
    {

        /// <summary>
        /// 反対の色を返します
        /// </summary>
        /// <param name="pc2p"></param>
        /// <returns></returns>
        public static PlayerColor2P Reverse(this PlayerColor2P pc2p) {
            return (((int) pc2p) * -1).ToPlayerColor2P();
        }

        /// <summary>
        /// PlayerColor2Pとintで相互変換します
        /// </summary>
        /// <param name="color">色</param>
        /// <returns></returns>
        public static int ToInt(this PlayerColor2P color) {
            return (int) color;
        }

        /// <summary>
        /// PlayerColor2Pとintで相互変換します
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static PlayerColor2P ToPlayerColor2P(this int color) {
            return color.ToEnum<PlayerColor2P>();
        }
    }
}
