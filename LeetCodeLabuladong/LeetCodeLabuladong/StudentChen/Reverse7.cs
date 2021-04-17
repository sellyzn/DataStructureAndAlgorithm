using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen
{
    public class Reverse7
    {
        //7.整数反转
        //注意反转后判断是否溢出
        public int Reverse(int x)
        {
            int res = 0, mod = 0;
            while(x != 0)
            {
                mod = x % 10;
                //if (res > int.MaxValue / 10 || (res == int.MaxValue / 10 && mod > 7))
                //    return 0;
                //if (res < int.MinValue / 10 || (res == int.MinValue / 10 && mod < -8))
                //    return 0;
                if (res > int.MaxValue / 10 || res < int.MinValue / 10)
                    return 0;
                res = res * 10 + mod;
                x = x / 10;
            }
            return res;
        }
    }
}
