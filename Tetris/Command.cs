using GameLib.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public struct Command
    {
        public InputCommand command;

        public int value;

        public string message;

        public Command(InputCommand command, int value) : this() {
            this.command = command;
            this.value = value;
            this.message = "";
        }

        public Command(InputCommand command, string message) : this() {
            this.command = command;
            this.value = 0;
            this.message = message;
        }

    }
}
