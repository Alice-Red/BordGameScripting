using GameLib.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    public abstract class TwentyOneInputter : GameInputter
    {
        public override IInputObjectContainer Input(GameField field) {
            return Input(fielda: (TwentyOneField) field);
        }

        public abstract DoYouDrawCard Input(TwentyOneField fielda);

    }
}
