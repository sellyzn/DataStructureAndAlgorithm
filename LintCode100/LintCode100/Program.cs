using System;

namespace LintCode100
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] nums = new int[] { -5, -4 };
            int[] nums = new int[] { -2, 0, 0, 1, -1, -1 };
            MaxDiffSubArrays45 md = new MaxDiffSubArrays45();
            int res = md.MaxDiffSubArrays(nums);
            Console.WriteLine(res);
        }
    }
}
