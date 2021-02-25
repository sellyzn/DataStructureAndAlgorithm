using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLabuladong.DynamicProgramming.SubsequenceTypeProblems
{
    public class SubsequenceProblemSolvingTempletes
    {
        public int LongestPalindromeSubseq(string s)
        {
            int n = s.Length;
            int[,] dp = new int[n, n];
            //dp数组全部初始化为0
            //i肯定小于等于j，所以对于那些i>j的位置，根本不存在什么子序列，应该初始化为0；
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    dp[i, j] = 0;
                }
            }

            //base case
            //字符串只有一个字符，最长回文子序列长度是1，也就是d[i,i] = 1，（i == j）。
            for(int i = 0; i < n; i++)
            {
                dp[i, i] = 1;
            }
            //反着遍历保证正确的状态转移
            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = i + 1; j < n; j++)  // 此处j = i + 1开始，不是j = i
                {
                    //状态转移方程
                    if (s[i] == s[j])
                        dp[i, j] = dp[i + 1, j - 1] + 2;
                    else
                        dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j - 1]);
                }
            }
            //返回整个s的最长回文子串长度
            return dp[0, n - 1];
        }

        /*两种思路
         * 1、第一种思路模板是一个一维的dp数组：
         int n = array.Length;
         int[] dp = new int[n];

         for(int i = 1; i < n; i ++){
            for(int j = 0; j < i; j++){
                dp[i] = 最值（dp[i], dp[j] + ...）
            }
         }
          
          例如最长递增子序列里，dp数组的定义：
          在子数组array[0...i]中，以array[i]结尾的目标子序列（）的长度是dp[i]。
          
         * 2、第二种思路模板是一个二维dp数组：
         int n = array1.Length;
         int m = array2.Length;
         int[m,n] = new dp[m,n];
         for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                if(arr[i] == arr[j])
                    dp[i,j] = 
                else
                    dp[i,j] = 最值（...）
            }
         }

        2.1 涉及两个字符串/数组时（比如最长公共子序列），dp数组的含义如下：
        在子数组arr1[0...i]和子数组arr2[0...j]中，我们要求的子序列（最长公共子序列）长度为dp[i,j]。

        2.2 只涉及一个字符串/数组时（比如最长回文子序列），dp数组的含义如下：
        在子数组array[i...j]中，我们要求的子序列（最长回文子序列）的长度为dp[i,j]


         * 
         */






    }
}
