using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib.API;
using Tetris;

namespace MsBruteForceForTetris
{
    [GameAddon(TetrisMain.ID)]
    public class MsBruteForceForTetris : TetrisInputter
    {

        const string NAME = "Ms.Brute Force";

        public override string Name() {
            // 自己紹介
            return NAME;
        }

        public override void Initialize() {
            // 今回はここは何もなし
        }

        public override OperationSet Inputs(TetrisField field) {
            // 砂場
            TetrisFieldSandBox box = new TetrisFieldSandBox(field);

            int maxScore = 0;
            OperationSet max = new OperationSet();

            // 総当たり
            for (int r = -2; r < 2; r++) {
                for (int m = -5; m < 5; m++) {
                    OperationSet cur = new OperationSet();
                    cur.Store(InputCommand.RotateRight, r);
                    cur.Store(InputCommand.MoveRight, m);

                    int currentScore = Evaluation(box, cur);

                    if (maxScore < currentScore) {
                        maxScore = currentScore;
                        max = cur;
                    }

                }
            }

            // 一番まともそうな手を返す
            return max;
        }

        public int Evaluation(TetrisFieldSandBox box, OperationSet set) {

            int evalScore = 500;
            box.TestTry(set);


            // 穴の数 * 20 点　減点
            int[] holes = box.Holes().ToArray();
            evalScore -= (holes.Sum() * 20);


            // 標準偏差　平坦に近いほうがよさげ

            // 高さ一覧
            int[] heights = box.Heights().ToArray();


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
            evalScore -= (int)(StandardDeviation * 100);

            return evalScore;

        }



    }
}
