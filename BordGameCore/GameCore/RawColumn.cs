using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BordGameCore.GameCore
{
    class RawColumn
    {
        public int Raw { get; set; }
        public int Column { get; set; }

        public RawColumn() {
            this.Raw = 0;
            this.Column = 0;
        }

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

        public int GetX() {
            return Column;
        }

        public int GetY() {
            return Raw;
        }

        public int GetW() {
            return Column;
        }

        public int GetH() {
            return Raw;
        }

        public (int, int) Tuple() {
            return (this.Raw, this.Column);
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

        public static RawColumn operator +(RawColumn left, RawColumn right) {
            return new RawColumn(left.Raw + right.Raw, left.Column + right.Column);
        }

        public static RawColumn operator -(RawColumn left, RawColumn right) {
            return new RawColumn(left.Raw - right.Raw, left.Column - right.Column);
        }

        public static bool operator ==(RawColumn left, RawColumn right) {
            return (left.Raw == right.Raw && left.Column == right.Column);
        }

        public static bool operator !=(RawColumn left, RawColumn right) {
            return (left.Raw != right.Raw || left.Column != right.Column);
        }

    }
}
