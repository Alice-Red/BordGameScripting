using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BordGameCore.GameCore;

namespace BordGameCore.API
{
    public interface IInputter
    {
        string Name();

        IInputObjectContainer Input(GridField field);

    }
}
