using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.LinkedListProblems.StudentChen
{
    public class MergeTwoLists21
    {
        //Recursive
        //m,n 分别是l1,l2 的长度
        //时间复杂度：O(m + n)
        //空间复杂度： O(m + n)
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if(l1 == null)
            {
                return l2;
            }else if(l2 == null)
            {
                return l1;
            }else if(l1.val < l2.val)
            {
                l1.next = MergeTwoLists(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = MergeTwoLists(l1, l2.next);
                return l2;
            }
        }

        // iterate
        //时间复杂度：O(m + n)
        //空间复杂度： O(1)
        public ListNode MergeTwoListsI(ListNode l1, ListNode l2)
        {
            ListNode dummy = new ListNode(-1);
            ListNode pre = dummy;
            while(l1 != null && l2 != null)
            {
                if(l1.val < l2.val)
                {
                    pre.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    pre.next = l2;
                    l2 = l2.next;
                }
                pre = pre.next;
            }
            pre.next = l1 == null ? l2 : l1;
            return dummy.next;
        }


        //换成数组
        //双指针，从后往前
        //88.合并两个有序数组
        /*
        给你两个有序整数数组 nums1 和 nums2，请你将 nums2 合并到 nums1 中，使 nums1 成为一个有序数组。

        初始化 nums1 和 nums2 的元素数量分别为 m 和 n 。
        你可以假设 nums1 的空间大小等于 m + n，这样它就有足够的空间保存来自 nums2 的元素。

         */
        public void MergeArray(int[] nums1, int m, int[] nums2, int n)
        {
            int p1 = m - 1;
            int p2 = n - 1;
            int p = m + n - 1;
            while(p1 >= 0 && p2 >= 0)
            {
                nums1[p--] = (nums1[p1] > nums2[p2]) ? nums1[p1--] : nums2[p2--];
            }
            //while(p1 >= 0)
            //{
            //    nums1[p--] = nums1[p1--];
            //}
            while(p2 >= 0)
            {
                nums1[p--] = nums2[p2--];
            }
        }
    }
}
