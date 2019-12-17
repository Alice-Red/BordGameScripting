using GameLib.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Command
    {
        public InputCommand command;

        public int value { get; set; }

        public string message { get; set; }

        public Command(InputCommand command, int value) {
            this.command = command;
            this.value = value;
            this.message = "";
        }

        public Command(InputCommand command, string message) {
            this.command = command;
            this.value = 0;
            this.message = message;
        }

    }
}
