using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib.API;

namespace GameLib.Core
{
    public abstract class BordGame : Game
    {
        protected int Loser = 0;
        protected int turn = 1;
        protected bool Running = false;
        public GameField Field;
        protected IInputObjectContainer current;
        protected GameInputter PL1;
        protected GameInputter PL2;
        protected IDrawer Drawer;


        public override void Run() {
            if (Running) {
                return;
            }
            Init();
            Menu();
            Draw();
            do {
                Input();
                Process();
                Draw();
            } while (Loser == 0);
            Result();
        }

        protected abstract void Init();

        protected abstract void Menu();

        protected void Input() {
            switch (turn) {
                case 1:
                    current = PL1.Input(Field);
                    break;
                case -1:
                    current = PL2.Input(Field);
                    break;
            }
        }

        protected abstract void Process();

        public void Draw() {
            Drawer.DrawConsole((Base.GridField) Field);

        }

        protected abstract void Result();

        protected abstract void Next();

    }
}
