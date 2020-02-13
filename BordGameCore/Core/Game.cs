using GameLib.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Core
{
    public abstract class Game
    {
        public virtual bool Enable { get; protected set; } = true;

        public virtual int MaxPlayer { get; protected set; } = 0;

        public abstract void Run();

        public abstract void StorePlayer(params GameInputter[] players);


    }
}
