using GameLib.API;
using GameLib.Core;
using GameLib.Core.Util;
using RUtil;
using RUtil.Tcp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    [GameAddon(ID)]
    public class TetrisMainMultiServer : MultiGame
    {

        public const string ID = "Tetris";

        private double FallRate = 1;
        private long RateCount;

        public List<TetrisField> PlayersFields;
        //public List<TetrisInputter> Players;
        public TetrisInputter Player;
        public OperationSet[] PlayersInputStruct;
        private List<string> iPs;
        public MinoGenerator Generator;
        public int[] Losers;
        private bool closing = false;

        private Server server;

        public TetrisMainMultiServer() : base() {
            this.MaxPlayer = 1;
            this.ServerRate = 20;
            iPs = new List<string>();
            //iPs.Add("Host");
        }

        public override void StorePlayer(params GameInputter[] players) {
            PlayersFields = new List<TetrisField>();
            if (players.Length >= 1) {
                Player = (TetrisInputter) players[0];
                PlayersFields.Add(new TetrisField());
            }
        }

        public override void Start() {

            Console.Write("Player Count >>");
            MaxPlayer = int.Parse(Console.ReadLine());

            server = new Server();
            server.Create(34481);
            server.ConnectionSuccessfull += Server_ConnectionSuccessfull;
            server.ServerAwaked += Server_ServerAwaked;
            server.MessageReceived += Server_MessageReceived;
            server.Boot();


            while (!closing)
                ;
            PlayersInputStruct = Enumerable.Range(0, PlayersFields.Count()).Select(s => new OperationSet()).ToArray();

            Generator = new MinoGenerator();
            GenerateMino();
            for (int i = 0; i < PlayersFields.Count(); i++) {
                PlayersFields[i].SuperFast = false;
            }
            OnDraw += TetrisMain_OnDraw_Console;
        }

        private void Server_ServerAwaked(Server sender, ServerAwakedArgs e) {
            Console.WriteLine($"Waiting ({e.IpAddress.Join(Environment.NewLine)} : {e.Port})");
        }

        private void Server_ConnectionSuccessfull(Server sender, ConnetionSuccessfullArgs e) {
            ConsoleOut.Debug($"{e.IpAddress}");
            if (!closing) {
                iPs.Add(e.IpAddress);
                PlayersFields.Add(new TetrisField());
                if (MaxPlayer == iPs.Count() + 1) {
                    closing = true;
                }
                Console.WriteLine(e.IpAddress);
            }
        }

        private void Server_MessageReceived(Server sender, MessageReceivedArgs e) {
            ConsoleOut.Debug($"({e.IpAddress}){e.Message}");
            int id_in_ips = iPs.IndexOf(e.IpAddress);
            var cmmand = new CommandStruct(e.Message);

            PlayersInputStruct[id_in_ips + 1] = CommandConverter.InputSrtingToOpSet(cmmand);

        }

        private void TetrisMain_OnDraw_Console(Game sender, OnDrawArgs e) {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            Enumerable.Range(0, 4).ForEach(i => {
                sb.AppendLine(Generator.Nexts.Select(h => Minos.MinoP[h].Raw(i).Select(s => s == 0 ? "　" : "■").Join("")).Join("　"));
            });

            sb.AppendLine();
            sb.AppendLine(PlayersFields.Select(s => " Line : " + s.Lines).Join("\t\t"));
            sb.AppendLine(PlayersFields.Select(s => "Score : " + s.Score).Join("\t\t"));

            sb.AppendLine(Enumerable.Repeat("-－－－－－－－－－－-", PlayersFields.Count()).Join(" "));
            var fs = PlayersFields.Select(s => s.DrawableField()).ToArray();
            for (int i = 0; i < 20; i++) {
                sb.AppendLine(fs.Select(h => ("|" + h[i].Select(s => s == 0 ? "　" : "■").Join("") + "|")).Join(" "));
            }
            sb.AppendLine(Enumerable.Repeat("-－－－－－－－－－－-", PlayersFields.Count()).Join(" "));

            var lines = sb.ToString();


            Console.Clear();
            Console.WriteLine(lines);

        }
        public void GenerateMino() {
            Generator.Generate();
            for (int i = 0; i < PlayersInputStruct.Length; i++) {
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

                Task.Factory.StartNew(() => {
                    PlayersInputStruct[0] = Player.Inputs(PlayersFields[0]);
                });

                for (int i = 0; i < iPs.Count(); i++) {
                    ConsoleOut.Debug($"++++{iPs[i]}");
                    server.Send((s, k) => s.RemoteEndPoint.ToString() == iPs[i], CommandConverter.CreateInputCommand(PlayersFields[i]));
                }
                //System.Threading.Thread.Sleep(10);
                turn++;

            }

            for (int i = 0; i < PlayersInputStruct.Length; i++) {

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
                obsrt = (((double) obsrt - 1) * (3 / 2)).RoundDown();

                if (obsrt > 0) {
                    PlayersFields.Remove(i).Random().Obstacle(obsrt);
                    //PlayersFields[target];
                }
            }

            //StringBuilder sb = new StringBuilder();
            //sb.Append("SYNC|");
            //sb.Append(PlayersFields.Select((s, i) => $"{iPs[i]}:" + s.GetShowableField().SelectMany(f => f).Join(",")).Join("|"));

            //server.SendAll(sb.ToString());

            RateCount++;
        }

        public override void End() {
            //Console.WriteLine($"Winner is {(Loser == -1 ? "none" : Players[Loser - 1].Name() + " (Player" + (Loser) + ")")}");
            Console.WriteLine("game over");
        }
    }
}
