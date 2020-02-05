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

        GameLib.Core.Game game;
        List<GameInputter> pls = new List<GameInputter>();

        public GameMain() {
            LibraryLoader loader = new LibraryLoader(ProgramBGSCUI.LibraryPath);
            var tgame = loader.Games.Select(s => s.GetExportedTypes()).To2D().ToEnumerable().Where(s => s.GetBaseTypes().Contains(typeof(Game))).ToArray();
            //var tinput = loader.Inputters.Select(s => s.GetExportedTypes()).To2D().ToEnumerable().Where(
            //    s => s.GetBaseTypes().Contains(typeof(GameInputter))
            //    //s => s.IsSubclassOf(typeof(GameInputter))
            //    ).ToArray();
            var tinput = loader.Inputters.Select(s => s.GetExportedTypes()).To2D().ToEnumerable().Where(s => s.GetBaseTypes().Contains(typeof(GameInputter))).ToArray();
            Console.Write("Loop count >");
            int loopcount = int.Parse(Console.ReadLine());
            Menu(tgame, tinput);
            GameAutoLoop auto = new GameAutoLoop(game, pls.ToArray(), loopcount);
            Task.Factory.StartNew(() => {
                // game.Run();
                auto.Boot();
            });
        }

        public void Menu(Type[] tgames, Type[] tinputters) {
            var igames = tgames.Select(s => Activator.CreateInstance(s)).ToArray();
            for (int i = 0; i < igames.Length; i++) {
                Console.WriteLine($"{i}: {(igames[i] as Game).ToString()}");
            }
            Console.Write("Select Game >>");
            var n = Console.ReadLine().ParseInt();
            game = igames[n] as Game;
            var id = game.GetType().GetAttributeValue<GameAddonAttribute>().GameID;
            var iinputters = tinputters.Select(s => (GameInputter) Activator.CreateInstance(s)).Where(s => s.GetType().GetAttributeValue<GameAddonAttribute>().GameID == id).ToArray();

            for (int i = 0; i < iinputters.Length; i++) {
                Console.WriteLine($"{i}: {(iinputters[i] as GameInputter).ToString()}");
            }

            for (int i = 0; i < game.MaxPlayer; i++) {
                Console.Write($"Player{i + 1} >>");
                var n2 = Console.ReadLine().ParseInt();
                if (iinputters.Length <= n2)
                    break;
                pls.Add((GameInputter) Activator.CreateInstance(iinputters[n2].GetType()));
            }
            game.StorePlayer(pls.ToArray());

            //for (int i = 0; i < tinputters.Length; i++) {
            //    Console.WriteLine($"{i}: {(iinputters[i] as GameInputter).ToString()}");
            //}
            //Console.Write("2P>>");
            //var n3 = Console.ReadLine().ParseInt();

            //pl2 = (GameInputter) Activator.CreateInstance(iinputters[n3].GetType());

            //game.PL1 = pl1;
            //game.PL2 = pl2;


        }

    }
}
