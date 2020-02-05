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

namespace Experiment
{
    [GameAddon(TetrisMain.ID)]
    public class Fujiyama : TetrisInputter
    {

        // 名前
        const string NAME = "Fujiyama";

        public override string Name() {
            // 自己紹介
            return NAME;
        }

        public override void Initialize() {
            // 今回はここは何もなし
        }

        public override OperationSet Inputs(TetrisField field) {

            // 現在の最大スコア
            int maxScore = int.MinValue;

            // 同じスコア
            List<OperationSet> max = new List<OperationSet>();

            // 総当たり
            // とても雑
            for (int r = -1; r <= 2; r++) {
                for (int m = -5; m < 6; m++) {
                    // 砂場
                    TetrisFieldSandBox box = new TetrisFieldSandBox(field);
                    OperationSet cur = new OperationSet();

                    // 操作を登録
                    cur.Store(InputCommand.RotateRight, r);
                    cur.Store(InputCommand.MoveRight, m);

                    // 評価関数を呼ぶ
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

            return max.Random();
        }

        /// <summary>
        /// 評価関数
        /// </summary>
        /// <param name="box"></param>
        /// <param name="set"></param>
        /// <returns></returns>
        public int Evaluation(TetrisFieldSandBox box, OperationSet set) {

            int evalScore = 100;
            box.TryDrop(set);



            // 穴の数が多いほど減点
            int[] holes = box.Holes().ToArray();
            evalScore -= 3 * (holes.Sum());


            // 標準偏差でばらつきを見る

            // 高さ一覧
            int[] heights = box.Heights().ToArray();

            // 平均
            double avg = heights.Average();

            // 標準偏差
            double StandardDeviation = Math.Sqrt(heights.Select(s => Math.Pow(s - avg, 2)).Average());

            // ばらつきが多いほど減点
            evalScore -= (int) (StandardDeviation) * 3;

            var pos = box.CurrentPosition();
            evalScore += 2 * (pos.Column - heights[pos.Column]);

            // ラインを消せるなら加点
            int ls = box.Clearable().Count();
            evalScore += 2 * ((int) Math.Pow(ls, 2));



            return evalScore;

        }
    }
}
