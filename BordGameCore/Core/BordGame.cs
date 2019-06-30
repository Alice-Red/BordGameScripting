﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib.API;

namespace GameLib.Core
{
    public abstract class BordGame : BordGameAttribute, IGame
    {
        protected int Loser = 0;
        protected int turn = 1;
        protected bool Running = false;
        public IField Field;

        public BordGame(string gameid, ADrawer drawer) : base(gameid, drawer) {
        }

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

        public void Draw() {

        }

        protected abstract void Result();

        protected abstract void Next();

    }
}
