using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.DynamicProgramming.KnapsackTypeProblems
{
    public class Snapsack
    {
        /// <summary>
        /// 用这个背包装物品，最多能装的价值是多少
        /// </summary>
        /// <param name="W"></背包的总容量>
        /// <param name="N"></物品个数>
        /// <param name="wt"></第i个物品的重量wt[i]>
        /// <param name="val"></第I个物品的价值val[i]>
        /// <returns></returns>
        public int SnapsackOriginal(int W, int N, int[] wt, int[] val)
        {
            int[,] dp = new int[N + 1, W + 1];
            //初始化为0
            for(int i = 0; i < N + 1; i++)
            {
                for(int w = 0; w < W + 1; w++)
                {
                    dp[i, w] = 0;
                }
            }
            for(int i = 1; i <= N; i++)
            {
                for(int w = 1; w <= W; w++)
                {
                    if(w - wt[i - 1] < 0)
                    {
                        //当前背包容量装不下，只能选择不装入背包
                        dp[i, w] = dp[i - 1, w];
                    }
                    else
                    {
                        //装入或者不装入背包，择优
                        //由于i是从 1 开始的，所以对val和wt的取值是i-1
                        dp[i, w] = Math.Max(dp[i - 1, w], dp[i - 1, w - wt[i - 1] + val[i - 1]]);
                    }
                }
            }
            return dp[N, W];
        }
    }


    /*动态规划套路
     * 第一步：明确两点，「状态」和「选择」。
     * 第二步：明确dp数组的定义。
     * 第三步：根据「选择」，思考状态转移的逻辑。
     * 第四步：把伪代码翻译成代码，处理一些边界情况。
     */

    /*动态规划套路
     * 第一步：明确两点，「状态」和「选择」。
       「状态」：就是「背包的容量」和「可选择的物品」。
       「选择」：就是「装进背包」或者「不装进背包」。

        for 状态1 in 状态1的所有取值：
            for 状态2 in 状态2的所有取值：
                for ...
                    dp[状态1][状态2][...] = 择优(选择1，选择2...)

     * 第二步：明确dp数组的定义。
       dp数组是什么？其实就是描述问题局面的一个数组。换句话说，我们刚才明确问题有什么「状态」，现在需要用dp数组把状态表示出来。

       首先看看刚才找到的「状态」，有两个，也就是说我们需要一个二维dp数组，一维表示可选择的物品，一维表示背包的容量。

       dp[i][w]的定义如下：对于前i个物品，当前背包的容量为w，这种情况下可以装的最大价值是dp[i][w]。

       根据这个定义，我们想求的最终答案就是dp[N][W]。base case 就是dp[0][..] = dp[..][0] = 0，因为没有物品或者背包没有空间的时候，能装的最大价值就是 0。

        int dp[N+1][W+1]
        dp[0][..] = 0
        dp[..][0] = 0

        for i in [1..N]:
            for w in [1..W]:
                dp[i][w] = max(
                    把物品 i 装进背包,
                    不把物品 i 装进背包
            )
        return dp[N][W]


     * 第三步：根据「选择」，思考状态转移的逻辑。
       这一步要结合对dp数组的定义和我们的算法逻辑来分析：
       如果你没有把这第i个物品装入背包，那么很显然，最大价值dp[i][w]应该等于dp[i-1][w]。你不装嘛，那就继承之前的结果。
       如果你把这第i个物品装入了背包，那么dp[i][w]应该等于dp[i-1][w-wt[i-1]] + val[i-1]。
       
        for i in [1..N]:
        for w in [1..W]:
            dp[i][w] = max(
                dp[i-1][w],
                dp[i-1][w - wt[i-1]] + val[i-1]
            )
        return dp[N][W]

     * 第四步：把伪代码翻译成代码，处理一些边界情况。
     * 
     */
}
