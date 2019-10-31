using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib.API;
using GameLib.Core;

namespace Tetris
{
    [GameAddon(ID)]
    public class TetrisMainMulti : MultiGame
    {


        public const string ID = "Tetris";

        public TetrisMainMulti() : base() {

        }

        public TetrisMainMulti(params TetrisInputter[] players) : base() {

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
