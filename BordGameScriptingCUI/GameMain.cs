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
        public GameMain() {
            ConsoleDrawer drawer = new ConsoleDrawer();
            LibraryLoader loader = new LibraryLoader(@"");
            var tgame = loader.Games.Select(s => s.GetExportedTypes()).To2D().ToEnumerable().Where(s => s is Game).ToArray();



        }


    }
}
