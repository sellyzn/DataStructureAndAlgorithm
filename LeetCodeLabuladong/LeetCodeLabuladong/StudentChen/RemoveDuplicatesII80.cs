using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen
{
    //模板了
    //删除有序数组中的重复项II
    /*
    给你一个有序数组 nums ，请你 原地 删除重复出现的元素，使每个元素 最多出现两次 ，返回删除后数组的新长度。

    不要使用额外的数组空间，你必须在 原地 修改输入数组 并在使用 O(1) 额外空间的条件下完成

     */
    public class RemoveDuplicatesII80
    {
        public int RemoveDuplicatesII(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            int n = nums.Length;
            if (n <= 2)
                return n;
            int slow = 2, fast = 2;
            while(fast < n)
            {
                if (nums[slow - 2] != nums[fast])
                {
                    nums[slow] = nums[fast];
                    slow++;
                }
                fast++;
            }
            return slow;
        }


        //删除有序数组中的重复项I
        /*
        给你一个有序数组 nums ，请你 原地 删除重复出现的元素，使每个元素 最多出现一次 ，返回删除后数组的新长度。

        不要使用额外的数组空间，你必须在 原地 修改输入数组 并在使用 O(1) 额外空间的条件下完成

         */
        public int RemoveDuplicatesI(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            int n = nums.Length;
            if (n <= 1)
                return n;
            int slow = 1, fast = 1;
            while(fast < n)
            {
                if(nums[slow - 1] != nums[fast])
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
