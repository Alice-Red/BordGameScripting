﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RUtil;

namespace BordGameCore.GameCore.Util
{
    class Calculation
    {
        public static double Distance(RawColumn rc1, RawColumn rc2) {
            return Utility.Distance(rc1.X, rc1.Y, rc2.X, rc2.Y);
        }
    }
}
