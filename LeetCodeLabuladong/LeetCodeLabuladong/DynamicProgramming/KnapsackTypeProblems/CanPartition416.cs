using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.DynamicProgramming.KnapsackTypeProblems
{
    public class CanPartition416
    {
        public bool CanPartition(int[] nums)
        {
            int sum = 0;
            foreach(int num in nums)
            {
                sum += num;
            }
            //和为奇数时，不可能划分成两个和相等的集合
            if (sum % 2 != 0)
                return false;
            int n = nums.Length;
            sum /= 2;
            bool[,] dp = new bool[n + 1, sum + 1];
            for(int i = 0; i < n + 1; i++)
            {
                for(int j = 0; j < sum + 1; j++)
                {
                    dp[i, j] = false;
                }
            }
            for(int i = 0; i <= n; i++)
            {
                dp[i, 0] = true;
            }
            for(int i = 1; i <= n; i++)
            {
                for(int j = 1; j <= sum; j++)
                {
                    if(j - nums[i - 1] < 0)
                    {
                        //背包容量不足，不能装入第i个物品
                        dp[i, j] = dp[i - 1, j];
                    }
                    else
                    {
                        //装入或不装入背包
                        //位运算符 | ：
                        dp[i, j] = dp[i - 1, j - nums[i - 1]] | dp[i - 1, j];
                    }
                }
            }
            return dp[n, sum];
        }
    }
}
