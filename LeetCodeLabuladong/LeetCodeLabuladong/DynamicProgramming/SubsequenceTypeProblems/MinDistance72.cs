using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLabuladong.DynamicProgramming.SubsequenceTypeProblems
{
    public class MinDistance72
    {
        /*
            1、动态规划

            2、定义 dp[i][j]
                1. dp[i][j] 代表 word1 中前 i 个字符，变换到 word2 中前 j 个字符，最短需要操作的次数
                2. 需要考虑 word1 或 word2 一个字母都没有，即全增加/删除的情况，所以预留 dp[0][j] 和 dp[i][0]

            3、状态转移
                1. 增，dp[i][j] = dp[i][j - 1] + 1
                2. 删，dp[i][j] = dp[i - 1][j] + 1
                3. 改，dp[i][j] = dp[i - 1][j - 1] + 1
                4. 按顺序计算，当计算 dp[i][j] 时，dp[i - 1][j] ， dp[i][j - 1] ， dp[i - 1][j - 1] 均已经确定了
                5. 配合增删改这三种操作，需要对应的 dp 把操作次数加一，取三种的最小
                6. 如果刚好这两个字母相同 word1[i - 1] = word2[j - 1] ，那么可以直接参考 dp[i - 1][j - 1] ，操作不用加一


         */
        public int MinDistance(string word1, string word2)
        {
            int m = word1.Length;
            int n = word2.Length;
            //dp[i][j] 代表 word1 中前 i 个字符，变换到 word2 中前 j 个字符，最短需要操作的次数
            //需要考虑 word1 或 word2 一个字母都没有，即全增加/删除的情况，所以预留 dp[0][j] 和 dp[i][0]

            //Dp[i,j]:返回word1[0...i]和word2[0...j]的最小编辑距离
            //Dp[i-1][j-1]:存储 word1[0..i] 和 word2[0..j] 的最小编辑距离
            int[,] Dp = new int[m + 1, n + 1];
            //第一行，word1为空，变成word2最少步数，就是插入操作
            for(int i = 0; i <= m; i++)
            {
                Dp[i, 0] = i;
            }
            //第一列，
            for(int j = 0; j <= n; j++)
            {
                Dp[0, j] = j;
            }
            //
            for(int i = 1; i <= m; i++)
            {
                for(int j = 1; j <= n; j++)
                {
                    if(word1[i - 1] == word2[j - 1])   //不是word1[i] == word2[j]？？
                    {
                        Dp[i, j] = Dp[i - 1, j - 1];
                    }
                    else
                    {
                        Dp[i, j] = Min(Dp[i - 1, j] + 1,
                            Dp[i, j - 1] + 1,
                            Dp[i - 1, j - 1] + 1);
                    }
                }
            }
            return Dp[m, n];
        }
        public int Min(int a, int b, int c)
        {
            return Math.Min(a, Math.Min(b, c));
        }
    }
}
