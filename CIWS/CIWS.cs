using GameLib.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris;
using RUtil;
using System.Runtime;

namespace CIWS
{

    [GameAddon(TetrisMain.ID)]
    public class CIWS : TetrisInputter
    {
        private const string NAME = "Redkun";
        public override string Name() {
            return NAME;
        }

        public override void Initialize() {

        }

        public override OperationSet Inputs(TetrisField field) {

            int maxScore = int.MinValue;
            List<OperationSet> max = new List<OperationSet>();

            // 総当たり

            //for (int n = -1; n < field.Nexts.Length; n++) {
            for (int r = -1; r <= 2; r++) {
                for (int m = -5; m < 6; m++) {
                    // 砂場
                    TetrisFieldSandBox box = new TetrisFieldSandBox(field);
                    OperationSet cur = new OperationSet();

                    cur.Store(InputCommand.RotateRight, r);
                    cur.Store(InputCommand.MoveRight, m);


                    int currentScore = Evaluation(box, cur);


                    if (maxScore == currentScore) {
                        max.Add(cur);
                    } else if (maxScore < currentScore) {
                        maxScore = currentScore;
                        max.Clear();
                        max.Add(cur);
                    }
                }
            }
            //}
            // 一番まともそうな手を返す

            return max.Random();
        }

        //public TetrisFieldSandBox fowerd() {

        //}




        public int Evaluation(TetrisFieldSandBox box, OperationSet set) {

            int evalScore = 10000;
            box.TryDrop(set);

            // 高さ一覧
            int[] heights = box.Heights().ToArray();

            // 穴の数が多いほど減点
            int[] holes = box.Holes().ToArray();
            evalScore -= ((Math.Pow(holes.Sum(), 2) / 2) * 120 * heights.Max() / 3).RoundUp();


            // 標準偏差　平坦に近いほうが正義（嘘）

            double avg = heights.Average();             // 平均
            double StandardDeviation = Math.Sqrt(heights.Select(s => Math.Pow(s - avg, 2)).Average());    // 標準偏差

            // ばらつきが多いほど減点
            evalScore -= (Math.Pow(StandardDeviation, 3) * 250).RoundUp();

            //ConsoleOut.Log($"{box.DistanceToHole().Join(", ")}");

            // ラインを消せるなら加点
            int ls = box.Clearable().Count();
            evalScore += (Math.Pow(ls, 2) * 50 + ls * 10 * heights.Max()).RoundDown();

            // 高さが高いと減点
            evalScore -= (Math.Pow((heights.Max() + 5), 2) / 2).RoundUp();

            // 個数一覧を取得
            int[] depth = box.DistanceToHole().ToArray();

            // 一番深い所に穴がある位置を取得
            int maxIndex = depth.IndexOf(depth.Min());
            evalScore -= maxIndex * 2;

            // 個数一覧を取得
            int[] count = box.ElementCount().ToArray();

            // 一番個数が多い位置を取得
            int y = count.IndexOf(count.Max());

            return evalScore;

        }
    }
}
