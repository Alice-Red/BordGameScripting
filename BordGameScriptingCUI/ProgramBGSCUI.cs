﻿#define NO_MAIN

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BordGameScriptingCUI
{
    class ProgramBGSCUI
    {
        static void Main(string[] args) {

#if NO_MAIN
            debug d = new debug();
            Console.ReadKey(true);
#else
            GameMain main = new GameMain();
            Console.ReadKey(true);
#endif

        }
    }
}
