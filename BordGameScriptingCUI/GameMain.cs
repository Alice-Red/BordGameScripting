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
            LibraryLoader loader = new LibraryLoader(ProgramBGSCUI.LibraryPath);
            var tgame = loader.Games.Select(s => s.GetExportedTypes()).To2D().ToEnumerable().Where(s => s.IsSubclassOf(typeof(Game))).ToArray();
            Menu(tgame);

            Task.Factory.StartNew(() => {
                game.Run();
            });

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
