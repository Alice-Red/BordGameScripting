using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RUtil;

namespace Tetris
{
    public class TetrisFieldSandBox : TetrisField
    {
        public TetrisFieldSandBox(TetrisField f) {
            this.field = f.Field;
            this.Current = f.Current;
            this.Score = f.Score;
        }


        public void TryPut() {
            Place();
        }


        /// <summary>
        /// 試しに落とします
        /// </summary>
        /// <param name="set"></param>
        public void TryDrop(OperationSet set) {

            for (int j = 0; j < set.Commands.Length; j++) {
                switch (set.Commands[j].command) {
                    case InputCommand.MoveLeft:
                        for (int i = 0; i < Math.Abs(set.Commands[j].value); i++) {
                            Move(set.Commands[j].value < 0);
                        }
                        break;
                    case InputCommand.MoveRight:
                        for (int i = 0; i < Math.Abs(set.Commands[j].value); i++) {
                            Move(set.Commands[j].value > 0);
                        }
                        break;
                    case InputCommand.RotateLeft:
                        for (int i = 0; i < Math.Abs(set.Commands[j].value); i++) {
                            Rotate(set.Commands[j].value < 0);
                        }
                        break;
                    case InputCommand.RotateRight:
                        for (int i = 0; i < Math.Abs(set.Commands[j].value); i++) {
                            Rotate(set.Commands[j].value > 0);
                        }
                        break;
                    default:
                        break;
                }
            }
            HardDrop();
            Current.State = MainPartConfiguration.Idle;
        }

        /// <summary>
        /// 列ごとにミノの高さを数えます
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> Heights() {
            var tfield = DrawableField();
            foreach (var item in tfield.Columns()) {
                int counter = 20;
                foreach (var t2 in item) {
                    if (t2 == 0) {
                        counter -= 1;
                    } else {
                        break;
                    }
                }
                yield return counter;
            }
        }

        /// <summary>
        /// 列ごとに穴の数を数えます
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> Holes() {
            var tfield = DrawableField().Reverse().ToArray();
            var hts = Heights().ToArray();
            for (int i = 0; i < hts.Length; i++) {
                int counter = 0;
                for (int j = 0; j < hts[i] - 1; j++)
                    if (tfield[j][i] == 0) {
                        counter++;
                    }
                yield return counter;
            }
        }

        /// <summary>
        /// 列ごとに穴を無視してブロックの個数を数えます
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> ElementCount() {
            var tfield = DrawableField();
            foreach (var item in tfield.Columns())
                yield return item.Count(s => s > 0);
        }

        /// <summary>
        /// 列ごとに穴までの距離を測ります
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> DistanceToHole() {
            var holes = Holes().ToArray();
            var heights = Heights().ToArray();
            var tfield = DrawableField();

            for (int i = 0; i < holes.Length; i++) {
                if (holes[i] == 0) {
                    yield return 0;
                    continue;
                }
                for (int j = 0; j < heights[i]; j++) {
                    int index = 20 - heights[i] + j;
                    if (tfield[index][i] == 0) {
                        yield return j;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 消すことができる行を列挙します
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> Clearable() {
            var tfield = DrawableField();
            for (int i = 0; i < tfield.Length; i++) {
                if (tfield[i].All(s => s != 0))
                    yield return i;
            }
        }


        /// <summary>
        /// sizeマスの平面を探します。
        /// 無い場合はからの配列が返ります。
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public int[] ScanFlat(int size) {
            var hts = Heights().ToArray();
            List<int> result = new List<int>();
            for (int i = 0; i < hts.Length - (size - 1); i++) {
                int a = hts[i];
                bool flg = true;
                for (int j = i + 1; j < size - 1; j++) {
                    if (hts[j] != a) {
                        flg = false;
                        break;
                    }
                }
                if (flg)
                    result.Add(i);
            }
            return result.ToArray();
        }

        /// <summary>
        /// 指定した形状を探します。
        /// 無い場合はからの配列が返ります。
        /// </summary>
        /// <param name="depth">形状</param>
        /// <returns></returns>
        public int[] ScanUndulation(int[] depth) {
            var hts = Heights().ToArray();
            List<int> result = new List<int>();
            for (int i = 0; i < hts.Length - (depth.Length - 1); i++) {
                //int a= 
                bool flg = true;
                //int b = 0;
                for (int j = 0; j < depth.Length; j++) {
                    if (hts[i + j + 1] != hts[i] + depth[j]) {
                        flg = false;
                        break;
                    }
                }
                if (flg)
                    result.Add(i);
            }
            return result.ToArray();
        }


        public void Reset() {
            Current.Position = TetrisUtils.GeneratePosition;
            Current.Rotate = 0;
            Current.State = MainPartConfiguration.Floating;
        }



    }
}
