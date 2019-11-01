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



        public TetrisMainMulti() : base() {

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
            for (int i = 0; i < PlayersFields.Length; i++) {
                PlayersFields[i].Generator = Generator;
            }
        }

        public override void UpDate() {
            var inputStructs = new OperationSet[Players.Length];
            for (int i = 0; i < inputStructs.Length; i++) {
                Task.Factory.StartNew(() => {
                    inputStructs[i] = Players[i].Inputs(PlayersFields[i]);
                    foreach (var item in inputStructs[i].Commands) {
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
                });
            }



        }

        public override void End() {

        }

    }
}
