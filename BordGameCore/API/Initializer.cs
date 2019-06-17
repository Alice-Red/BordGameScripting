using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BordGameCore.GameCore.Base;

namespace BordGameCore.API
{
    public abstract class Initializer
    {
        protected abstract IMenu GetIMenu();

        protected abstract IInputter Get1P();

        protected abstract IInputter Get2P();

        protected abstract IInputObjectContainer GetInputContainer();

        protected abstract GridField GetField();

    }
}
