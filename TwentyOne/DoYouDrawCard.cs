using GameLib.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyOne
{
    public enum CardAction
    {
        None,
        UseSP,
        Stay,
        Need,
    }



    public struct DoYouDrawCard : IInputObjectContainer
    {
        public CardAction cardAction;
        public int sptype;
    }
}
