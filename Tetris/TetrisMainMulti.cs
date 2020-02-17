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
            //this.Enable = false;
            this.MaxPlayer = 2;
            this.ServerRate = 20;
            ConsoleOut.SetRestriction(MessageType.Default);
        }

        public TetrisMainMulti(params TetrisInputter[] players) : base() {
            StorePlayer(players);
        }

        private void TetrisMain_OnDraw_Console(Game sender, OnDrawArgs e) {
            TetrisFieldSandBox[] boxes = PlayersFields.Select(s => new TetrisFieldSandBox(s)).ToArray();
            boxes.ForEach(s => {
                s.HardDrop();
            });
            var boxcur = boxes.Select(s => s.Current).ToArray();
            //var ts = boxes.Select(s => s.DrawableField()).ToArray();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            Enumerable.Range(0, 4).ForEach(i => {
                sb.AppendLine(Generator.Nexts.Select(h => Minos.MinoP[h].Raw(i).Select(s => s == 0 ? "　" : "■").Join("")).Join("　") + "　　　　");
            });

            sb.AppendLine();
            sb.AppendLine(PlayersFields.Select(s => (" Line : " + s.Lines).PadLeftInBytes(Utility.PadType.Char, 23)).Join(""));
            sb.AppendLine(Players.Select(s => (" Name : " + s.Name()).PadLeftInBytes(Utility.PadType.Char, 23)).Join(""));
            sb.AppendLine(PlayersFields.Select(s => ("Score : " + s.Score).PadLeftInBytes(Utility.PadType.Char, 23)).Join(""));
            sb.AppendLine(PlayersFields.Select(s => (s.CheckWinner() == -1 ? "Dead" : "Alive").PadLeftInBytes(Utility.PadType.Char, 23)).Join(""));

            sb.AppendLine(Enumerable.Repeat("-－－－－－－－－－－-", PlayersFields.Length).Join(" "));

            var fs = PlayersFields.Select(s => s.DrawableField()).ToArray();
            for (int i = 0; i < boxcur.Length; i++) {
                boxcur[i].Position -= new RawColumn(20, 1);
                var t = boxcur[i].Shape();
                for (int k = 0; k < t.GetLength(0); k++) {
                    for (int j = 0; j < t.GetLength(1); j++) {
                        var rc = boxcur[i].Position + new RawColumn(k, j);
                        try {
                            if (fs[i][rc.Raw][rc.Column] == 0 && t[k, j] != 0) {
                                fs[i][rc.Raw][rc.Column] = -100;
                            }
                        } catch { }
                    }
                }
            }

            for (int i = 0; i < 20; i++) {
                sb.AppendLine(fs.Select(h => ("|" + h[i].Select(s => s == 0 ? "　" : (s == -100 ? "□" : "■")).Join("") + "|")).Join(" "));
            }
            sb.AppendLine(Enumerable.Repeat("-－－－－－－－－－－-", PlayersFields.Length).Join(" "));

            var lines = sb.ToString()/*.Trim('\r').Split('\n').ToArray();*/;


            //Console.Clear();
            Console.CursorTop = 0;
            Console.CursorLeft = 0;
            Console.WriteLine(lines);
            //for (int i = 0; i < lines.Length; i++) {
            //    Console.WriteLine(lines[i]);
            //}


        }


        public override void StorePlayer(params GameInputter[] players) {
            int count = players.Length;
            Players = players.Select(s => (TetrisInputter)s).ToArray();
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
                PlayersFields[i].Nexts = Generator.Nexts;
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
                    if (PlayersFields[i].CheckWinner() != -1) {
                        PlayersInputStruct[i] = null;
                        int a = i;
                        PlayersInputStruct[a] = Players[a].Inputs(PlayersFields[a].Clone());
                    }
                }

                turn++;

            }

            for (int i = 0; i < Players.Length; i++) {

                if (PlayersInputStruct[i] != null)
                    for (int j = 0; j < PlayersInputStruct[i].Commands.Length; j++) {
                        if (PlayersInputStruct[i].Commands[j].value != 0) {
                            switch (PlayersInputStruct[i].Commands[j].command) {
                                case InputCommand.RotateLeft:

                                    PlayersFields[i].Rotate(PlayersInputStruct[i].Commands[j].value <= -1);
                                    PlayersInputStruct[i].Commands[j].value = PlayersInputStruct[i].Commands[j].value.ToZero(1);
                                    break;
                                case InputCommand.RotateRight:

                                    PlayersFields[i].Rotate(PlayersInputStruct[i].Commands[j].value >= 1);
                                    PlayersInputStruct[i].Commands[j].value = PlayersInputStruct[i].Commands[j].value.ToZero(1);
                                    break;
                                default:
                                    break;
                            }

                            switch (PlayersInputStruct[i].Commands[j].command) {
                                case InputCommand.MoveLeft:

                                    PlayersFields[i].Move(PlayersInputStruct[i].Commands[j].value <= -1);
                                    PlayersInputStruct[i].Commands[j].value = PlayersInputStruct[i].Commands[j].value.ToZero(1);
                                    break;
                                case InputCommand.MoveRight:

                                    PlayersFields[i].Move(PlayersInputStruct[i].Commands[j].value >= 1);
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
                obsrt = (((double)obsrt - 1) * (3 / 2)).Round();

                if (obsrt > 0) {
                    PlayersFields.Remove(i).Where(s => s.CheckWinner() != -1).Random().Obstacle(obsrt);
                    //PlayersFields[target];
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