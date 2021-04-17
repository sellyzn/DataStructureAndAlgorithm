using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen
{
    public class ContainsDuplicateCollection
    {
        //217.存在重复元素//
        /*
        给定一个整数数组，判断是否存在重复元素。
        如果存在一值在数组中出现至少两次，函数返回 true 。
        如果数组中每个元素都不相同，则返回 false 。
         */

        //HashSet
        //时间复杂度：O(n)
        //空间复杂度：O(n)
        public bool ContainsDuplicate_Hash(int[] nums)
        {
            HashSet<int> set = new HashSet<int>();
            foreach(int num in nums)
            {
                if (set.Contains(num))
                    return true;
                else
                    set.Add(num);
            }
            return false;
        }

        //Sort
        //时间复杂度：O(nlogn)
        //空间复杂度：O(1)
        public bool ContainsDuplicate_Sort(int[] nums)
        {
            Array.Sort(nums);
            for(int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] == nums[i + 1])
                    return true;
            }
            return false;
        }


        //offer03.数组中重复的数字//
        /*
        找出数组中重复的数字。
        在一个长度为 n 的数组 nums 里的所有数字都在 0～n-1 的范围内。
        数组中某些数字是重复的，但不知道有几个数字重复了，也不知道每个数字重复了几次。
        请找出数组中任意一个重复的数字。

         */

        //HashSet
        public int FindRepeatNumber_Hash(int[] nums)
        {
            HashSet<int> set = new HashSet<int>();
            int repeat = -1;
            foreach (int num in nums)
            {
                if (set.Contains(num))
                {
                    repeat = num;
                    break;
                }
                else
                    set.Add(num);
            }
            return repeat;
        }

        //原地置换
        /*
         如果没有重复数字，那么正常排序后，数字i应该在下标为i的位置，所以思路是重头扫描数组，
        遇到下标为i的数字如果不是i的话，（假设为m),那么我们就拿与下标m的数字交换。
        在交换过程中，如果有重复的数字发生，那么终止返回ture
         */
        //扫描数组，检查nums[i] == nums[nums[i]]，
        //如果相等，则返回nums[i];如果不相等，则交换nums[i]和nums[nums[i]].
        public int FindRepeatNumber_Re(int[] nums)
        {
            int temp;
            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == nums[nums[i]])
                    return nums[i];
                temp = nums[i];
                nums[i] = nums[temp];
                nums[temp] = temp;
            }
            return -1;
        }

        ////////快慢指针////////
        //287.寻找重复数
        /*
        给定一个包含 n + 1 个整数的数组 nums ，
        其数字都在 1 到 n 之间（包括 1 和 n），
        可知至少存在一个重复的整数。

        假设 nums 只有 一个重复的整数 ，找出 这个重复的数 。


        提示：
        2 <= n <= 3 * 104
        nums.length == n + 1
        1 <= nums[i] <= n
        nums 中 只有一个整数 出现 两次或多次 ，其余整数均只出现 一次
 

        进阶：
        如何证明 nums 中至少存在一个重复的数字?
        你可以在不修改数组 nums 的情况下解决这个问题吗？
        你可以只用常量级 O(1) 的额外空间解决这个问题吗？
        你可以设计一个时间复杂度小于 O(n^2) 的解决方案吗？

         */
        //public int FindDuplicate(int[] nums)
        //{
            
        //}

        //202.快乐数


        //26.删除有序数组中的重复项
        /*
        给你一个有序数组 nums ，请你 原地 删除重复出现的元素，使每个元素 只出现一次 ，返回删除后数组的新长度。

        不要使用额外的数组空间，你必须在 原地 修改输入数组 并在使用 O(1) 额外空间的条件下完成。

         */

        //原地修改，快慢指针
        /*
        快慢指针：
        比较 slow 和 fast 位置的元素是否相等。

        如果相等，fast 后移 1 位
        如果不相等，将 fast 位置的元素复制到 slow+1 位置上，slow 后移 1 位，fast 后移 1 位
        重复上述过程，直到 fast 等于数组长度。

        返回 slow + 1，即为新数组长度。

         */
        public int RemoveDuplicates(int[] nums)
        {
            if (nums == null | nums.Length == 0)
                return 0;
            int slow = 0, fast = 0;
            while(fast < nums.Length)
            {
                if (nums[slow] != nums[fast])
                {
                    slow++;
                    nums[slow] = nums[fast];
                }
                fast++;
                //if (nums[slow] == nums[fast])
                //{
                //    fast++;
                //}
                //else
                //{
                //    slow++;
                //    nums[slow] = nums[fast];
                //    fast++;
                //}
            }
            return slow + 1;
        }

        
    }
}
