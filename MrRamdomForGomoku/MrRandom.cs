using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib.API;
using Gomoku;


namespace MrRamdomForGomoku
{
    [GameAddon(Gomoku.Gomoku.ID)]
    public class MrRandom : GamokuInputter
    {
        const string NAME = "Mr.Random";

        public override string Name() {
            return NAME;
        }

        public override GomokuInputObject Input(GomokuField field) {
            var t = field.CanPutList();
            //Console.WriteLine($"\tt : {t.Count()}");
            GomokuInputObject box = new GomokuInputObject(t.Random());
            //if(t.Count()!=0)
            return box;
        }

    }
}
