using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib.API;
using GameLib.Core.Base;

namespace Gomoku
{
    public abstract class GamokuInputter : GameInputter
    {

        public override IInputObjectContainer Input(GameField field) {
            return Input((GomokuField) field);
        }

        public abstract GomokuInputObject Input(GomokuField field);

    }
}
