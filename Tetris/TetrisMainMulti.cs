using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib.API;
using GameLib.Core;
using RUtil;

namespace Tetris
{
    [GameAddon(ID)]
    public class TetrisMainMulti : MultiGame
    {


        public const string ID = "Tetris";



        public TetrisField[] PlayersFields;
        public TetrisInputter[] Players;
        public MinoGenerator Generator;
        public int[] Losers;


        public TetrisMainMulti() : base() {
            this.MaxPlayer = 2;
            this.ServerRate = 2;
        }

        public TetrisMainMulti(params TetrisInputter[] players) : base() {
            StorePlayer(players);
        }

        private void TetrisMain_OnDraw_Console(Game sender, OnDrawArgs e) {
            StringBuilder sb = new StringBuilder();

            Enumerable.Range(0, 4).ForEach(i => {
                sb.AppendLine(Generator.Nexts.Select(h => Minos.MinoP[h].Raw(i).Select(s => s == 0 ? "　" : "■").Join("")).Join(""));
            });

            sb.AppendLine(Enumerable.Repeat("-－－－－－－－－－－-", Players.Length).Join(" "));
            var fs = PlayersFields.Select(s => s.DrawableField()).ToArray();
            for (int i = 0; i < 20; i++) {
                sb.AppendLine(fs.Select(h => ("|" + h[i].Select(s => s == 0 ? "　" : "■").Join("") + "|")).Join(" "));
            }
            sb.AppendLine(Enumerable.Repeat("-－－－－－－－－－－-", Players.Length).Join(" "));

            Console.Clear();
            Console.WriteLine(sb.ToString());

        }


        public override void StorePlayer(params GameInputter[] players) {
            int count = players.Length;
            Players = players.Select(s => (TetrisInputter) s).ToArray();
            PlayersFields = Enumerable.Range(0, count).Select(s => new TetrisField()).ToArray();
        }


        public override void Start() {
            Generator = new MinoGenerator();
            GenerateMino();
            for (int i = 0; i < PlayersFields.Length; i++) {
                PlayersFields[i].SuperFast = true;
            }
            OnDraw += TetrisMain_OnDraw_Console;
        }

        public void GenerateMino() {
            Generator.Generate();
            for (int i = 0; i < Players.Length; i++) {
                PlayersFields[i].Current = new FallingBlock() {
                    Mino = Generator.Current,
                    State = MainPartConfiguration.Generated,
                    Position = TetrisUtils.GeneratePosition,
                    Rotate = 0
                };
            }
        }

        public override void UpDate() {
            //var inputStructs = new OperationSet[Players.Length];
            System.Diagnostics.Debug.WriteLine($"{turn}");
            for (int j = 0; j < Players.Length; j++) {
                int i = j;
                //Task.Factory.StartNew(() => {

                var inputStructs = Players[i].Inputs(PlayersFields[i]);
                foreach (var item in inputStructs.Commands) {
                    switch (item.command) {
                        case InputCommand.MoveLeft:
                            for (int k = 0; k < item.value; k++) {
                                PlayersFields[i].Move(true);
                            }
                            break;
                        case InputCommand.MoveRight:
                            for (int k = 0; k < item.value; k++) {
                                PlayersFields[i].Move(false);
                            }
                            break;
                        case InputCommand.RotateLeft:
                            for (int k = 0; k < item.value; k++) {
                                PlayersFields[i].Rotate(true);
                            }
                            break;
                        case InputCommand.RotateRight:
                            for (int k = 0; k < item.value; k++) {
                                PlayersFields[i].Rotate(false);
                            }
                            break;
                        default:
                            break;
                    }


                }
                PlayersFields[i].HardDrop();
                PlayersFields[i].ScanErase();
                //});
            }

            for (int i = 0; i < Players.Length; i++) {
                while (PlayersFields[i].Current.State != MainPartConfiguration.Generated)
                    System.Threading.Thread.Sleep(1);
            }

            GenerateMino();
            Losers = PlayersFields.Select(s => s.CheckWinner()).ToArray();

            switch (Losers.Count(s => s == 0)) {
                case 0:
                    Loser = -1;
                    break;
                case 1:
                    Loser = Losers.IndexOf(0) + 1;
                    break;
                default:
                    break;
            }

            turn++;

        }

        public override void End() {
            Console.WriteLine($"Winner is {(Loser == -1 ? "none" : Players[Loser - 1].Name() + " (Player" + (Loser) + ")")}");
            Console.WriteLine("game over");

        }

    }
}