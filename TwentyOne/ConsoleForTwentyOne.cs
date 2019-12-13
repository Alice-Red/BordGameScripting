using GameLib.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    [GameAddon("TwentyOne")]
    public class ConsoleForTwentyOne : TwentyOneInputter
    {
        string NAME = "";

        public override string Name() {
            if (NAME == "") {
                Console.Write("your name >");
                NAME = Console.ReadLine();
            }
            return NAME;
        }

        public override DoYouDrawCard Input(TwentyOneField fielda) {
            Console.WriteLine("");



            return new DoYouDrawCard();
        }
    }
}
