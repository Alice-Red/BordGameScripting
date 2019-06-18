using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib.API;
using GameLib.Core.Base;

namespace Gomoku
{
    public abstract class GamokuInputter : IInputter
    {
        public IInputObjectContainer Input(GridField field) {
            return Input(field);
        }

        public abstract GomokuInputObject Input(GomokuField field);

        public abstract string Name();
    }
}
