using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using RUtil;

namespace GameLib.Core.Util
{
    public class ConsoleOut
    {

        private static List<Message> allMessages = new List<Message>();

        private static MessageType Restriction = MessageType.Default;

        /// <summary>
        /// すべてのログ
        /// </summary>
        public static Message[] AllMessages { get { return allMessages.ToArray(); } }

        /// <summary>
        /// コンソールに表示するログの種類を設定します
        /// </summary>
        /// <param name="types"></param>
        public static void SetRestriction(params MessageType[] types) {
            if (types.Length == 0)
                return;
            Restriction = types[0];
            for (int i = 1; i < types.Length; i++) {
                Restriction |= types[i];
            }
        }

        /// <summary>
        /// ログを送信します
        /// </summary>
        /// <param name="text">メッセージ</param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public static void Log(string text, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = -1) {
            var t = AllMessages.AddGet(new Message(text, memberName, filePath, lineNumber, MessageType.Debug));
            if (Restriction.HasFlag(t.Type))
                Console.WriteLine(t.ToString());
        }

        /// <summary>
        /// ログを送信します
        /// </summary>
        /// <param name="type">ログのタイプ</param>
        /// <param name="text">メッセージ</param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public static void Log(MessageType type, string text, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = -1) {
            var t = AllMessages.AddGet(new Message(text, memberName, filePath, lineNumber, type));
            if (Restriction.HasFlag(t.Type))
                Console.WriteLine(t.ToString());
        }

        /// <summary>
        /// メッセージとしてログを送信します
        /// </summary>
        /// <param name="text">メッセージ</param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public static void Information(string text, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = -1) {
            var t = AllMessages.AddGet(new Message(text, memberName, filePath, lineNumber, MessageType.Info));
            if (Restriction.HasFlag(t.Type))
                Console.WriteLine(t.ToString());
        }

        /// <summary>
        /// デバッグ情報としてログを送信します
        /// </summary>
        /// <param name="text">メッセージ</param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public static void Debug(string text, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = -1) {
            var t = AllMessages.AddGet(new Message(text, memberName, filePath, lineNumber, MessageType.Debug));
            if (Restriction.HasFlag(t.Type))
                Console.WriteLine(t.ToString());
        }

        /// <summary>
        /// 警告としてログを送信します
        /// </summary>
        /// <param name="text">メッセージ</param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public static void Warning(string text, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = -1) {
            var t = AllMessages.AddGet(new Message(text, memberName, filePath, lineNumber, MessageType.Warning));
            if (Restriction.HasFlag(t.Type))
                Console.WriteLine(t.ToString());
        }

        /// <summary>
        /// エラーとしてログを送信します
        /// </summary>
        /// <param name="text">メッセージ</param>
        /// <param name="memberName"></param>
        /// <param name="filePath"></param>
        /// <param name="lineNumber"></param>
        public static void Error(string text, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = -1) {
            var t = AllMessages.AddGet(new Message(text, memberName, filePath, lineNumber, MessageType.Error));
            if (Restriction.HasFlag(t.Type))
                Console.WriteLine(t.ToString());
        }

    }
}
