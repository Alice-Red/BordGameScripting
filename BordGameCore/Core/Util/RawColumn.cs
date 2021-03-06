﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GameLib.API;
using RUtil;

namespace GameLib.Core.Util
{
    public struct RawColumn : IInputObjectContainer, IComparable<RawColumn>,IGamePoint
    {
        public int Raw { get; set; }

        public int Column { get; set; }

        public int X { get => Column; set => Column = value; }

        public int Y { get => Raw; set => Raw = value; }

        public int Width { get => Column; set => Column = value; }

        public int Height { get => Raw; set => Raw = value; }

        public int Horizontal { get => Column; set => Column = value; }

        public int Vertical { get => Raw; set => Raw = value; }

        public (int, int) Tuple => (this.Raw, this.Column);

        // 数値直入力
        public RawColumn(int Raw, int Column) {
            this.Raw = Raw;
            this.Column = Column;
        }

        // タプル入力
        public RawColumn((int, int) value) {
            this.Raw = value.Item1;
            this.Column = value.Item2;
        }

        // 複製
        public RawColumn(RawColumn value) {
            this.Raw = value.Raw;
            this.Column = value.Raw;
        }

        public override string ToString() {
            return string.Format($"({this.Raw}, {this.Column})");
        }

        public override bool Equals(object obj) {
            return obj is RawColumn column &&
                   Raw == column.Raw &&
                   Column == column.Column;
        }

        public override int GetHashCode() {
            var hashCode = -1684758400;
            hashCode = hashCode * -1521134295 + Raw.GetHashCode();
            hashCode = hashCode * -1521134295 + Column.GetHashCode();
            return hashCode;
        }

        public static RawColumn New(int Raw, int Column) {
            return new RawColumn(Raw, Column);
        }

        public static RawColumn New((int, int) value) {
            return new RawColumn(value);
        }

        public static RawColumn New(RawColumn value) {
            return new RawColumn(value);
        }

        public int CompareTo(RawColumn other) {
            if (other.Raw < Raw) {
                return -1;
            } else if (other.Raw > Raw) {
                return 1;
            } else {
                if (other.Column < Column) {
                    return -1;
                } else if (other.Column > Column) {
                    return 1;
                } else {
                    return 0;
                }
            }
        }

        int IGamePoint.X() {
            return X;
        }

        int IGamePoint.Y() {
            return Y;
        }

        public static RawColumn operator +(RawColumn left, RawColumn right) {
            return new RawColumn(left.Raw + right.Raw, left.Column + right.Column);
        }

        public static RawColumn operator -(RawColumn left, RawColumn right) {
            return new RawColumn(left.Raw - right.Raw, left.Column - right.Column);
        }

        public static RawColumn operator +(RawColumn left, int right) {
            return new RawColumn(left.Raw + right, left.Column + right);
        }

        public static RawColumn operator -(RawColumn left, int right) {
            return new RawColumn(left.Raw - right, left.Column - right);
        }

        public static RawColumn operator *(RawColumn left, int right) {
            return new RawColumn(left.Raw * right, left.Column * right);
        }

        public static bool operator ==(RawColumn left, RawColumn right) {
            return (left.Raw == right.Raw && left.Column == right.Column);
        }

        public static bool operator !=(RawColumn left, RawColumn right) {
            return (left.Raw != right.Raw || left.Column != right.Column);
        }

        public static bool operator <(RawColumn left, RawColumn right) {
            return (left.Raw < right.Raw || (left.Raw == right.Raw && left.Column < right.Column));
        }
        public static bool operator <=(RawColumn left, RawColumn right) {
            return (left.Raw < right.Raw || (left.Raw == right.Raw && left.Column <= right.Column));
        }
        public static bool operator >(RawColumn left, RawColumn right) {
            return (left.Raw > right.Raw || (left.Raw == right.Raw && left.Column > right.Column));

        }
        public static bool operator >=(RawColumn left, RawColumn right) {
            return (left.Raw > right.Raw || (left.Raw == right.Raw && left.Column >= right.Column));
        }

    }

    public static class RawColumnUtil
    {
        public static T FromRC<T>(this T[,] source, RawColumn rc, T defaultValue = default(T)) {
            if (rc.Raw.InBetween(0, source.GetLength(0) - 1) && rc.Column.InBetween(0, source.GetLength(1) - 1))
                return source[rc.Raw, rc.Column];
            else
                return defaultValue;

        }

        public static bool Include(this RawColumn[] source, RawColumn[] target, bool strict = false) {
            var sequence = source.ToList();
            for (int i = 0; i < target.Length; i++) {
                if (!sequence.Contains(target[i]))
                    return false;
                sequence.Remove(target[i]);
            }
            return true;
        }

    }



}
