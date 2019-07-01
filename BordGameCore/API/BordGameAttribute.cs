using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.API
{

    [AttributeUsage(AttributeTargets.Class)]
    public class BordGameAttribute : Attribute
    {
        public string GameID { get; set; }
        //public IDrawer Drawer { get; set; }


        public BordGameAttribute(string gameid) {
            GameID = gameid;
        }

        public void Nendo() {

        }

    }
}
