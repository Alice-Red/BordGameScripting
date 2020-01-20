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
    public class TetrisMainMultiClient : MultiGame
    {
        public const string ID = "Tetris";


        private double FallRate = 1;
        private long RateCount;

        public TetrisField[] PlayersFields;
        public TetrisInputter Player;
        public OperationSet PlayersInputStruct;
        public MinoGenerator Generator;
        public int[] Losers;

        private Client client = new Client();

        public TetrisMainMultiClient() : base() {
            this.MaxPlayer = 1;
            this.ServerRate = 10;
            ConsoleOut.SetRestriction(MessageType.All);
        }

        public override void StorePlayer(params GameInputter[] players) {
            if (players.Length >= 1) {
                Player = (TetrisInputter) players[0];
            }
            PlayersFields = new TetrisField[0];
        }


        public override void Start() {
            Console.Write("IP? >>");
            client.MessageReceived += Client_MessageReceived;
            client.Create(Console.ReadLine(), 34481);
            client.Boot();

            Console.WriteLine("Connecting...");
            //for (int i = 0; i < PlayersFields.Length; i++) {
            //    PlayersFields[i].SuperFast = false;
            //}
        }

        private void Client_MessageReceived(Client sender, MessageReceivedArgs e) {
            ConsoleOut.Debug($"({e.IpAddress}){e.Message}");
            CommandStruct command = new CommandStruct(e.Message);

            switch (command.Head) {
                case "INPUT":
                    //PlayersFields[0] = CommandConverter.CommandToField(command);
                    PlayersInputStruct = Player.Inputs(CommandConverter.CommandToField(command));
                    client.Send(CommandConverter.OpSetToString(PlayersInputStruct));
                    break;
                case "NAME":
                    client.Send($"NAME|Name:{Player.Name()}");
                    break;
                case "SYNC":
                    //PlayersFields = command.Values.Select(s => new TetrisField(CommandConverter.ValueToField(s.Value), new FallingBlock())).ToArray();
                    break;
                case "INFO":

                    break;
                default:
                    break;
            }

        }



        public override void UpDate() {

        }


        public override void End() {
            Console.WriteLine($"");
            Console.WriteLine("game over");
        }
    }
}
