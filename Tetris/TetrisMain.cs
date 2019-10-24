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
    public class TetrisMain : SingleGame
    {

        TetrisField TField;
        OperationSet opSet;


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

            var f = TField.DrawableField().ToJagged();
            foreach (var item in f) {
                sb.AppendLine(item.Select(s => s == 0 ? "　" : "■").Join(""));
            }

            Console.Clear();
            Console.WriteLine(sb.ToString());

        }

        public override void Start() {
            TField = new TetrisField();
            opSet = new OperationSet();
        }

        public override void UpDate() {
            foreach (var item in opSet.Commands) {
                switch (item.command) {
                    case InputCommand.None:
                        break;
                    case InputCommand.HardDrop:

                        break;
                    case InputCommand.WaitDrop:
                        break;
                    case InputCommand.MoveLeft:
                        break;
                    case InputCommand.MoveRight:
                        break;
                    case InputCommand.RotateLeft:
                        break;
                    case InputCommand.RotateRight:
                        break;
                    case InputCommand.Hold:
                        break;
                    case InputCommand.Command:
                        break;
                    default:
                        break;
                }
            }
        }

        public override void End() {

        }
    }
}
