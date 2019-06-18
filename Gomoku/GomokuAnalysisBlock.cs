using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib.Core.Base;
using GameLib.Core.Util;

namespace Gomoku
{
    public struct GomokuAnalysisBlock
    {
        public RawColumn[] Items { get; }

        public int Connect;
        public RelativeName Direction;
        public RawColumn ValidPosition;

        public bool Containment(ref GomokuAnalysisBlock block) {
            if (this.Direction != block.Direction)
                return false;

            if (this.Items.Last() != block.Items.Last()) {

            }



        }




    }
}
