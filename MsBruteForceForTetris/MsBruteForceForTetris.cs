using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib.API;
using GameLib.Core.Util;
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


            int maxScore = int.MinValue;
            List<OperationSet> max = new List<OperationSet>();

            // 総当たり
            // とても雑
            for (int r = -1; r < 2; r++) {
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

            // 一番まともそうな手を返す
            var res = max.Random();
            //OperationSet Result = new OperationSet();

            //Result.Store(res.Commands[0].value < 0 ? InputCommand.RotateLeft : InputCommand.RotateRight, Math.Abs(res.Commands[0].value));
            //Result.Store(res.Commands[1].value < 0 ? InputCommand.MoveLeft : InputCommand.MoveRight, Math.Abs(res.Commands[1].value));

            return res;
        }

        public int Evaluation(TetrisFieldSandBox box, OperationSet set) {

            int evalScore = 10000;
            box.TestTry(set);


            // 穴の数が多いほど減点
            int[] holes = box.Holes().ToArray();
            evalScore -= (holes.Sum());


            // 標準偏差　平坦に近いほうが正義（嘘）

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
            evalScore -= (int) (Math.Abs(dispersion));

            //ConsoleOut.Log($"{box.DistanceToHole().Join(", ")}");

            // ラインを消せるなら加点
            int ls = box.Clearable().Count();
            evalScore += ((int) Math.Pow(ls, 2));


            return evalScore;

        }



    }
}
