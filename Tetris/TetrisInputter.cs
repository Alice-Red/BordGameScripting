using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib.API;

namespace Tetris
{
    public abstract class TetrisInputter : GameInputter
    {
        public abstract OperationSet Inputs(TetrisField field);

        public override IInputObjectContainer Input(GameField field) {
            return this.Inputs((TetrisField) field);
        }

        public abstract void Initialize();
    }
}
