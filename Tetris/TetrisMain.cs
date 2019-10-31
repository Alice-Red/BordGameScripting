using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using GameLib;
using GameLib.API;
using GameLib.Core;
using GameLib.Core.Util;
using RUtil;
using System.Security.Policy;

namespace Tetris
{
    [GameAddon(ID)]
    public class TetrisMain : SingleGame
    {

        public const string ID = "Tetris";
        TetrisField TField;
        TetrisInputter pl;
        OperationSet opSet;
        public string Err = "";
        private double FallRate = 1;



        public TetrisMain() {
            OnDraw += TetrisMain_OnDraw_Console;
            this.ServerRate = 20;
            //OnDraw += TetrisMain_OnDraw_GDI;

        }
        public override void StorePlayer(params GameInputter[] players) {
            System.Diagnostics.Debug.WriteLine($"{players[0] is TetrisInputter}");

            if (players.Length >= 1) {

                var tmpPl = (TetrisInputter) Activator.CreateInstance(players[0].GetType());
                pl = tmpPl;


                //pl = players[0];
            } else
                Err = "Player Cast faile.";
        }

        private void TetrisMain_OnDraw_GDI(Game sender, OnDrawArgs e) {

        }

        private void TetrisMain_OnDraw_Console(Game sender, OnDrawArgs e) {
            StringBuilder sb = new StringBuilder();

            Enumerable.Range(0, 4).ForEach(i => {
                sb.AppendLine(TField.Generator.Nexts.Select(h => Minos.MinoP[h].Raw(i).Select(s => s == 0 ? "　" : "■").Join("")).Join(""));
            });

            var f = TField.DrawableField();
            foreach (var item in f) {
                sb.AppendLine(item.Select(s => s == 0 ? "　" : "■").Join(""));
            }

            Console.Clear();
            Console.WriteLine(sb.ToString());

        }

        public override void Start() {
            TField = new TetrisField();
            opSet = new OperationSet();
            Console.WriteLine("Inited.");
        }

        public override void UpDate() {
            if (Err != "") {
                System.Diagnostics.Debug.WriteLine(Err);
                Loser = -2;
                return;
            }
            opSet = pl?.Inputs(TField);

            foreach (var item in opSet.Commands) {
                switch (item.command) {
                    case InputCommand.None:
                        break;
                    case InputCommand.HardDrop:
                        TField.HardDrop();
                        break;
                    case InputCommand.WaitDrop:
                        TField.Fall();
                        break;
                    case InputCommand.MoveLeft:
                        Enumerable.Repeat(TField.Move(true), item.value);
                        break;
                    case InputCommand.MoveRight:
                        Enumerable.Repeat(TField.Move(false), item.value);
                        break;
                    case InputCommand.RotateLeft:
                        Enumerable.Repeat(TField.Rotate(true), item.value);
                        break;
                    case InputCommand.RotateRight:
                        Enumerable.Repeat(TField.Rotate(false), item.value);
                        break;
                    case InputCommand.Hold:
                        break;
                    case InputCommand.Command:
                        break;
                    default:
                        break;
                }
            }

            TField.Fall();

            TField.ScanErase();

            Loser = TField.CheckWinner();

            //Console.WriteLine("update");
        }

        public override void End() {
            Console.WriteLine("game over");
            Console.WriteLine("any key...");
        }

    }
}
