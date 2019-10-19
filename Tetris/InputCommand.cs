using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public enum InputCommand
    {
        None        = 0,
        HardDrop    = 1,
        WaitDrop    = 2,
        MoveLeft    = 3,
        MoveRight   = 4,
        RotateLeft  = 5,
        RotateRight = 6,
        Hold        = 7,

        Command     = 9,

    }
}
