using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen
{
    public class TwoPointersCollection
    {
        //283.移动零
        public void MoveZeroes(int[] nums)
        {
            int p = RemoveElement(nums, 0);
            while(p < nums.Length)
            {
                nums[p] = 0;
                p++;
            }
        }
        public int RemoveElement(int[] nums, int target)
        {
            if (nums.Length == 0)
                return 0;
            int slow = 0, fast = 0;
            while(fast < nums.Length)
            {
                if(nums[fast] != target)
                {
                    nums[slow] = nums[fast];
                    slow++;
                }
                fast++;
            }
            return slow;
        }
    }
}
