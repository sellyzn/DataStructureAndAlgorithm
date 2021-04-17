using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen
{
    public class IsHappy202
    {
        public bool IsHappy(int n)
        {
            HashSet<int> set = new HashSet<int>();
            while(n != 1 && !set.Contains(n))
            {
                set.Add(n);
                n = GetNext(n);
            }
            return n == 1;
        }
        public int GetNext(int n)
        {
            int sum = 0;
            while(n > 0)
            {
                int m = n % 10;
                n /= 10;
                sum += m * m;
            }
            return sum;
        }
    }
}
