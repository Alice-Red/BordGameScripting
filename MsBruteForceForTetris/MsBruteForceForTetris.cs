﻿using System;
using System.Collections.Generic;
using System.Linq;
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
            evalScore -= (holes.Sum());


            // 標準偏差でばらつきを見る
            int[] heights = box.Heights().ToArray();                    // 高さ一覧
            double avg = heights.Average();                             // 平均
            double StandardDeviation = Math.Sqrt(heights.Select(s => Math.Pow(s - avg, 2)).Average());      // 標準偏差

            // ばらつきが多いほど減点
            evalScore -= (int) (StandardDeviation);


            // ラインを消せるなら加点
            int ls = box.Clearable().Count();
            evalScore += ((int) Math.Pow(ls, 2));


            return evalScore;

        }

    }
}
