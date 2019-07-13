using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib.API;
using GameLib.Core.Base;
using GameLib.Core.Util;
using RUtil;

namespace GameLib.Core
{
    public abstract class BordGame : Game
    {
        protected int Loser = 0;
        protected int turn = 1;
        protected bool Running = false;
        private bool Inited = true;
        public GridField Field;
        protected IInputObjectContainer current;
        protected GameInputter PL1;
        protected GameInputter PL2;
        protected IDrawer Drawer;

        public BordGame() {
            Inited = false;
        } 

        public BordGame(Type pl1, Type pl2) {
            if (!pl1.CreateInstance(typeof(GameInputter), out PL1) || pl2.CreateInstance(typeof(GameInputter), out PL2)) {
                ConsoleOut.Error("初期化に失敗しました");
                Inited = false;
            }
        }

        public void SetPlayer(Type pl1, Type pl2) {
            if (!pl1.CreateInstance(typeof(GameInputter), out PL1) || pl2.CreateInstance(typeof(GameInputter), out PL2)) {
                ConsoleOut.Error("初期化に失敗しました");
                Inited = false;
            }
        }


        public override void Run() {
            if (Running)
                return;
            Init();
            if (Inited == false)
                return;
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
