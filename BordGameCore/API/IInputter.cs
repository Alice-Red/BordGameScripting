using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib.Core.Base;

namespace GameLib.API
{
    public interface IInputter
    {
        string Name();

        IInputObjectContainer Input(GridField field);

    }
}
