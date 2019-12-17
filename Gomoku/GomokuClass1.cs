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

        public Gomoku() {

        }

        public override void End() {

        }

        public override void Start() {
            this.Drawer = new GomokuDraw();
            Field = new GomokuField();
        }

        public override void StorePlayer(params GameInputter[] players) {

        }

        public override void UpDate() {
            var tmpObject = (GomokuInputObject) current;

            if (((GomokuField) Field).Canput(new RawColumn(tmpObject.Raw, tmpObject.Column), turn)) {
                ((GomokuField) Field).OverWrite(new RawColumn(tmpObject.Raw, tmpObject.Column), turn);
                turn *= -1;
            }

            var reslut = ((GomokuField) Field).Connected(5);
            if (reslut.Count() >= 1) {
                Loser = reslut.First().Player.Reverse().ToInt();
            }

        }

    }
}
