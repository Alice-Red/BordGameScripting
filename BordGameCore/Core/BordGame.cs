using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        protected bool Inited = true;
        public GridField Field;
        protected IInputObjectContainer current;
        public GameInputter PL1;
        public GameInputter PL2;
        protected IDrawer Drawer;

        public delegate void OnDrawHandler(Game sender, OnDrawArgs e);
        public event OnDrawHandler OnDraw;

        public BordGame() {
            //Inited = false;
        }


        public override void Run() {
            if (Running)
                return;
            
            if (Inited == false)
                return;
            Start();
            do {
                Running = true;
                UpDate();
            } while (Loser == 0);
            Running = false;
            End();
        }

        public abstract void Start();

        public abstract void UpDate();

        public abstract void End();

    }
}
