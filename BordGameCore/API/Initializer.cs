using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib.Core.Base;

namespace GameLib.API
{
    public abstract class Initializer
    {
        protected abstract IMenu GetIMenu();

        protected abstract GameInputter Get1P();

        protected abstract GameInputter Get2P();

        protected abstract IInputObjectContainer GetInputContainer();

        protected abstract GridField GetField();

    }
}
