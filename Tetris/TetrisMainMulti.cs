using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using GameLib.API;
using GameLib.Core;
using GameLib.Core.Util;
using RUtil;

namespace Tetris
{
    [GameAddon(ID)]
    public class TetrisMainMulti : MultiGame
    {


        public const string ID = "Tetris";


        private double FallRate = 1;
        private long RateCount;

        public TetrisField[] PlayersFields;
        public TetrisInputter[] Players;
        public OperationSet[] PlayersInputStruct;
        public MinoGenerator Generator;
        public int[] Losers;


        public TetrisMainMulti() : base() {
            this.MaxPlayer = 2;
            this.ServerRate = 15;
            ConsoleOut.SetRestriction(MessageType.All);
        }

        public TetrisMainMulti(params TetrisInputter[] players) : base() {
            StorePlayer(players);
        }

        private void TetrisMain_OnDraw_Console(Game sender, OnDrawArgs e) {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            Enumerable.Range(0, 4).ForEach(i => {
                sb.AppendLine(Generator.Nexts.Select(h => Minos.MinoP[h].Raw(i).Select(s => s == 0 ? "　" : "■").Join("")).Join("　"));
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
            PlayersInputStruct = Enumerable.Range(0, count).Select(s => new OperationSet()).ToArray();
        }


        public override void Start() {
            Generator = new MinoGenerator();
            GenerateMino();
            for (int i = 0; i < PlayersFields.Length; i++) {
                PlayersFields[i].SuperFast = false;
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
            //System.Diagnostics.Debug.WriteLine($"{turn}");


            if (PlayersFields.Select(s => s.Current.State).All(s => s == MainPartConfiguration.Placed || s == MainPartConfiguration.Generated)) {
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

                for (int i = 0; i < Players.Length; i++) {
                    PlayersInputStruct[i] = null;
                    int a = i;
                    PlayersInputStruct[a] = Players[a].Inputs(PlayersFields[a]);
                    //Task.Factory.StartNew(() => {
                    //});
                    //Thread.Sleep(1000);
                }


                turn++;

            }

            for (int i = 0; i < Players.Length; i++) {

                if (PlayersInputStruct[i] != null)
                    for (int j = 0; j < PlayersInputStruct[i].Commands.Length; j++) {
                        if (PlayersInputStruct[i].Commands[j].value != 0) {
                            switch (PlayersInputStruct[i].Commands[j].command) {
                                case InputCommand.MoveLeft:

                                    PlayersFields[i].Move(PlayersInputStruct[i].Commands[j].value <= -1);
                                    PlayersInputStruct[i].Commands[j].value = PlayersInputStruct[i].Commands[j].value.ToZero(1);
                                    break;
                                case InputCommand.MoveRight:

                                    PlayersFields[i].Move(PlayersInputStruct[i].Commands[j].value >= 1);
                                    PlayersInputStruct[i].Commands[j].value = PlayersInputStruct[i].Commands[j].value.ToZero(1);
                                    break;
                                case InputCommand.RotateLeft:

                                    PlayersFields[i].Rotate(PlayersInputStruct[i].Commands[j].value >= 1);
                                    PlayersInputStruct[i].Commands[j].value = PlayersInputStruct[i].Commands[j].value.ToZero(1);
                                    break;
                                case InputCommand.RotateRight:

                                    PlayersFields[i].Rotate(PlayersInputStruct[i].Commands[j].value <= -1);
                                    PlayersInputStruct[i].Commands[j].value = PlayersInputStruct[i].Commands[j].value.ToZero(1);
                                    break;
                                default:
                                    break;
                            }

                            break;
                        }
                    }
                if (RateCount % FallRate == 0)
                    PlayersFields[i].Fall();
                //PlayersFields[i].HardDrop();

                int obsrt = PlayersFields[i].ScanErase();
                if (obsrt != 0) {
                    var target = Enumerable.Range(0, PlayersFields.Length).Random();
                    PlayersFields[target].Obstacle(obsrt);
                }
            }
            RateCount++;
        }

        public override void End() {
            Console.WriteLine($"Winner is {(Loser == -1 ? "none" : Players[Loser - 1].Name() + " (Player" + (Loser) + ")")}");
            Console.WriteLine("game over");

        }

    }
}