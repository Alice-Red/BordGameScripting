using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.API
{
    public interface IGameDrawInterface
    {

        void GDrawLine(IGamePoint point1, IGamePoint point2);
        void GDrawRect(IGamePoint point1, IGamePoint point2);
        void GFillLine(IGamePoint point1, IGamePoint point2);
        void GFillRect(IGamePoint point1, IGamePoint point2);
        void GDrawArc(IGamePoint point1, IGamePoint point2);
        void GFillArc(IGamePoint point1, IGamePoint point2);
        void GDrawText(IGamePoint point1, IGamePoint point2);
        void GDrawPoint(IGamePoint point1, IGamePoint point2);

    }
}
