using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLabuladong.DynamicProgramming.SubsequenceTypeProblems
{
    public class LengthOfLIS300
    {
        /*300、最长递增子序列
         * 
        给你一个整数数组 nums ，找到其中最长严格递增子序列的长度。

        子序列是由数组派生而来的序列，删除（或不删除）数组中的元素而不改变其余元素的顺序。例如，[3,6,2,7] 是数组 [0,3,1,6,2,2,7] 的子序列。
 
        示例 1：
        输入：nums = [10,9,2,5,3,7,101,18]
        输出：4
        解释：最长递增子序列是 [2,3,7,101]，因此长度为 4 。

        示例 2：
        输入：nums = [0,1,0,3,2,3]
        输出：4

        示例 3：
        输入：nums = [7,7,7,7,7,7,7]
        输出：1

         */

        //dp[i]表示以nums[i]这个数结尾的最长递增子序列的长度
        public int LengthOfLIS(int[] nums)
        {
            int[] dp = new int[nums.Length];
            //base case: dp数组全部初始化为1，因为以nums[i]结尾的最长递增子序列起码要包含它自己。
            for(int i = 0; i < dp.Length; i++)
            {
                dp[i] = 1;
            }
            //要想求dp[i]的值，就是相求以nums[i]为结尾的最长递增子序列
            //既然是递增序列，我们只要找到前面那些结尾比nums[i]小的子序列，然后把nums[i]接到最后，就可以形成一个新的递增序列，而且这个新的子序列长度加一
            //显然，可能形成很多种新的子序列，我们只选最长的那一个，把最长子序列的长度作为dp[i]的值即可。
            for(int i = 0; i < nums.Length; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
            //子序列的最大长度应该是dp数组中的最大值
            int res = 0;
            for(int i = 0; i < dp.Length; i++)
            {
                res = Math.Max(res, dp[i]);
            }
            return res;
        }


        /*673、最长递增子序列的个数
         给定一个未排序的整数数组，找到最长递增子序列的个数。

        示例 1:
        输入: [1,3,5,4,7]
        输出: 2
        解释: 有两个最长递增子序列，分别是 [1, 3, 4, 7] 和[1, 3, 5, 7]。
        
        示例 2:
        输入: [2,2,2,2,2]
        输出: 5
        解释: 最长递增子序列的长度是1，并且存在5个子序列的长度为1，因此输出5。


         */
        public int FindNumberOfLIS(int[] nums)
        {
            if (nums.Length == 0)
                return 0;

            int[] dp = new int[nums.Length];
            int[] count = new int[nums.Length];

            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = 1;
                count[i] = 1;
            }

            for (int i = 0; i < dp.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        if (dp[j] + 1 > dp[i])
                        {
                            dp[i] = dp[j] + 1;
                            count[i] = count[j];
                        }
                        else if (dp[j] + 1 == dp[i])
                        {
                            count[i] += count[j];
                        }
                    }
                }
            }

            int lis = 0;
            for (int i = 0; i < dp.Length; i++)
            {
                lis = Math.Max(lis, dp[i]);
            }

            int res = 0;
            for (int i = 0; i < dp.Length; i++)
            {
                if (lis == dp[i])
                    res += count[i];
            }
            return res;
        }


        /*674、最长连续递增序列
         * 
         给定一个未经排序的整数数组，找到最长且 连续递增的子序列，并返回该序列的长度。

        连续递增的子序列 可以由两个下标 l 和 r（l < r）确定，如果对于每个 l <= i < r，都有 nums[i] < nums[i + 1] ，
        那么子序列 [nums[l], nums[l + 1], ..., nums[r - 1], nums[r]] 就是连续递增子序列。
 

        示例 1：
        输入：nums = [1,3,5,4,7]
        输出：3
        解释：最长连续递增序列是 [1,3,5], 长度为3。
        尽管 [1,3,5,7] 也是升序的子序列, 但它不是连续的，因为 5 和 7 在原数组里被 4 隔开。 
        
        示例 2：
        输入：nums = [2,2,2,2,2]
        输出：1
        解释：最长连续递增序列是 [2], 长度为1。

         */
        //dp[i]：以nums[i]为结尾的子数组中，最长连续递增数组的长度
        //dp[i] = nums[i] > nums[i - 1] ? dp[i - 1] + 1 : 1;
        //ans = max{dp[i]}
        public int FindLengthOfLCIS(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            int[] dp = new int[nums.Length];
            for(int i = 0; i < dp.Length; i++)
            {
                dp[i] = 1;
            }
            for(int i = 1; i < nums.Length; i++)
            {
                if(nums[i] > nums[i - 1])
                {
                    dp[i] = dp[i - 1] + 1;
                }
                else
                {
                    dp[i] = 1;
                }
            }
            int ans = 0;
            for(int i = 0; i < dp.Length; i++)
            {
                ans = Math.Max(ans, dp[i]);
            }
            return ans;
        }


    }
}
