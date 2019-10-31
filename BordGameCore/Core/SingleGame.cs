using GameLib.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using RUtil;
using System.Diagnostics;

namespace GameLib.Core
{
    public abstract class SingleGame : Game
    {
        public override int MaxPlayer { get; } = 1;

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

        public delegate void OnInputHandler(SingleGame sender, OnInputArgs e);
        public event OnInputHandler OnInput;


        public override void Run() {
            if (Running)
                return;
            Start();
            if (Inited == false)
                return;

            OnDraw?.Invoke(this, new OnDrawArgs());
            do {
                sw.Start();
                UpDate();
                OnDraw?.Invoke(this, new OnDrawArgs());
                sw.Stop();

                if (serverSleep - sw.ElapsedMilliseconds > 0)
                    Thread.Sleep((int) (serverSleep - sw.ElapsedMilliseconds));
                sw.Reset();
            } while (Loser == 0);
            End();
        }

        public abstract void Start();

        public abstract void UpDate();

        public abstract void End();

    }
}
