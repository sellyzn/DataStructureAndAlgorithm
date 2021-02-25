using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLabuladong.DynamicProgramming.SubsequenceTypeProblems
{
    public class MaxSubArray53
    {
        //dp数组的定义是「以nums[i]为结尾的最大子数组和为dp[i]」
        public int MaxSubArray(int[] nums)
        {
            int n = nums.Length;
            if (n == 0)
                return 0;
            int[] dp = new int[n];
            // base case
            // 第一个元素前面没有子数组
            dp[0] = nums[0];
            // 状态转移方程
            for (int i = 1; i < n; i++)
            {
                // 要么自成一派，要么和前面的子数组合并
                dp[i] = Math.Max(nums[i] + dp[i - 1], nums[i]);
            }
            // 得到 nums 的最大子数组
            int res = dp[0];
            for(int i = 0; i < n; i++)
            {
                res = Math.Max(res, dp[i]);
            }
            return res;
        }
    }
}
