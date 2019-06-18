using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib.API;
using GameLib.Core;
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
            var t = field.BeConnected(2);

            GomokuInputObject box = new GomokuInputObject(t.Ramdom());

        }

    }
}
