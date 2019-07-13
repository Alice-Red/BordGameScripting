using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib.API;
using GameLib.Core;
using GameLib.Core.Util;


namespace Gomoku
{
    [GameAddon(ID)]
    public class Gomoku : BordGame
    {
        public const string ID = "Gomoku";

        public Gomoku(Type pl1, Type pl2) : base(pl1, pl2) {
        }

        protected override void Init() {
            this.Drawer = new GomokuDraw();
            

            //throw new NotImplementedException();
        }

        protected override void Menu() {
            
            //throw new NotImplementedException();
        }

        protected override void Next() {

            //throw new NotImplementedException();
        }

        protected override void Process() {
            if (((GomokuField) Field).Canput((RawColumn) current, turn)) {
                ((GomokuField) Field).OverWrite((RawColumn) current, turn);
                turn *= -1;
            }
            
            //throw new NotImplementedException();
        }

        protected override void Result() {
            //throw new NotImplementedException();
        }
    }
}
