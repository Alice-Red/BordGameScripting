using GameLib.Core.Util;
using RUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class CommandConverter
    {
        public static string CreateInputCommand(TetrisField field) {
            StringBuilder sb = new StringBuilder();
            sb.Append("INPUT|");
            var enableField = field.GetRect(RawColumn.New(20, 1), RawColumn.New(39, 10));
            sb.Append("Field:" + enableField.SelectMany(s => s).Join(",") + "|");
            sb.Append("Position:" + $"{field.Current.Position.Raw},{field.Current.Position.Column}|");
            sb.Append("Next:" + $"{field.Current.Mino},{field.Nexts.Join(",")}");

            return sb.ToString();
        }

        public static OperationSet InputSrtingToOpSet(CommandStruct command) {
            if (command.Head == "INPUT") {
                OperationSet opset = new OperationSet();
                opset.Store(InputCommand.RotateLeft, int.Parse(command.Values["Rotate"][0]));
                opset.Store(InputCommand.MoveLeft, int.Parse(command.Values["Move"][0]));
                return opset;
            }
            return default(OperationSet);
        }

        public static TetrisField CommandToField(CommandStruct command) {
            if (command.Head == "INPUT") {
                var fld = ValueToField(command.Values["Field"]);
                var pos = new RawColumn(int.Parse(command.Values["Position"][0]), int.Parse(command.Values["Position"][1]));
                var nex = command.Values["Next"].Select(s => s.ToEnum<Mino>()).ToArray();
                var cur = nex.First();
                nex = nex.Skip(1).ToArray();
                return new TetrisField(fld, new FallingBlock(pos, cur, 0, nex));
            }
            return default(TetrisField);
        }

        public static string OpSetToString(OperationSet opset) {
            StringBuilder sb = new StringBuilder();
            sb.Append("INPUT|");
            sb.Append(opset.Commands.Select(s => {
                switch (s.command) {
                    case InputCommand.MoveLeft:
                        return ("Move:" + s.value * -1);
                    case InputCommand.MoveRight:
                        return ("Move:" + s.value);
                    case InputCommand.RotateLeft:
                        return ("Rotate:" + s.value * -1);
                    case InputCommand.RotateRight:
                        return ("Rotate:" + s.value);
                    default:
                        return "";
                }
            }).Join("|"));
            return sb.ToString();
        }

        public static int[,] ValueToField(string[] value) {
            int[,] f = new int[41, 12];
            var t = value.Select(s => int.Parse(s)).Chunk(10).ToJagged();
            for (int i = 0; i < t.Length; i++) {
                for (int j = 0; j < t[i].Length; j++) {
                    f[i + 20, j + 1] = t[i][j];
                }
            }
            return f;
        }

    }
}
