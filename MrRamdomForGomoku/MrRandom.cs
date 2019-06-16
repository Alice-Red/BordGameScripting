using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BordGameCore.API;
using BordGameCore.GameCore;
using Gomoku;


namespace MrRamdomForGomoku
{
    class MrRandom : GamokuInputter
    {
        const string NAME = "Mr.Random";

        public override string Name() {
            return NAME;
        }

        public override GomokuInputObject Input(GomokuField field) {
            field
        }

    }
}
