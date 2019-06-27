using GameLib.API;
using GameLib.Core.Base;
using GameLib.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku
{
    public struct GomokuAnalysisBlock
    {
        public RawColumn[] Items { get; }

        public int Connect { get; }
        public RelativeName Direction { get; }
        public PlayerColor2P Player { get; }
        public RawColumn[] ValidPosition { get; }

        public GomokuAnalysisBlock(RawColumn[] rc, RelativeName relative, PlayerColor2P player) {
            Items = rc;
            Connect = rc.Length >= 1 && rc.All(s => s == rc[0]) ? rc.Length : 0;
            Direction = relative;
            Player = player;
            ValidPosition = new RawColumn[]{
                new RawColumn(rc.First() - Relative.Position[relative]),
                new RawColumn(rc.First() + Relative.Position[relative]),
            };

        }

        public bool Containment(ref GomokuAnalysisBlock block) {
            if (Direction != block.Direction)
                return false;

            if (Items.Last() != block.Items.Last())
                return false;

            if (!Items.Include(block.Items))
                return false;

            return true;
        }



    }
}
