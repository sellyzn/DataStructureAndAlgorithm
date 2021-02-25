using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLabuladong.DynamicProgramming.SubsequenceTypeProblems
{
    public class MaxEnvelopes354
    {
        public int MaxEnvelopes(int[][] envelopes)
        {
            int n = envelopes.Length;
            //按宽度升序排列，如果宽度一样，则按高度降序排列
            //Array.Sort(envelopes, new Comparer<int[]>()
            //{
            //    public int Compare(int[] a, int[] b)
            //    {
            //        return a[0] == b[0] ? b[1] - a[1] : a[0] - b[0];
            //    }
            //});
            IComparer revCompare = new ReverseComparer();
            Array.Sort(envelopes, revCompare);

            //对高度数组寻找LIS
            int[] height = new int[n];
            for(int i = 0; i < n; i++)
            {
                height[i] = envelopes[i][1];
            }
            return LengthOfLIS(height);
        }
        public int LengthOfLIS(int[] nums)
        {
            int[] dp = new int[nums.Length];
            //base case: dp数组全部初始化为1，因为以nums[i]结尾的最长递增子序列起码要包含它自己。
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = 1;
            }
            //要想求dp[i]的值，就是相求以nums[i]为结尾的最长递增子序列
            //既然是递增序列，我们只要找到前面那些结尾比nums[i]小的子序列，然后把nums[i]接到最后，就可以形成一个新的递增序列，而且这个新的子序列长度加一
            //显然，可能形成很多种新的子序列，我们只选最长的那一个，把最长子序列的长度作为dp[i]的值即可。
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
            //子序列的最大长度应该是dp数组中的最大值
            int res = 0;
            for (int i = 0; i < dp.Length; i++)
            {
                res = Math.Max(res, dp[i]);
            }
            return res;
        }

    }
}
