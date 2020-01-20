using GameLib.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris;
using RUtil;

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
            TetrisFieldSandBox box = new TetrisFieldSandBox(field);
            //if (n >= 0)
            //    box.TryPut();
            for (int r = -1; r <= 2; r++) {
                for (int m = -5; m < 6; m++) {
                    // 砂場
                    box.Reset();
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

        public int Evaluation(TetrisFieldSandBox box, OperationSet set) {

            int evalScore = 10000;
            box.TryDrop(set);

            // 高さ一覧
            int[] heights = box.Heights().ToArray();

            // 穴の数が多いほど減点
            int[] holes = box.Holes().ToArray();
            evalScore -= ((Math.Pow(holes.Sum(), 2) / 2) * 20 * heights.Max() / 2).RoundUp();


            // 標準偏差　平坦に近いほうが正義（嘘）



            // 標準偏差の求め方
            // 1.平均値を求める
            double avg = heights.Average();

            // 2.偏差（数値 － 平均値）を求める
            double[] deviation = new double[heights.Length];
            for (int i = 0; i < deviation.Length; i++) {
                deviation[i] = heights[i] - avg;
            }

            // 3.分散（偏差の二乗平均）を求める
            double[] devipow2 = new double[deviation.Length];
            for (int i = 0; i < devipow2.Length; i++) {
                devipow2[i] = Math.Pow(deviation[i], 2);
            }
            double dispersion = devipow2.Average();

            // 4.分散の正の平方根を計算する
            double StandardDeviation = Math.Sqrt(dispersion);

            // ばらつきが多いほど減点
            evalScore -= (Math.Abs(dispersion) * 50 * Math.Abs(StandardDeviation)).RoundUp();

            //ConsoleOut.Log($"{box.DistanceToHole().Join(", ")}");

            // ラインを消せるなら加点
            int ls = box.Clearable().Count();
            evalScore += (Math.Pow(ls, 2) * 20 + TetrisUtils.BasicScore[ls] * 40 * heights.Max()).RoundDown();

            // 高さが高いと減点
            //evalScore -= Math.Pow((heights.Max() + 5), 2).RoundUp();


            return evalScore;

        }
    }
}
