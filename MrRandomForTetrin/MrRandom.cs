using GameLib.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris;

namespace MrRandomForTetris
{
    [GameAddon(TetrisMain.ID)]
    public class MrRandom : TetrisInputter
    {

        const string NAME = "Mr.Random";

        public override string Name() {
            return NAME;
        }

        public override OperationSet Inputs(TetrisField field) {

            OperationSet opset = new OperationSet();
            opset.Store(Util.DICE(100) <= 50 ? InputCommand.MoveLeft : InputCommand.MoveRight, Util.DICE(6) - 1);
            opset.Store(Util.DICE(100) <= 50 ? InputCommand.RotateLeft : InputCommand.RotateRight, Util.DICE(4) - 1);


            return opset;
            //.Store(InputCommand.HardDrop);
        }

    }
}
