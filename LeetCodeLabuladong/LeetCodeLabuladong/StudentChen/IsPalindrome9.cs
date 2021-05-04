using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen
{
    public class IsPalindrome9
    {
        //9.回文数
        //注意：负数 --> false
        //      0   --> true
        //      10的倍数 --> false （在此之前要先判断 0 是 true）
        public bool IsPalindrome(int x)
        {
            if (x < 0)
                return false;
            if (x == 0)
                return true;
            if (x % 10 == 0)
                return false;
            int rev = 0;
            while(rev < x)
            {
                rev = rev * 10 + x % 10;
                x = x / 10;
            }
            return rev == x || rev / 10 == x;
        }
    }
}
