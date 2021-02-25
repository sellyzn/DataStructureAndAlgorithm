using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLabuladong.DynamicProgramming
{
    public class DPFrame
    {
        /*动态规划问题的一般形式就是求最值
         * 求解动态规划的核心问题是穷举
         * 存在「重叠子问题」，如果暴力穷举效率极其低下，所以需要「备忘录」或者「DP table」来优化穷举过程
         * 动态规划问题一定会具备「最优子结构」，才能通过子问题的最值得到原问题的最值
         * 只有列出正确的「状态转移方程」才能正确地穷举
         * 重叠子问题、最优子结构、状态转移方程就是动态规划三要素
         */

        /*
         明确「状态」 -> 定义 dp 数组/函数的含义 -> 明确「选择」-> 明确 base case。
         */


        /////////////// 斐波那契数列 /////////////
        //1、暴力递归解法
        public int  Fib(int N)
        {
            if (N == 1 || N == 2)
                return 1;
            return Fib(N - 1) + Fib(N - 2);
        }

        //但凡遇到需要递归的问题，最好都画出递归树，这对分析算法的复杂度，寻找算法低效的原因都有巨大帮助。
        //                ||
        //               \||/
        //                \/
        //递归算法的时间复杂度计算：子问题个数乘以解决一个子问题需要的时间。
        //时间复杂度：O（2^n）

        //观察递归树，很明显算法低效的原因：存在大量重复计算。这就是动态规划问题的第一个性质：重叠子问题。

        //2、带备忘录的递归解法
        /*
         创建「备忘录」，每次算出某个子问题的答案后别急着返回，先记到「备忘录」里再返回；每次遇到一个子问题先去「备忘录」里查一查，如果发现之前已经解决过这个问题了，直接把答案拿出来用，不要再耗时去计算了。

         一般使用一个数组充当这个「备忘录」，当然也可以使用哈希表（字典），思想都是一样的。
         */

        public int FibMemo(int N)
        {
            if (N < 1)
                return 0;
            //备忘录全初始化为0
            int[] memo = new int[N + 1];
            for(int i = 0; i <= N; i++)
            {
                memo[i] = 0;
            }
            //初始化最简情况
            return Helper(memo, N);
        }
        public int Helper(int[] memo, int n)
        {
            //base case
            if (n == 1 || n == 2)
                return 1;
            //已经计算过
            if (memo[n] != 0)
                return memo[n];
            memo[n] = Helper(memo, n - 1) + Helper(memo, n - 2);
            return memo[n];
        }
        //时间复杂度为：o(n)

        /*
        带备忘录的递归解法的效率已经和迭代的动态规划一样了。
        实际上，这种解法和迭代的动态规划思想已经差不多，
        只不过这种方法叫做「自顶向下」，动态规划叫做「自底向上」。

        啥叫「自顶向下」？注意我们刚才画的递归树（或者说图），
        是从上向下延伸，都是从一个规模较大的原问题比如说f(20)，
        向下逐渐分解规模，直到f(1)和f(2)触底，然后逐层返回答案，
        这就叫「自顶向下」。

        啥叫「自底向上」？反过来，我们直接从最底下，最简单，
        问题规模最小的f(1)和f(2)开始往上推，直到推到我们想要的答案f(20)，
        这就是动态规划的思路，
        这也是为什么动态规划一般都脱离了递归，而是由循环迭代完成计算。
         */


        //3、dp数组的迭代解法
        public  int FibIteration(int N)
        {
            int[] dp = new int[N + 1];
            for(int i = 0; i < N + 1; i++)
            {
                dp[i] = 0;
            }
            //base case
            dp[1] = dp[2] = 1;
            for(int i = 3; i <= N; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[N];
        }

        ////////////////// 凑零钱问题 //////////////////
        ///题目：给你k种面值的硬币，面值分别为c1, c2 ... ck，
        ///每种硬币的数量无限，再给一个总金额amount，
        ///问你最少需要几枚硬币凑出这个金额，如果不可能凑出，算法返回 -1

        //1、暴力递归

        //要符合「最优子结构」，子问题间必须互相独立.

        /*
         动态规划问题，关键是如何列出正确的状态转移方程。

        1、先确定「状态」，也就是原问题和子问题中变化的变量。
           由于硬币数量无限，所以唯一的状态就是目标金额amount。

        2、确定dp函数的定义：函数 dp(n)表示，当前的目标金额是n，至少需要dp(n)个硬币凑出该金额。

        3、确定「选择」并择优，也就是对于每个状态，可以做出什么选择改变当前状态。
           具体到这个问题，无论当的目标金额是多少，选择就是从面额列表coins中选择一个硬币，然后目标金额就会减少
         
         # 伪码框架
        def  CoinChange(int[] coins, int amount){
            # 定义：要凑出金额n，至少要dp(n)个硬币
            def dp(n):
                # 做选择，需要硬币最少的那个结果就是答案
                foreach coin in coins:
                    res = min(res, 1 + dp(n - coin))
                return res
            # 我们要求目标金额是amount
            return dp(amount)
        }

        4、明确base case。显然目标金额为 0 时，所需硬币数量为 0；
           当目标金额小于 0 时，无解，返回 -1

        def coinChange(coins: List[int], amount: int):

            def dp(n):
                # base case
                if n == 0: return 0
                if n < 0: return -1
                # 求最小值，所以初始化为正无穷
                res = float('INF')
                for coin in coins:
                    subproblem = dp(n - coin)
                    # 子问题无解，跳过
                    if subproblem == -1: continue
                    res = min(res, 1 + subproblem)

                return res if res != float('INF') else -1

            return dp(amount)

         */


        //2、带备忘录的递归解法
        //消除重叠子问题

        /*
         def coinChange(coins: List[int], amount: int):
            # 备忘录
            memo = dict()
            def dp(n):
                # 查备忘录，避免重复计算
                if n in memo: return memo[n]

                if n == 0: return 0
                if n < 0: return -1
                res = float('INF')
                for coin in coins:
                    subproblem = dp(n - coin)
                    if subproblem == -1: continue
                    res = min(res, 1 + subproblem)

                # 记入备忘录
                memo[n] = res if res != float('INF') else -1
                return memo[n]

            return dp(amount)
         */



        //3、dp数组迭代解法
        //dp[i] = x 表示，当目标金额为i时，至少需要x枚硬币。

        /*
         int coinChange(vector<int>& coins, int amount) {
            // 数组大小为 amount + 1，初始值也为 amount + 1
            vector<int> dp(amount + 1, amount + 1);
            // base case
            dp[0] = 0;
            for (int i = 0; i < dp.size(); i++) {
                // 内层 for 在求所有子问题 + 1 的最小值
                for (int coin : coins) {
                    // 子问题无解，跳过
                    if (i - coin < 0) continue;
                    dp[i] = min(dp[i], 1 + dp[i - coin]);
                }
            }
            return (dp[amount] == amount + 1) ? -1 : dp[amount];
        }
         */

        //PS：为啥dp数组初始化为amount + 1呢，因为凑成amount金额的硬币数
        //最多只可能等于amount（全用 1 元面值的硬币），所以初始化为amount + 1
        //就相当于初始化为正无穷，便于后续取最小值。

        public int CoinChange(int[] coins, int amount)
        {
            //dp[i] = x 表示，当目标金额为i时，至少需要x枚硬币
            //dp[i] ： 当目标金额为i时，至少需要dp[i]枚硬币
            int[] dp = new int[amount + 1];
            for(int i = 0; i <= amount; i++)
            {
                dp[i] = amount + 1;
            }

            dp[0] = 0;
            for(int i = 0; i <  dp.Length; i++)
            {
                foreach(int coin in coins)
                {
                    if (i - coin < 0)
                        continue;
                    dp[i] = Math.Min(dp[i], 1 + dp[i - coin]);
                }
            }
            return (dp[amount] == amount + 1) ? -1 : dp[amount];
        }




    }
}
