using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib;
using GameLib.API;
using GameLib.Core;
using GameLib.Core.Base;
using GameLib.Core.Util;
using RUtil;

namespace BordGameScripting
{
    public class GameMain
    {

        GameLib.Core.Game game;
        List<GameInputter> pls = new List<GameInputter>();

        public GameMain() {
            LibraryLoader loader = new LibraryLoader(ProgramBGSGUI.LibraryPath);
            var tgame = loader.Games.Select(s => s.GetExportedTypes()).To2D().ToEnumerable().Where(s => s.GetBaseTypes().Contains(typeof(Game))).ToArray();
            var tinput = loader.Inputters.Select(s => s.GetExportedTypes()).To2D().ToEnumerable().Where(s => s.GetBaseTypes().Contains(typeof(GameInputter))).ToArray();
            //Menu(tgame, tinput);

        }




        public void Menu(Type[] tgames, Type[] tinputters) {
            //game.StorePlayer(pls.ToArray());

        }
    }
}