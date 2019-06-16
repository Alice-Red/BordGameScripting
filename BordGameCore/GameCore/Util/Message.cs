using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using RUtil;

namespace BordGameCore.GameCore.Util
{
    public struct Message
    {
        public DateTime Time { get; }
        public string SourceProperty { get; }
        public string SourceFile { get; }
        public int SourceLine { get; }
        public MessageType Type { get; }
        public string MessageText { get; }

        public Message(string messageText, string sourceProperty, string sourceFile, int sourceLine, MessageType type) {
            Time = DateTime.Now;
            SourceProperty = sourceProperty;
            SourceFile = sourceFile;
            SourceLine = sourceLine;
            Type = type;
            MessageText = messageText;
        }

        public override string ToString() {
            return string.Format($"{Time.ToString("hh:mm:ss")}\t{SourceProperty}\t{Path.GetFileName(SourceFile)}\t{SourceLine}\t{Type.ToString()}\t{MessageText}");
        }
    }
}
