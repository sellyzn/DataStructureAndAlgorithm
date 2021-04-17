using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.LinkedListProblems.StudentChen
{
    public class SortList148
    {
        //148.排序链表
        //要求时间复杂度：O(nlogn)，空间复杂度：常数级
        public ListNode SortList(ListNode head)
        {
            //1.递归结束条件
            if (head == null || head.next == null)
                return head;
            //2.找到链表中间节点断开链表 & 递归
            ListNode middleNode = MiddleNode(head);
            ListNode rightHead = middleNode.next;
            middleNode.next = null;

            ListNode left = SortList(head);
            ListNode right = SortList(rightHead);

            //3. 合并有序链表
            return MergeTwoLists(left, right);
        }

        //找到链表的中间节点（876.链表的中间节点）
        public ListNode MiddleNode(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            ListNode slow = head;
            ListNode fast = head;
            while(fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
        }
        //合并两个有序链表（21.合并两个有序链表）
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
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
            pre.next = l1 != null ? l1 : l2;
            return dummy.next;
        }
    }
}
