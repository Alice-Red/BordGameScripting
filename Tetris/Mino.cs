using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public enum Mino
    {
        O = 1,
        T = 2,
        I = 3,
        L = 4,
        J = 5,
        S = 6,
        Z = 7,
    }

    public class Minos
    {
        public static readonly int[,] O = new int[,] {
            { 0, 0, 0, 0 },
            { 0, 1, 1, 0 },
            { 0, 1, 1, 0 },
            { 0, 0, 0, 0 },
        };
        public static readonly int[,] T = new int[,] {
            { 0, 0, 0, 0 },
            { 0, 1, 1, 1 },
            { 0, 0, 1, 0 },
            { 0, 0, 0, 0 },
        };
        public static readonly int[,] I = new int[,] {
            { 0, 0, 1, 0 },
            { 0, 0, 1, 0 },
            { 0, 0, 1, 0 },
            { 0, 0, 1, 0 },
        };
        public static readonly int[,] L = new int[,] {
            { 0, 1, 0, 0 },
            { 0, 1, 0, 0 },
            { 0, 1, 1, 0 },
            { 0, 0, 0, 0 },
        };
        public static readonly int[,] J = new int[,] {
            { 0, 0, 1, 0 },
            { 0, 0, 1, 0 },
            { 0, 1, 1, 0 },
            { 0, 0, 0, 0 },
        };
        public static readonly int[,] S = new int[,] {
            { 0, 0, 0, 0 },
            { 0, 0, 1, 1 },
            { 0, 1, 1, 0 },
            { 0, 0, 0, 0 },
        };
        public static readonly int[,] Z = new int[,] {
            { 0, 0, 0, 0 },
            { 0, 1, 1, 0 },
            { 0, 0, 1, 1 },
            { 0, 0, 0, 0 },
        };

        public static readonly Dictionary<Mino, int[,]> MinoP = new Dictionary<Mino, int[,]>() {
           { Mino.O, O },
           { Mino.T, T },
           { Mino.I, I },
           { Mino.L, L },
           { Mino.J, J },
           { Mino.S, S },
           { Mino.Z, Z },
        };


    }


}
