using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen
{
    public class NthUglyNumberOffer49
    {
        //剑指Offer49.丑数
        //动态规划
        //丑数的递推性质：丑数只包含因子2，3，5，因此有“丑数 = 某较小丑数 x 某因子”

        public int NthUglyNumber(int n)
        {
            int a = 0, b = 0, c = 0;
            int[] dp = new int[n];
            dp[0] = 1;
            for(int i = 1; i < n; i++)
            {
                int n2 = dp[a] * 2;
                int n3 = dp[b] * 3;
                int n5 = dp[c] * 5;
                dp[i] = Math.Min(n2, Math.Min(n3, n5));
                if (dp[i] == n2)
                    a++;
                if (dp[i] == n3)
                    b++;
                if (dp[i] == n5)
                    c++;
            }
            return dp[n - 1];
        }
    }
}
