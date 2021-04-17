using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen
{
    public class MySqrt69
    {
        //
        /*
         
         */

        //二分查找
        public int MySqrt(int x)
        {
            int left = 0, right = x, res = -1;
            while(left <= right)
            {
                int mid = left + (right - left) / 2;
                if ((long)mid * mid <= x)    //(long)(mid * mid)会错
                {
                    res = mid;
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return res;
        }
    }
}
