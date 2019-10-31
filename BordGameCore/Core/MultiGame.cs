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
        public override int MaxPlayer { get; } = 99;

        protected int Loser = 0;
        protected int turn = 1;
        protected bool Running = false;
        private bool Inited = true;
        public GameField Field;
        public int ServerRate = 10;
        private Stopwatch sw = new Stopwatch();

        private int serverSleep => (1000.0 / ServerRate).Round();


        protected MultiGame() {
            Inited = false;
        }

        protected MultiGame(params GameInputter[] player) {

        }

        public override void Run() {
            if (Running)
                return;
            Start();
            if (Inited == false)
                return;
            do {
                sw.Start();
                UpDate();
                sw.Stop();

                if (serverSleep - sw.ElapsedMilliseconds > 0)
                    Thread.Sleep((int) (serverSleep - sw.ElapsedMilliseconds));

            } while (Loser == 0);
            End();
        }

        public abstract void Start();

        public abstract void UpDate();

        public abstract void End();

    }
}
