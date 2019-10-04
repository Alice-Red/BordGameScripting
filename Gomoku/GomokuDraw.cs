using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib.API;
using GameLib.Core.Base;
using GameLib.Core.Util;
using RUtil;

namespace Gomoku
{
    public class GomokuDraw : IDrawer
    {
        public void DrawConsole(GridField field) {
            var num = new string[] {
                "　一", "　二", "　三", "　四", "　五", "　六", "　七", "　八", "　九", "　十", "十一", "十二", "十三", "十四", "十五", "十六",
            };

            Console.WriteLine($"    |{Enumerable.Range(0, 16).Select(s => (s + "").PadRightInBytes(Utility.PadType.Char, 3)).Join("")}");
            for (int i = 0; i < num.Length; i++) {
                Console.WriteLine($"{num[i]}| {field.Field.Raw(i).Select(s => s.ToPlayerColor2P() == PlayerColor2P.Black ? "●" : s.ToPlayerColor2P() == PlayerColor2P.White ? "○" : "＋").Join(" ")}");
            }


        }

        public void DrawPanel(GridField field) {
            throw new NotImplementedException();
        }
    }
}
