using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLabuladong.Array
{
    public class BinarySearchApplication1
    {
        ////////////////////////  KoKo吃香蕉 //////////////////////：
        //N堆香蕉，第i堆有piles[i]根香蕉
        //H小时内吃掉所有香蕉
        //求最小速度
        //条件：Koko 每小时最多吃一堆香蕉，如果吃不下的话留到下一小时再吃；如果吃完了这一堆还有胃口，也只会等到下一小时才会吃下一堆。
        public int MinEatingSpeed875(int[] piles, int H)
        {
            int left = 1;
            int right = GetMax(piles);
            while(left <= right)
            {
                // 防止溢出
                int mid = left + (right - left) / 2;
                if (CanFinish(piles, mid, H))
                {
                    right = mid -9 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return left;
        }
        //以速度speed吃香蕉，在H小时内，能否将N堆香蕉（piles）都吃完
        public bool CanFinish(int[] piles, int speed, int H)
        {
            int time = 0;
            foreach(int n in piles)
            {
                time += TimeOf(n, speed);
            }
            return time <= H;
        }
        

        //每一堆香蕉（piles[i]）以速度speed吃，需要的时间
        public int TimeOf(int n, int speed)
        {
            //
            return (n / speed) + ((n % speed > 0) ? 1 : 0);
        }

        //求数组中元素最大值
        public int GetMax(int[] piles)
        {
            int max = 0;
            foreach(int n in piles)
            {
                max = Math.Max(max, n);
            }
            return max;
        }


        /////////////////////////  包裹运输问题  ///////////////////////
        ///


        public int ShipWithinDays1011(int[] weights, int D)
        {
            int left = GetMax(weights);
            int right = GetSum(weights);
            while(left <= right)
            {
                int mid = left + (right - left) / 2;
                if(CanFinishWeights(weights, mid, D))
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return left;
        }

        public int GetSum(int[] weights)
        {
            int sum = 0;
            foreach(int w in weights)
            {
                sum += w;
            }
            return sum;
        }

        //如果在中为cap, 能否在D天内运完货物？
        public bool CanFinishWeights(int[] weights, int cap, int D)
        {
            int i = 0;   //i为weights数组的索引
            for(int day = 1; day <= D; day++)
            {
                int maxCap = cap;
                while((maxCap -= weights[i]) >= 0)
                {
                    i++;
                    if (i == weights.Length)   //此处为weights.Length而非weights.Legnth - 1， 是因为i++操作在前。
                        return true;
                }
            }
            return false;
        }

        

    }
}
