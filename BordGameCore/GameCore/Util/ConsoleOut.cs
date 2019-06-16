using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using RUtil;

namespace BordGameCore.GameCore.Util
{
    public class ConsoleOut
    {

        public static List<Message> AllMessages { get; } = new List<Message>();

        private static MessageType Restriction = MessageType.None;

        public static void SetRestriction(params MessageType[] types) {
            if (types.Length == 0)
                return;
            Restriction = types[0];
            for (int i = 1; i < types.Length; i++) {
                Restriction |= types[i];
            }
        }

        public static void Log(string text, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = -1) {
            var t = AllMessages.AddGet(new Message(text, memberName, filePath, lineNumber, MessageType.Debug));
            if (Restriction.HasFlag(t.Type))
                Console.WriteLine(t.ToString());
        }

        public static void Log(MessageType type, string text, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = -1) {
            var t = AllMessages.AddGet(new Message(text, memberName, filePath, lineNumber, type));
            if (Restriction.HasFlag(t.Type))
                Console.WriteLine(t.ToString());
        }
        public static void Information(string text, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = -1) {
            var t = AllMessages.AddGet(new Message(text, memberName, filePath, lineNumber, MessageType.Info));
            if (Restriction.HasFlag(t.Type))
                Console.WriteLine(t.ToString());
        }

        public static void Debug(string text, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = -1) {
            var t = AllMessages.AddGet(new Message(text, memberName, filePath, lineNumber, MessageType.Debug));
            if (Restriction.HasFlag(t.Type))
                Console.WriteLine(t.ToString());
        }

        public static void Warning(string text, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = -1) {
            var t = AllMessages.AddGet(new Message(text, memberName, filePath, lineNumber, MessageType.Warning));
            if (Restriction.HasFlag(t.Type))
                Console.WriteLine(t.ToString());
        }

        public static void Error(string text, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = -1) {
            var t = AllMessages.AddGet(new Message(text, memberName, filePath, lineNumber, MessageType.Error));
            if (Restriction.HasFlag(t.Type))
                Console.WriteLine(t.ToString());
        }

    }
}
