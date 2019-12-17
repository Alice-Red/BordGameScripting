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

        List<CommandStruct> CommandsStore = new List<CommandStruct>();

        public TCPReceiver() {
            //if (!init)
            //    Init();
        }

        private void Init() {
            server.Create(34481);
            server.ConnectionSuccessfull += Server_ConnectionSuccessfull;
            server.MessageReceived += Server_MessageReceived;
            server.ServerAwaked += Server_ServerAwaked;
            server.Boot();
            init = true;
        }

        public override void Initialize() {
            if (!init)
                Init();
            while (!Connecting)
                ;

        }

        private void Server_ServerAwaked(Server sender, ServerAwakedArgs e) {
            ConsoleOut.Information($"{e.IpAddress.Join(" || ")} :: {e.Port}");
        }

        private void Server_ConnectionSuccessfull(Server sender, ConnetionSuccessfullArgs e) {
            if (ConnectingIP == "") {
                ConnectingIP = e.IpAddress;
                Connecting = true;
                ConsoleOut.Information("connected" + e.IpAddress);
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
                Init();
            return GetName();
        }

        public override OperationSet Inputs(TetrisField field) {
            if (!init)
                Init();
            //OpenFileDialog fileDialog = new OpenFileDialog();
            //fileDialog.
            while (!Connecting)
                ;
            CommandReturned = false;
            server.Send((s, i) => i == 0, FieldToString(field));
            while (!CommandReturned)
                ;
            var ttt = CommandsStore.Where(s => s.Head == "INPUT").LastOrDefault();
            OperationSet opset = new OperationSet();
            opset.Store(InputCommand.RotateLeft, int.Parse(ttt.Values["Rotate"][0]));
            opset.Store(InputCommand.MoveLeft, int.Parse(ttt.Values["Move"][0]));
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
            sb.Append("Field:" + enableField.SelectMany(s => s).Join(",") + "|");
            sb.Append("Position:" + $"{field.Current.Position.Raw},{field.Current.Position.Column}|");
            sb.Append("Next:" + $"{field.Current.Mino}, {field}");

            return sb.ToString();
        }

    }
}
