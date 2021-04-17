using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen
{
    public class MajorityElement169
    {
        //1.Hash Table
        public int MajorityElement_Hash(int[] nums)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!dict.ContainsKey(nums[i]))
                    dict[nums[i]] = 1;
                else
                    dict[nums[i]]++;
                if (dict[nums[i]] > nums.Length / 2)
                    return nums[i];
            }
            return -1;
        }

        //2.Sort
        public int MajorityElement_Sort(int[] nums)
        {
            Array.Sort(nums);
            return nums[nums.Length / 2];
        }

        //Boyer-Moore vote
        public int MajorityElement_Moore(int[] nums)
        {
            int count = 0;
            int candidate = nums[0];

            foreach (int num in nums)
            {
                if (count == 0)
                    candidate = num;
                count += (num == candidate) ? 1 : -1;
            }
            return candidate;
        }



        //229.求众数II
        /*
        给定一个大小为 n 的整数数组，找出其中所有出现超过 ⌊ n/3 ⌋ 次的元素。

        进阶：尝试设计时间复杂度为 O(n)、空间复杂度为 O(1)的算法解决此问题。

         */
        //public IList<int> MajorityElementII(int[] nums)
        //{

        //}
    }
}
