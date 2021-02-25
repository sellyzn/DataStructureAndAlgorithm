using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLabuladong.DynamicProgramming.SubsequenceTypeProblems
{
    public class LongestCommonSubsequence1143
    {
        //最长公共子序列
        int[,] memo;
        public int LongestCommonSubsequence(string text1, string text2)
        {
            var m = text1.Length;
            var n = text2.Length;
            memo = new int[m,n];
            //foreach (int[] row in memo)
            //{
            //    for(int i = 0; i < n; i++)
            //    {
            //        row[i] = -1;
            //    }
            //}
            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    memo[i,j] = -1;
                }
            }
            return Dp(text1, 0, text2, 0);
        }
        public int Dp(string text1, int i, string text2, int j)
        {
            if (i == text1.Length || j == text2.Length)
                return 0;
            if (memo[i,j] != -1)
                return memo[i,j];

            if(text1[i] == text2[j])
            {
                memo[i,j] = 1 + Dp(text1, i + 1, text2, j + 1);
            }
            else
            {
                memo[i,j] = Math.Max(Dp(text1, i + 1, text2, j), Dp(text1, i, text2,  j + 1));
            }
            return memo[i,j];
        }



        //583、两个字符串的删除操作
        //给定两个单词s1和s2，找到使得s1和s2相同所需的最小步数，每步可以删除任意一个字符串中的一个字符。
        public int MinDistance(string s1, string s2)
        {
            int m = s1.Length;
            int n = s2.Length;
            //if (m == 0 || n == 0)
            //    return 0;
            if (m == 0 && n == 0)
                return 0;
            if (m == 0 && n != 0)
                return n;
            if (m != 0 && n == 0)
                return m;
            int lcs = LongestCommonSubsequence(s1, s2);
            return m - lcs + n - lcs;
        }


        //712、两个字符串的最小ASCII删除和
        //给定两个字符串s1,s2，找到使两个字符串相等所需删除字符的ASCII值的最小和

        public  int MinimumDeleteSum(string s1, string s2)
        {
            var m = s1.Length;
            var n = s2.Length;
            memo = new int[m, n];
            
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    memo[i, j] = -1;
                }
            }
            return DpSum(s1, 0, s2, 0);
        }
        // 定义：将 s1[i..] 和 s2[j..] 删除成相同字符串，
        // 最小的 ASCII 码之和为 Dp(s1, i, s2, j)。
        public int DpSum(string s1, int i, string s2, int j)
        {
            //记录结果
            int res = 0;
            //base case
            if(i == s1.Length)
            {
                // 如果 s1 到头了，那么 s2 剩下的都得删除,注意索引是j，s2的索引
                while (j < s2.Length)
                {
                    res += s2[j];
                    j++;
                }
                return res;
            }
            if(j == s2.Length)
            {
                // 如果 s2 到头了，那么 s1 剩下的都得删除，注意索引是i，s1的索引
                while (i < s1.Length)
                {
                    res += s1[i];
                    i++;
                }
                return res;
            }

            if (memo[i, j] != -1)
                return memo[i, j];

            if (s1[i] == s2[j])
            {
                // s1[i] 和 s2[j] 都是在 lcs 中的，不用删除
                memo[i, j] = DpSum(s1, i + 1, s2, j + 1);
            }
            else
            {
                // s1[i] 和 s2[j] 至少有一个不在 lcs 中，删一个
                memo[i, j] = Math.Min(
                    s1[i] + DpSum(s1, i + 1, s2, j),
                    s2[j] + DpSum(s1, i, s2, j + 1)
                    );
            }
            return memo[i, j];
        }
    }
}
