using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLabuladong.Array
{
    public class TwoSumProblems
    {
        //Two Sum 系列问题即如何使用哈希表HashMap(C#:Dictionary)处理问题
        //逻辑思路比较清晰
        public int[] TwoSumI(int[] nums, int target)
        {
            int n = nums.Length;
            var dict = new Dictionary<int, int>();
            for(int i = 0; i < n; i++)
            {
                dict.Add(nums[i], i);
            }

            for(int i = 0; i < n; i++)
            {
                int other = target - nums[i];
                if (dict.ContainsKey(other) && dict[other] != i)
                    return new int[] { i, dict[other] };
            }
            return new int[] { -1, -1 };
        }

        //有点绕
        public int[] TwoSumI1(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();
            for(int i = 0; i < nums.Length; i++)
            {
                int num = target - nums[i];
                if (dict.ContainsKey(num))
                {
                    return new int[] { i, dict[num] };
                }
                if (!dict.ContainsKey(num[i]))
                {
                    dict.Add(nums[i], i);
                }
            }
            return new int[] { -1, -1 };
        }



        //设计一个类，拥有两个API

        // public class TwoSum{
        Dictionary<int, int> freq = new Dictionary<int, int>();
        
        //向数据结构中添加一个数number
        public void Add(int number)
        {
            if (!freq.ContainsKey(number))
            {
                freq.Add(number, 1);
            }
            else
            {
                freq[number]++;
            }
        }

        //寻找当前数据结构中是否存在两个数的和为value
        public bool Find(int value)
        {
            foreach(int key in freq.Keys)
            {
                int other = value - key;
                //情况一
                if (other == key && freq[key] > 1)
                    return true;
                //情况二
                if (other != key && freq.ContainsKey(other))
                    return true;
            }
            return false;
        }
        //情况一：如果连续add了[3,2,3,5]，那么freq是{3：2，2：1，5：1}，执行Find(6)，由于3出现了两次，3+3=6，所以返回true。
        //情况二：同上,执行Find(7),那么key为2，other为5时算法可以返回true

        // }


        //频繁调用Find方法时，优化Find方法

        // public class TwoSum{
        HashSet<int> sum = new HashSet<int>();
        List<int> nums = new List<int>();
        public void AddU(int number)
        {
            //记录所以可能组成的和
            foreach(int n in nums)
            {
                sum.Add(n + number);
            }
            nums.Add(number);
        }
        public bool FindU(int value)
        {
            return sum.Contains(value);
        }
        // }

    }
}
