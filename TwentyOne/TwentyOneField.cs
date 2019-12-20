using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib.API;

namespace TwentyOne
{
    public class TwentyOneField : GameField
    {

        private int[] Deck;

        private int[][] PlayersHand;


        public int[] GetHand(int pl) {
            if (PlayersHand.Length <= pl)
                return PlayersHand[pl - 1];
            else
                return new int[0];
        }



    }
}
