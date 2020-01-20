using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RUtil;

namespace Tetris
{
    public class CommandStruct
    {
        public string Head;
        public Dictionary<string, string[]> Values = new Dictionary<string, string[]>();

        public CommandStruct(string value) {
            var ar = value.Split('|').ToArray();
            Head = ar.FirstOrDefault();

            for (int i = 1; i < ar.Length; i++) {
                if (ar[i].Contains(',')) {
                    var tmp = ar[i].Split(':');
                    if (!Values.ContainsKey(tmp.FirstOrDefault()))
                        Values.Add(tmp.FirstOrDefault(), tmp.LastOrDefault().Split(','));
                } else {
                    var tmp = ar[i].Split(':');
                    if (!Values.ContainsKey(tmp.FirstOrDefault()))
                        Values.Add(tmp.FirstOrDefault(), tmp.LastOrDefault().Split(','));
                }
            }
        }

        public new string ToString() {
            return new string[] { Head }.Concat(Values.Select(s => s.Key + ":" + s.Value.Join(","))).Join("|");
        }

    }
}
