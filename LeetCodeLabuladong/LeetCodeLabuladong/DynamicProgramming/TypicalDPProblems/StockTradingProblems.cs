using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.DynamicProgramming.TypicalDPProblems
{
    public class StockTradingProblems
    {
        //剑指offer63：股票的最大利润
        //121、买卖股票的的最佳时机


        /*穷举
         所有可能 = { 第 x 天买，第 y 天卖 }
         其中 0 <= x < len(prices), 
              x < y < len(prices)

         result = max(所有可能)
         */
        public int MaxProfitI(int[] prices)
        {
            if (prices == null || prices.Length == 0)
                return 0;
            int res = 0;
            for(int buy = 0; buy < prices.Length; buy++)
            {
                for(int sell = buy + 1; sell < prices.Length; sell++)
                {
                    res = Math.Max(res, prices[sell] - prices[buy]);
                }
            }
            return res;
        }

        //                /\
        //               /||\
        //                ||
        //固定买入时间buy，然后将buy后面的每一天作为sel进行穷举，只为寻找prices[sell]最大的那一天，因为这样prices[sell]-prices[buy]的差值才会最大
        //
        //优化：固定卖出时间sell，向前穷举买入时间buy，寻找prices[buy]最小的那天。
        //                ||
        //               \||/
        //                \/


        public int MaxProfitIup(int[] prices)
        {
            if (prices == null || prices.Length == 0)
                return 0;
            int res = 0;
            int curMin = prices[0];
            for(int sell = 1; sell < prices.Length; sell++)
            {
                curMin = Math.Min(curMin, prices[sell]);
                res = Math.Max(res, prices[sell] - curMin);
            }
            return res;
        }

        //122、买卖股票的最佳时机II

        public int MaxProfitII(int[] prices)
        {
            if (prices == null || prices.Length == 0)
                return 0;
            return Dp(prices, 0);
        }
        public int Dp(int[] prices, int start)
        {
            int n = prices.Length;
            if (start >= n)
                return 0;
            int[] memo = new int[n];
            for (int i = 0; i < n; i++)
            {
                memo[i] = -1;
            }
            if (memo[start] != -1)
                return memo[start];
            int res = 0;
            int curMin = prices[start];
            for(int sell = start + 1; sell < n; sell++)
            {
                curMin = Math.Min(curMin, prices[sell]);
                res = Math.Max(res, prices[sell] - curMin + Dp(prices, sell + 1));
            }

            return res;
        }


        //贪心算法
        public int MaxProfitIIGreedy(int[] prices)
        {
            if (prices == null || prices.Length == 0)
                return 0;
            int maxProfit = 0;
            for(int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                {
                    maxProfit += prices[i] - prices[i - 1];
                }
            }
            return maxProfit;
        }


        //123、买卖股票的最佳时机III
        //和188题类似，k具体为2了
        public int MaxProfitIII(int[] prices)
        {
            if (prices == null || prices.Length == 0)
                return 0;
            return Dp(prices, 0, 2);
        }


        //188、买卖股票的最佳时机IV

        /*
        给定一个整数数组 prices ，它的第 i 个元素 prices[i] 是一支给定的股票在第 i 天的价格。

        设计一个算法来计算你所能获取的最大利润。你最多可以完成 k 笔交易。

        注意：你不能同时参与多笔交易（你必须在再次购买前出售掉之前的股票）。

        示例 1：
        输入：k = 2, prices = [2,4,1]
        输出：2
        解释：在第 1 天 (股票价格 = 2) 的时候买入，在第 2 天 (股票价格 = 4) 的时候卖出，这笔交易所能获得利润 = 4-2 = 2 。
        
        示例 2：
        输入：k = 2, prices = [3,2,6,5,0,3]
        输出：7
        解释：在第 2 天 (股票价格 = 2) 的时候买入，在第 3 天 (股票价格 = 6) 的时候卖出, 这笔交易所能获得利润 = 6-2 = 4 。
             随后，在第 5 天 (股票价格 = 0) 的时候买入，在第 6 天 (股票价格 = 3) 的时候卖出, 这笔交易所能获得利润 = 3-0 = 3 。
         */
        public int MaxProfitIV(int k, int[] prices)
        {
            if (prices == null || prices.Length == 0)
                return 0;
            return Dp(prices, 0, k);
        }
        public int Dp(int[] prices, int start, int k)
        {
            int n = prices.Length;
            if (start >= n)
                return 0;
            if (k == 0)
                return 0;
            int[] memo = new int[n];
            for(int i = 0; i < n; i++)
            {
                memo[i] = -1;
            }
            if (memo[start] != -1)
                return memo[start];
            int res = 0;
            int curMin = prices[start];
            for(int sell = start + 1; sell < n; sell++)
            {
                curMin = Math.Min(curMin, prices[sell]);
                res = Math.Max(res, prices[sell] - curMin + Dp(prices, sell + 1, k - 1));  // k - 1
            }
            return res;
        }



        //309、买卖股票的最佳时机含冷冻期
        public int MaxProfitWithCooldown(int[] prices)
        {
            if (prices == null || prices.Length == 0)
                return 0;
            return DpCooldown(prices, 0);
        }
        public int DpCooldown(int[] prices, int start)
        {
            int n = prices.Length;
            if (start >= n)
                return 0;

            int[] memo = new int[n];
            for (int i = 0; i < n; i++)
            {
                memo[i] = -1;
            }
            if (memo[start] != -1)
                return memo[start];
            int res = 0;
            int curMin = prices[start];
            for (int sell = start + 1; sell < n; sell++)
            {
                curMin = Math.Min(curMin, prices[sell]);
                res = Math.Max(res, prices[sell] - curMin + DpCooldown(prices, sell + 2));
            }

            return res;
        }


        //714、买卖股票的最佳时机含手续费

        public int MaxProfitWithTransaction(int[] prices, int fee)
        {
            if (prices == null || prices.Length == 0)
                return 0;
            return DpTransaction(prices, 0, fee);
        }
        public int DpTransaction(int[] prices, int start, int fee)
        {
            int n = prices.Length;
            if (start >= n)
                return 0;

            int[] memo = new int[n];
            for (int i = 0; i < n; i++)
            {
                memo[i] = -1;
            }
            if (memo[start] != -1)
                return memo[start];
            int res = 0;
            int curMin = prices[start];
            for (int sell = start + 1; sell < n; sell++)
            {
                curMin = Math.Min(curMin, prices[sell]);
                res = Math.Max(res, prices[sell] - curMin - fee + DpTransaction(prices, sell + 1, fee));
            }

            return res;
        }





    }
}
