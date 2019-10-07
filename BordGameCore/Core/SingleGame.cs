using GameLib.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.Core
{
    public class SingleGame : Game
    {

        protected int Loser = 0;
        protected int turn = 1;
        protected bool Running = false;
        private bool Inited = true;
        public GameField Field;


        public delegate void OnDrawHandler(Game sender, OnDrawArgs e);
        public event OnDrawHandler OnDraw;



        public override void Run() {
            if (Running)
                return;
            Start();
            if (Inited == false)
                return;
            OnDraw(this, new OnDrawArgs());
            do {
                UpDate();
                OnDraw(this, new OnDrawArgs());
            } while (Loser == 0);
            End();
        }

        public void Start() {

        }

        public void UpDate() {

        }

        public void End() {

        }

    }
}
