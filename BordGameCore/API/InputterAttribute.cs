using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.API
{
    [AttributeUsage(AttributeTargets.Class)]
    class InputterAttribute : Attribute
    {
        public string GameID { get; set; }

        public InputterAttribute(string gameid) {
            GameID = gameid;
        }

    }
}
