using LeetCodeLabuladong.LinkedListProblems;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLabuladong.ArrayProblems
{
    public class TwoPointers
    {
        /* 双指针技巧可分为两类：一类是「快慢指针」，一类是「左右指针」
         * 「快慢指针」：主要解决链表中的问题，比如典型的判定链表中是否包含环
         *  「左右指针」：主要解决数组（或字符串）中的问题，比如二分查找。
         */

        ///////////////////////////////////////////////////////
        ///                      快慢指针                    ///
        ///////////////////////////////////////////////////////

        /*** 1、判定链表中是否含有环 ***/
        public bool HasCycle141(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;
            while(fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                    return true;
            }
            return false;
        }

        /*** 2、已知链表有环，返回这个环的起始位置 ***/
        public ListNode DetectCycle142(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;
            //while(fast != null && fast.next != null)
            //{
            //    slow = slow.next;
            //    fast = fast.next.next;
            //    if (slow == fast)
            //        break;
            //}
            while (true)
            {
                if (fast == null || fast.next == null)
                    return null;
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                    break;
            }
            slow = head;
            while(slow != fast)
            {
                slow = slow.next;
                fast = fast.next;
            }
            return slow;
        }

        /*** 3、寻找链表的中点 ***/

        public ListNode MiddleNode(ListNode head)
        {
            //if (head == null)
            //    return null;
            ListNode slow = head;
            ListNode fast = head;
            while(fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            //链表长度为奇偶两种情况，此时都一样
            return slow;
        }






        /*** 4、寻找链表的倒数第k个元素 ***/
        //思路还是使用快慢指针，让快指针先走 k 步，然后快慢指针开始同速前进。
        //这样当快指针走到链表末尾 null 时，慢指针所在的位置就是倒数第 k 个链表节点（为了简化，假设 k 不会超过链表长度）：
        public ListNode GetKthFromEnd(ListNode head, int k)
        {
            var fast = head;
            var slow = head;
            for (var i = 0; i < k; i++)
            {
                if (fast == null)
                {
                    return null;
                }
                else
                {
                    fast = fast.next;
                }
            }
            while (fast != null)
            {
                slow = slow.next;
                fast = fast.next;
            }
            return slow;
        }




        ///////////////////////////////////////////////////////
        ///                      左右指针                    ///
        ///////////////////////////////////////////////////////

        /*** 1、二分查找 ***/
        //最简单的二分算法
        public int BinarySearch(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            while(left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] < target)
                    left = mid + 1;
                else if (nums[mid] > target)
                    right = mid - 1;
            }
            return -1;
        }





        /*** 2、两数之和 ***/

        public int[] TwoSum(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            while(left < right)
            {
                int sum = nums[left] + nums[right];
                if (sum == target)
                    return new int[] { left, right };
                else if (sum < target)
                    left++;  //让sum大点
                else if (sum > target)
                    right--;  //让sum小点
            }
            return new int[] { -1, -1 };
        }



        /*** 3、反转数组 ***/

        public void Reverse(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;
            while(left < right)
            {
                int temp = nums[left];
                nums[left] = nums[right];
                nums[right] = temp;
                left++;
                right--;
            }
        }




        /*** 4、滑动窗口算法 ***/




    }
}
