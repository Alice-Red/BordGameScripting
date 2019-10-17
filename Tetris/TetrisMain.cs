using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GameLib;
using GameLib.Core;
using GameLib.Core.Util;
using RUtil;

namespace Tetris
{
    public class TetrisMain : SingleGame {

        TetrisField TField;
        public int ServerRate = 10;

        private int serverSleep => (1000.0 / ServerRate).Round();

        public TetrisMain() {
            OnDraw += TetrisMain_OnDraw_Console;
            OnDraw += TetrisMain_OnDraw_GDI;

        }

        private void TetrisMain_OnDraw_GDI(Game sender, OnDrawArgs e) {

        }

        private void TetrisMain_OnDraw_Console(Game sender, OnDrawArgs e) {
            StringBuilder sb = new StringBuilder();

            Enumerable.Range(0, 4).ForEach(i => {
                TField.Generator.Nexts.Select(h => Minos.MinoP[h].Raw(i).Select(s => s == 0 ? "　" : "■").Join("")).Join("");
            });

            var f = TField.GetRect(RawColumn.New(1, 20), RawColumn.New(10, 39));
            foreach (var item in f) {
                sb.AppendLine(item.Select(s => s == 0 ? "　" : "■").Join(""));
            }

            Console.Clear();
            Console.WriteLine(sb.ToString());

        }

        public override void Start() {
            TField = new TetrisField();
        }

        public override void UpDate() {

        }

        public override void End() {

        }
    }
}
