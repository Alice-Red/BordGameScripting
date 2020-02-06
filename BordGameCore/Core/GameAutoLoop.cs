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
            int c = 0;
            while (c < count || count == -1) {
                var GAME = (Game) Activator.CreateInstance(Target.GetType());
                //var INPUTS = Enumerable.Range(0, 2).Select(s => (GameInputter) Activator.CreateInstance(Players.Random().GetType())).ToArray();
                var INPUTS = Players.Select(s => (GameInputter) Activator.CreateInstance(s.GetType())).ToArray();
                GAME.StorePlayer(INPUTS);
                GAME.Run();

                c += 1;
                System.Threading.Thread.Sleep(1400);
                Console.Clear();
            }
        }


    }
}
