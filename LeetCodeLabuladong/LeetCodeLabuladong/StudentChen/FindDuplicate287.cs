using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen
{
    public class FindDuplicate287
    {
        //287.寻找重复数
        public int FindDuplicate(int[] nums)
        {
            //Array.Sort(nums);
            //if (nums.Length == 2)
            //    return nums[0];
            //int left = 0, right = nums.Length - 1;
            //while(left <= right)
            //{
            //    int mid = left + (right - left) / 2;
            //    if (nums[mid] == mid)
            //        right = mid;
            //    else if (nums[mid] < mid)
            //        left = mid + 1;
            //}
            //return left - 1;

            int n = nums.Length;
            if (n == 2)
                return nums[0];
            int left = 1, right = n - 1;
            int res = -1;
            while(left <= right)
            {
                int mid = left + (right - left) / 2;
                int count = 0;
                for(int i = 0; i < n; i++)
                {
                    if (nums[i] <= mid)
                        count++;
                }
                if (count <= mid)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                    res = mid;
                }
            }
            return res;
        }
    }
}
