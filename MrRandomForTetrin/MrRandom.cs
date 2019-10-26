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
            //field.Current;
            OperationSet opset = new OperationSet();
            opset.Store(InputCommand.HardDrop);

            return opset;
        }

    }
}
