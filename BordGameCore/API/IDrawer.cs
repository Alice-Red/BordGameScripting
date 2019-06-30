using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib.Core.Base;


namespace GameLib.API
{
    public abstract class ADrawer
    {
        abstract public void DrawPanel(GridField field);

        abstract public void DrawConsole(GridField field);

    }
}
