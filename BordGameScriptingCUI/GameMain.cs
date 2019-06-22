using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib.API;
using GameLib.Core;
using GameLib.Core.Util;
using GameLib.Core.Base;
using RUtil;

namespace BordGameScriptingCUI
{
    class GameMain
    {

        GameLib.Core.BordGame game;



        public GameMain() {
            ConsoleDrawer drawer = new ConsoleDrawer();
            LibraryLoader loader = new LibraryLoader(@"");
            var tgame = loader.Games.Select(s => s.GetExportedTypes()).To2D().ToEnumerable().Where(s => s is Game).ToArray();
            Menu(tgame);


        }

        public void Menu(Type[] tgames) {
            var igames = tgames.Select(s => Activator.CreateInstance(s)).ToArray();
            for (int i = 0; i < igames.Length; i++) {
                Console.WriteLine($"{i}: {(igames[i] as BordGame).ToString()}");
            }
            Console.Write(">>");
            var n = Console.ReadLine().ParseInt();
            game = igames[n] as BordGame;

        }

    }
}
