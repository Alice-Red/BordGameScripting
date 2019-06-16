using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BordGameCore.API;

namespace BordGameCore.GameCore
{
    public abstract class BordGame
    {
        protected int Loser = 0;
        protected bool Running = false;
        public IField Field;

        public void Run() {
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

        protected abstract void Input();

        protected abstract void Process();

        protected abstract void Draw();

        protected abstract void Result();

        protected abstract void Next();

    }
}
