using GameLib.API;
using RUtil;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameLib.Core
{
    public abstract class MultiGame : Game
    {
        protected int Loser = 0;
        protected int turn = 1;
        protected bool Running = false;
        private bool Inited = true;
        public GameField Field;
        public int ServerRate = 10;
        private Stopwatch sw = new Stopwatch();

        private int serverSleep => (1000.0 / ServerRate).Round();


        public delegate void OnDrawHandler(Game sender, OnDrawArgs e);
        public event OnDrawHandler OnDraw;

        public MultiGame() {
            Inited = false;
        }

        public MultiGame(params GameInputter[] player) {

        }


        public override void Run() {
            if (Running)
                return;
            Start();
            if (Inited == false)
                return;
            OnDraw(this, new OnDrawArgs());
            do {
                sw.Start();
                UpDate();
                OnDraw(this, new OnDrawArgs());
                sw.Stop();

                if (serverSleep - sw.ElapsedMilliseconds > 0)
                    Thread.Sleep((int) (serverSleep - sw.ElapsedMilliseconds));

            } while (Loser == 0);
            End();
        }

        public virtual void Start() {

        }

        public virtual void UpDate() {

        }

        public virtual void End() {

        }

    }
}
