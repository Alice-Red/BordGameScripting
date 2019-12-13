using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib.API;
using GameLib.Core;

namespace TwentyOne
{
    [GameAddon(ID)]
    public class TwentyOneMain : BordGame
    {

        public const string ID = "TwentyOne";

        public TwentyOneMain() {
            OnDraw += TwentyOneMain_OnDraw;
        }

        private void TwentyOneMain_OnDraw(Game sender, OnDrawArgs e) {

        }

        public override void StorePlayer(params GameInputter[] players) {

        }

        public override void Start() {


        }

        public override void UpDate() {

        }

        public override void End() {

        }
    }
}
