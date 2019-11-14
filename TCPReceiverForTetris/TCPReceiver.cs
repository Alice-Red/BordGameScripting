using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLib.API;
using GameLib.Core.Util;
using RUtil;
using RUtil.Tcp;
using Tetris;

namespace TCPReceiverForTetris
{
    [GameAddon(TetrisMain.ID)]
    public class TCPReceiver : TetrisInputter
    {
        Server server = new Server();
        bool init = false;
        public bool Connecting { get; private set; } = false;
        string ConnectingIP = "";
        bool CommandReturned = false;


        List<CommandStruct> CommandsStore;

        private void Initialize() {
            server.Create(34481);
            server.ConnetionSuccessfull += Server_ConnetionSuccessfull;
            server.MessageReceived += Server_MessageReceived;

            init = true;
        }

        private void Server_ConnetionSuccessfull(Server sender, ConnetionSuccessfullArgs e) {
            if (ConnectingIP == "") {
                ConnectingIP = e.IpAddress;
                Connecting = true;
            }
        }

        private void Server_MessageReceived(Server sender, MessageReceivedArgs e) {
            if (e.IpAddress == ConnectingIP) {
                CommandsStore.Add(new CommandStruct(e.Message));
                if (e.Message.Split('|').FirstOrDefault() == "INPUT") {
                    CommandReturned = true;
                }
            }
        }

        public override string Name() {
            if (!init)
                Initialize();
            return GetName();
        }

        public override OperationSet Inputs(TetrisField field) {
            if (!init)
                Initialize();
            //OpenFileDialog fileDialog = new OpenFileDialog();
            //fileDialog.
            CommandReturned = false;
            server.Send((s, i) => i == 0, FieldToString(field));
            while (!CommandReturned)
                ;
            var ttt = CommandsStore.Where(s => s.Head == "INPUT").LastOrDefault();
            OperationSet opset = new OperationSet();
            opset.Store(InputCommand.MoveLeft, int.Parse(ttt.Values["Move"][0]));
            opset.Store(InputCommand.RotateLeft, int.Parse(ttt.Values["Rotate"][0]));
            return opset;
        }

        public string GetName() {
            var name = CommandsStore.Where(s => s.Head == "NAME").FirstOrDefault();
            return name != null ? "" : name.Values["Name"][0];
        }

        public string FieldToString(TetrisField field) {
            StringBuilder sb = new StringBuilder();
            sb.Append("INPUT|");
            var enableField = field.GetRect(RawColumn.New(20, 1), RawColumn.New(39, 10));
            sb.Append(enableField.SelectMany(s => s).Join(",") + "|");
            sb.Append($"{field.Current.Position.Raw},{field.Current.Position.Column}|");
            sb.Append($"{field.Current.Mino},{field}");

            return sb.ToString();
        }

    }
}
