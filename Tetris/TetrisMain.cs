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
    public class TetrisMain : MultiGame
    {

        public const string ID = "Tetris";
        TetrisField TField;
        TetrisInputter pl;
        OperationSet opSet;
        public string Err = "";
        private double FallRate = 1;
        protected MinoGenerator Generator;

        public TetrisMain() {
            OnDraw += TetrisMain_OnDraw_Console;
            this.MaxPlayer = 1;
            this.ServerRate = 15;
            //OnDraw += TetrisMain_OnDraw_GDI;
            //OnDraw -= TetrisMain_OnDraw_GDI;

        }

        public override void StorePlayer(params GameInputter[] players) {
            System.Diagnostics.Debug.WriteLine($"{players[0] is TetrisInputter}");

            if (players.Length >= 1) {
                pl = (TetrisInputter) Activator.CreateInstance(players[0].GetType());

            } else
                Err = "Player Cast faile.";
        }

        private void TetrisMain_OnDraw_GDI(Game sender, OnDrawArgs e) {

        }

        private void TetrisMain_OnDraw_Console(Game sender, OnDrawArgs e) {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            Enumerable.Range(0, 4).ForEach(i => {
                sb.AppendLine("　" + Generator.Nexts.Select(h => Minos.MinoP[h].Raw(i).Select(s => s == 0 ? "　" : "■").Join("")).Join("  "));
            });

            for (int i = 0; i < TField.Current.Shape().GetLength(1); i++) {
                sb.AppendLine("　" + TField.Current.Shape().ToJagged()[i].Select(s => s == 0 ? "　" : "■").Join(""));
            }

            sb.AppendLine();
            sb.AppendLine($"Lines:{TField.Lines} Score:{TField.Score}");
            sb.AppendLine();
            sb.AppendLine("-－－－－－－－－－－-");
            var f = TField.DrawableField();
            foreach (var item in f) {
                sb.AppendLine("|" + item.Select(s => s == 0 ? "　" : "■").Join("") + "|");
            }
            sb.AppendLine("-－－－－－－－－－－-");

            Console.Clear();
            Console.WriteLine(sb.ToString());

        }

        public void GenerateMino() {
            TField.Current = new FallingBlock() {
                Mino = Generator.Generate(),
                State = MainPartConfiguration.Generated,
                Position = TetrisUtils.GeneratePosition,
                Rotate = 0
            };
        }

        public override void Start() {
            TField = new TetrisField();
            opSet = new OperationSet();
            Generator = new MinoGenerator();
            GenerateMino();
            System.Diagnostics.Debug.WriteLine("Inited.");
        }

        public override void UpDate() {
            if (Err != "") {
                System.Diagnostics.Debug.WriteLine(Err);
                Loser = -2;
                return;
            }
            opSet = pl.Inputs(TField);

            for (int j = 0; j < opSet.Commands.Length; j++) {
                switch (opSet.Commands[j].command) {
                    case InputCommand.MoveLeft:
                        for (int i = 0; i < Math.Abs(opSet.Commands[j].value); i++) {
                            TField.Move(opSet.Commands[j].value < 0);
                        }
                        break;
                    case InputCommand.MoveRight:
                        for (int i = 0; i < Math.Abs(opSet.Commands[j].value); i++) {
                            TField.Move(opSet.Commands[j].value > 0);
                        }
                        break;
                    case InputCommand.RotateLeft:
                        for (int i = 0; i < Math.Abs(opSet.Commands[j].value); i++) {
                            TField.Rotate(opSet.Commands[j].value < 0);
                        }
                        break;
                    case InputCommand.RotateRight:
                        for (int i = 0; i < Math.Abs(opSet.Commands[j].value); i++) {
                            TField.Rotate(opSet.Commands[j].value > 0);
                        }
                        break;
                    default:
                        break;
                }
            }

            TField.HardDrop();

            TField.ScanErase();
            GenerateMino();


            Loser = TField.CheckWinner();

            //Console.WriteLine("update");
        }

        public override void End() {
            Console.WriteLine("game over");
            Console.WriteLine("any key...");
        }

    }
}
