using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.DynamicProgramming.TypicalDPProblems
{
    public class StockTradingProblems3Ddp
    {
        //188、买卖股票的最佳时机IV（交易次数k，框架）

        /*
         * 利用「状态」进行穷举
         每天都有三种「选择」：买入、卖出、无操作，我们用 buy, sell, rest 表示这三种选择。
         三维数组dp：
         dp[i][k][0 or 1]
         第一个状态i:表示天数
         第二个状态k:表示当天允许交易的最大次数
         第三个状态：为当前持有的状态（即rest的状态，用1表示持有，0表示没有持有）
         
        dp[i][k][0 or 1]
        0 <= i <= n-1, 1 <= k <= K
        n为天数，大K为最多交易次数
        此问题共n * K * 2 中交易状态，全部穷举即可。

        for 0 <= i <= n:
            for 1 <= k <= K:
                for s in {0, 1}:
                    dp[i][k][s] = max(buy, sel, rest)

        我们想要的最终答案是dp[n-1][K][0]，即最后一天，最多允许K次交易，所能获取的最大利润。

        状态转移方程：
        dp[i][k][0] = max(dp[i-1][k][0], dp[i-1][k][1] + prices[i])
                      max(选择rest      , 选择sell                 )

        解释：今天我没有持有股票，有两种可能：
        要么是我昨天就没有持有，然后今天选择rest，所以我今天还是没有持有；
        要么是我昨天持有股票，但是今天我sell了，索引我今天没有持有股票了。

        dp[i][k][1] = max(dp[i-1][k][1], dp[i-1][k-1][0] - prices[i])
                      max(选择rest      , 选择buy                    )

        解释：今天我持有着股票，有两种可能：
        要么我昨天持有着股票，然后今天选择rest，所以我今天还持有着股票；
        要么我昨天本没有持有，但今天我选择buy，所以今天我就持有股票了。


        注意k的限制，我们在buy的时候把最大交易次数减小了1，当然也可以在sell的时候减1，一样的。

        定义base case：
        dp[-1][k][0] = 0
        解释：因为i是从0开始的，所以 i = -1 意味着还没有开始，这时候利润当然是0。

        dp[-1][k][1] = -infinity
        解释：还没开始的时候，是不能持有股票的，用负无穷表示这种不可能。

        dp[i][0][0] = 0
        解释：因为k是从1开始的，所以 k = 0 意味着根本不允许交易，这时候利润当然是0。

        dp[i][0][1] = -infinity
        解释：不允许交易的情况下，是不可能持有股票的，用负无穷表示这种不可能。
        
        状态转移方程总结：
        dp[-1][k][0] = 0
        dp[-1][k][1] = -infinity

        dp[i][k][0] = max(dp[i-1][k][0], dp[i-1][k][1] + prices[i])
        dp[i][k][1] = max(dp[i-1][k][1], dp[i-1][k-1][0] - prices[i])

         */


        //121、买卖股票的的最佳时机(一次交易：k=1)
        /*
        dp[-1][0] = 0
        dp[-1][1] = -infinity

        dp[i][0] = max(dp[i-1][0], dp[i-1][1] + prices[i])
        dp[i][1] = max(dp[i-1][1], - prices[i])
         */


        /*
         直接翻译成代码：

        int n = prices.Length;            
        int[,] dp = new int[n, 2];
        for(int i = 0; i < n; i++)
        {
            dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i]);
            dp[i, 1] = Math.Max(dp[i - 1, 1], -prices[i]);
        }
        return dp[n - 1, 0];

        * i = 0 时 dp[i-1] 是不合法的，因为我们没有对 i 的 base case 进行处理。

        for(int i = 0; i < n; i++)
        {
            if(i - 1 == -1)
            {
                dp[i, 0] = 0;
                //解释：
                // dp[i,0]
                // = max(dp[-1,0], dp[-1,1] + prices[i]) 
                // = max(0, -infinity + prices[i])
                // = 0
                dp[i, 1] = -prices[i];
                //解释：
                // dp[i,1]
                // = max(dp[-1,1], dp[-1,0] - prices[i])
                // = max(-infinity, 0 - prices[i])
                // = -prices[i]
                continue;
            }
            dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i]);
            dp[i, 1] = Math.Max(dp[i - 1, 1], -prices[i]);
        }
        return dp[n - 1, 0];


        但这样处理 base case 很麻烦，而且注意一下状态转移方程，
        新状态只和相邻的一个状态有关，其实不用整个 dp 数组，
        只需要两个变量储存所需的状态就足够了，这样可以把空间复杂度降到 O(1):

         */
        public int MaxProfit_k_1(int[] prices)
        {
            if (prices == null || prices.Length == 0)
                return 0;
            int n = prices.Length;
            // base case: dp[-1,0] = 0, dp[-1,1] = -infinity
            int dp_i_0 = 0, dp_i_1 = int.MinValue;
            for(int i = 0; i < n; i++)
            {
                //dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] + prices[i]);
                dp_i_0 = Math.Max(dp_i_0, dp_i_1 + prices[i]);
                //dp[i, 1] = Math.Max(dp[i - 1, 1], -prices[i]);
                dp_i_1 = Math.Max(dp_i_1, -prices[i]);
            }

            return dp_i_0; 
        }


        //122、买卖股票的最佳时机II（不限交易次数）
        /*
        不限交易次数： k = +infinity
        k为正无穷，那么就可以认为 k 和 k-1 是一样的。

        框架改写：
        dp[i][k][0] = max(dp[i-1][k][0], dp[i-1][k][1] + prices[i])
        dp[i][k][1] = max(dp[i-1][k][1], dp[i-1][k-1][0] - prices[i])
                      max(dp[i-1][k][1], dp[i-1][k][0] - prices[i])

        数组中 k 不会改变，也就是说不需要记录 k 这个状态了：
        dp[i][0] = max(dp[i-1][0], dp[i-1][1] + prices[i])
        dp[i][1] = max(dp[i-1][1], dp[i-1][0] - prices[i])

         */

        public int MaxProfit_k_inf(int[] prices)
        {
            if (prices == null || prices.Length == 0)
                return 0;
            int n = prices.Length;
            int dp_i_0 = 0, dp_i_1 = int.MinValue;
            for(int i = 0; i < n; i++)
            {
                int temp = dp_i_0;
                dp_i_0 = Math.Max(dp_i_0, dp_i_1 + prices[i]);
                dp_i_1 = Math.Max(dp_i_1, temp - prices[i]);
            }
            return dp_i_0;
        }



        //309、买卖股票的最佳时机含冷冻期（不限交易次数）
        /*
        每次 sell 之后要等一天才能交易
        状态转移方程：
        dp[i][0] = max(dp[i-1][0], dp[i-1][1] + prices[i])
        dp[i][1] = max(dp[i-1][1], dp[i-2][0] - prices[i])

         */
        public int MaxProfit_with_cooldown(int[] prices)
        {
            if (prices == null || prices.Length == 0)
                return 0;
            int n = prices.Length;
            int dp_i_0 = 0, dp_i_1 = int.MinValue;
            int dp_pre_0 = 0;
            for(int i = 0; i < n; i++)
            {
                int temp = dp_i_0;                
                dp_i_0 = Math.Max(dp_i_0, dp_i_1 + prices[i]);
                dp_i_1 = Math.Max(dp_i_1, dp_pre_0 - prices[i]);
                dp_pre_0 = temp;
            }
            return dp_i_0;
        }

        //714、买卖股票的最佳时机含手续费（不限交易次数）
        //每次交易需要手续费，只需要把手续费从利润里减去即可：
        /*
        状态转移方程：
        dp[i][0] = max(dp[i-1][0], dp[i-1][1] + prices[i])
        dp[i][1] = max(dp[i-1][1], dp[i-1][0] - prices[i] - fee)
         */

        public int MaxProfit_with_fee(int[] prices, int fee)
        {
            if (prices == null || prices.Length == 0)
                return 0;
            int n = prices.Length;
            int dp_i_0 = 0, dp_i_1 = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                int temp = dp_i_0;
                dp_i_0 = Math.Max(dp_i_0, dp_i_1 + prices[i]);
                dp_i_1 = Math.Max(dp_i_1, temp - prices[i] - fee);
            }
            return dp_i_0;
        }

        //123、买卖股票的最佳时机III(交易次数为2)
        /*
         由于没有消掉 k 的影响，所以必须要用 for 循环对 k 进行穷举才行：

        int max_k = 2;
        int[][][] dp = new int[n][max_k + 1][2];
        for(int i = 0; i < n; i++){
            for(int k = max_k; k >= 1; k--){
                if(i - 1 == -1){ // 处理 base case }
                dp[i][k][0] = max(dp[i-1][k][0], dp[i-1][k][1] + prices[i])
                dp[i][k][1] = max(dp[i-1][k][1], dp[i-1][k-1][0] - prices[i])
            }
        }
        //穷举了 n * max_k * 2 个状态
        return dp[n-1][max_k][0];


        这里因为 k 的取值范围比较小，可以不用 for 循环，
        直接把 k = 1 和 2 的情况手动列出来：

        dp[i][2][0] = max(dp[i-1][2][0], dp[i-1][2][1] + prices[i])
        dp[i][2][1] = max(dp[i-1][2][1], dp[i-1][1][0] - prices[i])
        dp[i][1][0] = max(dp[i-1][1][0], dp[i-1][1][1] + prices[i])
        dp[i][1][1] = max(dp[i-1][1][1], - prices[i])
         

         */
        public int MaxProfit_k_2(int[] prices)
        {
            if (prices == null || prices.Length == 0)
                return 0;
            int n = prices.Length;
            int dp_i10 = 0, dp_i11 = int.MinValue;
            int dp_i20 = 0, dp_i21 = int.MinValue;  // ？？？
            for (int i = 0; i < n; i++)
            {
               
                dp_i20 = Math.Max(dp_i20, dp_i21 + prices[i]);
                dp_i21 = Math.Max(dp_i21, dp_i10 - prices[i]);
                dp_i10 = Math.Max(dp_i10, dp_i11 + prices[i]);
                dp_i11 = Math.Max(dp_i11, - prices[i]);
            }
            return dp_i20;
        }



        // k = any integer
        /*
        和 k = 2 没啥区别。
        一次交易由买入和卖出构成，至少需要两天。
        所以说有效的限制次数 k 应该不超过 n/2，
        如果超过，就没有约束作用了，相当于 k = +infinity。
        
        public int MaxProfit_k_any(int max_k, int[] prices){
            int n = prices.Length;
            
            if(max_k > n / 2)
                return MaxProfit_k_inf(prices);
            
            int[][][] dp = new int[n][max_k + 1][2];
            for(int i = 0; i < n; i++){
                for(int k = max_k; k >= 1; k--){
                    if(i - 1 == -1){ // 处理 base case }
                    dp[i][k][0] = max(dp[i-1][k][0], dp[i-1][k][1] + prices[i])
                    dp[i][k][1] = max(dp[i-1][k][1], dp[i-1][k-1][0] - prices[i])
                }
            }
            return dp[n-1][max_k][0];
        }

         */

        public int MaxProfit_k_any(int k, int[] prices)
        {
            if (prices == null || prices.Length == 0)
                return 0;
            int n = prices.Length;

            if (k > n / 2)
                return MaxProfit_k_inf(prices);

            int[,,] dp = new int[n, k + 1, 2];

            for (int j = 1; j <= k; j++)
            {
                dp[0, j, 0] = 0;
                dp[0, j, 1] = -prices[0];
            }

            for (int i = 1; i < n; i++)
            {
                for (int j = k; j >= 1; j--)
                {
                    dp[i, j, 0] = Math.Max(dp[i - 1, j, 0], dp[i - 1, j, 1] + prices[i]);
                    dp[i, j, 1] = Math.Max(dp[i - 1, j, 1], dp[i - 1, j - 1, 0] - prices[i]);
                }
            }
            return dp[n - 1, k, 0];
        }


        public int MaxProfit_k_any_1(int k, int[] prices)
        {
            if (prices == null || prices.Length == 0)
                return 0;
            int n = prices.Length;

            if (k > n / 2)
                return MaxProfit_k_inf(prices);

            int[,,] dp = new int[n, k + 1, 2];

            for (int i = 0; i < n; i++)
            {
                for (int j = k; j >= 1; j--)
                {
                    if (i - 1 == -1)
                    {                        
                        dp[i, j, 0] = 0;
                        dp[i, j, 1] = int.MinValue;
                        continue;
                    }
                    dp[i, j, 0] = Math.Max(dp[i - 1, j, 0], dp[i - 1, j, 1] + prices[i]);
                    dp[i, j, 1] = Math.Max(dp[i - 1, j, 1], dp[i - 1, j - 1, 0] - prices[i]);
                }
            }
            return dp[n - 1, k, 0];
        }














    }
}
