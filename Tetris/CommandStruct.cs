using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class CommandStruct
    {
        public string Head;
        public Dictionary<string, string[]> Values;

        public CommandStruct(string value) {
            var ar = value.Split('|').ToArray();
            Head = ar.FirstOrDefault();

            for (int i = 1; i < ar.Length; i++) {
                if (ar[i].Contains(',')) {
                    var tmp = ar[i].Split(':');
                    Values.Add(tmp.FirstOrDefault(), tmp.LastOrDefault().Split(','));
                }
            }

        }
    }
}
