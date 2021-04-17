using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.ArrayProblems.StudentChen
{
    public class SearchInsert35
    {
        public int SearchInsert(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1, res = nums.Length;
            while(left <= right)
            {
                int mid = left + (right - left) / 2;
                
                if (nums[mid] >= target)
                {
                    res = mid;
                    right = mid - 1;
                }                
                else
                {
                    left = mid + 1;
                }
            }
            return res;
        }
    }
}
