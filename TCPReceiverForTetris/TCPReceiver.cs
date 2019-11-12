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
    public class TCPReceiver : TetrisInputter
    {
        Server server = new Server();
        bool init = false;
        bool Connecting { get; }

        private void Initialize() {
            server.Create(34481);


            init = true;
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
            server.Send(,FieldToString(field));

        }

        public string GetName() {

        }

        public string FieldToString(TetrisField field) {
            StringBuilder sb = new StringBuilder();
            sb.Append("INPUT|");
            var enableField = field.GetRect(RawColumn.New(20, 1), RawColumn.New(39, 10));
            sb.Append(enableField.SelectMany(s => s).Join(",") + "|");
            sb.Append($"{field.Current.Position.Raw},{field.Current.Position.Column}|");
            sb.Append($"{field.Current.Mino},{field}|");



            sb.ToString();
        }

    }
}
