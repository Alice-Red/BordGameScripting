using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib.API;

namespace GameLib.Core
{
    public class GameAutoLoop
    {

        Game Target;
        GameInputter[] Players;
        int count;

        public GameAutoLoop(Game target, GameInputter[] players, int count) {
            Target = target;
            Players = players;
            this.count = count;
        }

        public void Boot() {
            var GAME = (Target.GetType()) Activator.CreateInstance(Target.GetType());
        }


    }
}
