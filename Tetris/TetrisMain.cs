using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GameLib;
using GameLib.Core;

namespace Tetris
{
    public class TetrisMain : SingleGame
    {

        TetrisField TField = new TetrisField();


        public TetrisMain() {
            OnDraw += TetrisMain_OnDraw_Console;
            OnDraw += TetrisMain_OnDraw_GDI;

        }

        private void TetrisMain_OnDraw_GDI(Game sender, OnDrawArgs e) {

        }

        private void TetrisMain_OnDraw_Console(Game sender, OnDrawArgs e) {
            StringBuilder sb = new StringBuilder();



            Console.Clear();
            Console.WriteLine(sb.ToString());

        }

        public override void Start() {

        }

        public override void UpDate() {

        }

        public override void End() {

        }
    }
}
