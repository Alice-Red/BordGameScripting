using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib.Core.Base;

namespace GameLib.API
{
    public abstract class GameInputter
    {
        public virtual bool Enable { get; protected set; } = true;

        public abstract string Name();

        public abstract IInputObjectContainer Input(GameField field);

    }
}
