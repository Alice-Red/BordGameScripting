using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib.API;
using GameLib.Core.Base;

namespace Gomoku
{
    public class GomokuInit : Initializer
    {
        protected override IInputter Get1P() {
            throw new NotImplementedException();
        }

        protected override IInputter Get2P() {
            throw new NotImplementedException();
        }

        protected override GridField GetField() {
            throw new NotImplementedException();
        }

        protected override IMenu GetIMenu() {
            throw new NotImplementedException();
        }

        protected override IInputObjectContainer GetInputContainer() {
            throw new NotImplementedException();
        }
    }
}
