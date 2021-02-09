using LeetCodeLabuladong.LinkedList;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLabuladong.Array
{
    public class TwoPointersSkills
    {
        /*原地修改数组的算法*/


        /////////////////////////////////// 有序数组/链表去重 ////////////////////////////////

        /* 26. 删除排序数组中的重复项
         * 给定一个排序数组，你需要在 原地 删除重复出现的元素，使得每个元素只出现一次，返回移除后数组的新长度。
         * 不要使用额外的数组空间，你必须在 原地 修改输入数组 并在使用 O(1) 额外空间的条件下完成。 
         */
        public int RemoveDuplicates26(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            int slow = 0, fast = 0;
            while(fast < nums.Length)
            {
                if(nums[fast] != nums[slow])
                {
                    slow++;
                    //维护nums[0...slow]无重复
                    nums[slow] = nums[fast];
                }
                fast++;
            }
            //数组长度为索引+1
            return slow + 1;
        }


        /*83、删除排序链表中的重复元素
         * 给定一个排序链表，删除所有重复的元素，使得每个元素只出现一次。
         */

        public ListNode DeleteDuplicates83(ListNode head)
        {
            if (head == null)
                return null;
            ListNode slow = head, fast = head;
            while(fast != null)
            {
                if(fast.val != slow.val)
                {
                    slow.next = fast;
                    slow = slow.next;
                }
                fast = fast.next;
            }
            slow.next = null;
            return head;
        }



        //////////////////////////////////////// 移除元素 /////////////////////////////
        //给你一个数组 nums 和一个值 val，你需要 原地 移除所有数值等于 val 的元素，并返回移除后数组的新长度。
        public int RemoveElement27(int[] nums, int val)
        {
            if (nums.Length == 0)
                return 0;
            int slow = 0, fast = 0;
            while(fast < nums.Length)
            {
                if(nums[fast] != val)
                {
                    nums[slow] = nums[fast];
                    slow++;
                }
                fast++;
            }
            return slow;
        }



        ////////////////////////////////////////移动零////////////////////////////////
        //给定一个数组 nums，编写一个函数将所有 0 移动到数组的末尾，同时保持非零元素的相对顺序。

        //将所有0移到最后，相当于先移除数组中所有的0， 然后再把后面的元素都赋值为0即可。
        public void MoveZeroes283(int[] nums)
        {
            //去除nums中的所有0
            //返回去除0之后的数组长度
            int p = RemoveElement27(nums, 0);
            //将p之后的所有元素赋值为0
            while(p < nums.Length)
            {
                nums[p] = 0;
                p++;
            }
        }





    }
}
