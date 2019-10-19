using GameLib.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RUtil;

namespace Tetris
{
    public class OperationSet : IInputObjectContainer
    {
        public List<Command> cmds = new List<Command>();

        public Command[] Commands {
            get { return cmds.ToArray(); }
        }

        public string player;

        public void Store(InputCommand command) {
            if (((int) command).Any(1, 2))
                cmds.Add(new Command(command, 0));
        }

        public void Store(InputCommand command, int num) {
            if (((int) command).Any(3, 4, 5, 6)) {
                cmds.Add(new Command(command, num));
            }
        }

        public void Store(InputCommand command, string message) {
            if (((int) command).Any(0, 9)) {
                cmds.Add(new Command(command, message));
            }
        }
    }
}
