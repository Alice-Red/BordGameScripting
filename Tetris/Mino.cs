using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris
{
    public enum Mino
    {
        None = 0,
        O = 1,
        T = 2,
        I = 3,
        L = 4,
        J = 5,
        S = 6,
        Z = 7,

        Obstacle = 9
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
            { 0, 1, 0, 0 },
            { 1, 1, 1, 0 },
            { 0, 0, 0, 0 },
        };
        public static readonly int[,] I = new int[,] {
            { 0, 0, 0, 0 },
            { 1, 1, 1, 1 },
            { 0, 0, 0, 0 },
            { 0, 0, 0, 0 },
        };
        public static readonly int[,] L = new int[,] {
            { 0, 0, 0, 0 },
            { 0, 0, 1, 0 },
            { 1, 1, 1, 0 },
            { 0, 0, 0, 0 },
        };
        public static readonly int[,] J = new int[,] {
            { 0, 0, 0, 0 },
            { 0, 1, 0, 0 },
            { 0, 1, 1, 1 },
            { 0, 0, 0, 0 },
        };
        public static readonly int[,] S = new int[,] {
            { 0, 0, 0, 0 },
            { 0, 1, 1, 0 },
            { 1, 1, 0, 0 },
            { 0, 0, 0, 0 },
        };
        public static readonly int[,] Z = new int[,] {
            { 0, 0, 0, 0 },
            { 1, 1, 0, 0 },
            { 0, 1, 1, 0 },
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

        public static readonly Dictionary<Mino, Color> Color = new Dictionary<Mino, Color>() {
           { Mino.O, System.Drawing.Color.FromArgb(255, 255, 255,   8) },
           { Mino.T, System.Drawing.Color.FromArgb(255, 182,   0, 217) },
           { Mino.I, System.Drawing.Color.FromArgb(255,  26, 208, 220) },
           { Mino.L, System.Drawing.Color.FromArgb(255, 255, 116,   0) },
           { Mino.J, System.Drawing.Color.FromArgb(255,  41,  41, 238) },
           { Mino.S, System.Drawing.Color.FromArgb(255,  88, 140,  87) },
           { Mino.Z, System.Drawing.Color.FromArgb(255, 197,  16,  16) },
           { Mino.Obstacle, System.Drawing.Color.FromArgb(255, 148,  148,  148)},
        };

    }


}
