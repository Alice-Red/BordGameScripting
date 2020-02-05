using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib.API;
using GameLib.Core.Util;
using RUtil;
using Tetris;

namespace Experiment
{

    [GameAddon(TetrisMain.ID)]


    public class Nishiyama : TetrisInputter
    {

        // 名前
        const string NAME = "Nishiyama";

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
            for (int r = 0; r < 4; r++) {
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
            if (3 <= holes.Sum()) {
                evalScore -= (holes.Sum()) * 10;
            }

            // 標準偏差でばらつきを見る

            // 高さ一覧
            int[] heights = box.Heights().ToArray();
            if (heights.Sum() - heights.Max() == 4 && heights.Max() - heights.Sum() == 4) {
                evalScore -= (heights.Max()) * 100;
            }

            // 平均
            double avg = heights.Average();

            // 標準偏差
            double StandardDeviation = Math.Sqrt(heights.Select(s => Math.Pow(s - avg, 2)).Average());

            // ばらつきが多いほど減点
            evalScore -= (int) (StandardDeviation) * 10;


            // ラインを消せるなら加点
            int ls = box.Clearable().Count();
            evalScore += ((int) Math.Pow(ls, 2)) * 20;

            // 一番浅いところにある穴の位置を取得
            // 個数一覧を取得
            int[] count = box.ElementCount().ToArray();
            int minIndex = count.IndexOf(count.Min());
            if (minIndex <= 8) {
                evalScore -= (minIndex) * 20;
            }

            // 一番深いところにある穴の位置を取得
            int[] depth = box.DistanceToHole().ToArray();
            int maxIndex = depth.IndexOf(depth.Max());
            if (maxIndex == 0) {
                evalScore += (maxIndex) * 100;
            }


            return evalScore;

        }


    }
}
