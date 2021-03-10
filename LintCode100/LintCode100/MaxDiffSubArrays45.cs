using System;
using System.Collections.Generic;
using System.Text;

namespace LintCode100
{
    public class MaxDiffSubArrays45
    {
        public int MaxDiffSubArrays(int[] nums)
        {
            HashSet<int> setpos = new HashSet<int>();
            HashSet<int> setneg = new HashSet<int>();
            int flag = 0;   //default value: 标志符：nums中没有值为0的元素，flag = 0;

            for(int i = 0; i <nums.Length; i++)
            {
                if (nums[i] > 0)
                    setpos.Add(nums[i]);
                else if (nums[i] < 0)
                    setneg.Add(nums[i]);
                else if (nums[i] == 0)
                    flag = 1;
            }

            int posSum = 0, negSum = 0;
            int posMax = 0, posMin = int.MaxValue;
            int negMax = int.MinValue, negMin = 0;
            foreach(int item in setpos)
            {
                posSum += item;
                posMax = Math.Max(posMax, item);
                posMin = Math.Min(posMin, item);
            }
            foreach(int item in setneg)
            {
                negSum += item;
                negMax = Math.Max(negMax, item);
                negMin = Math.Min(negMin, item);
            }

            if (flag == 0 && negSum == 0)
                return posSum - 2 * posMin;
            if (flag == 0 && posSum == 0)
                return 2 * negMax - negSum;
            if (flag == 1 && negSum == 0)
                return posSum;
            if (flag == 1 && posSum == 0)
                return -negSum;
            return posSum - negSum;
            
        }
    }
}
