using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.API
{

    [AttributeUsage(AttributeTargets.Class)]
    public class GameAddonAttribute : Attribute
    {
        public string GameID { get; set; }
        //public IDrawer Drawer { get; set; }


        public GameAddonAttribute(string gameid) {
            GameID = gameid;
        }

        public void Nendo() {

        }

    }
}
