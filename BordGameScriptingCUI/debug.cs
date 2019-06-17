using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BordGameCore;
using BordGameCore.GameCore.Util;
using RUtil;

namespace BordGameScriptingCUI
{
    class debug
    {
        public debug() {
            ConsoleOut.SetRestriction(
                MessageType.All
                );
            ConsoleOut.Debug("aiueo1");
            ConsoleOut.Error("aiueo2");
            ConsoleOut.Log("aiueo3");
            ConsoleOut.Warning("aiueo4");
            ConsoleOut.Information("aiueo5");
            ConsoleOut.Debug("aiueo6");
            ConsoleOut.Debug("aiueo7");
            ConsoleOut.Debug("aiueo8");



        }
    }
}
