using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RUtil;
using Tetris;

namespace BordGameScriptingCUI
{
    class debug
    {
        public debug() {
            string text = "";
            MinoGenerator gen = new MinoGenerator(24);
            Dictionary<Mino, int> count = new Dictionary<Mino, int>();


            while (text == "") {
                Console.WriteLine(gen.Generate());
                if (!count.ContainsKey(gen.Current))
                    count.Add(gen.Current, 0);
                count[gen.Current]++;

                text = Console.ReadLine();
            }

            foreach (var t in count) {
                Console.WriteLine($"{t.Key} : {t.Value}");
            }

        }
    }
}
