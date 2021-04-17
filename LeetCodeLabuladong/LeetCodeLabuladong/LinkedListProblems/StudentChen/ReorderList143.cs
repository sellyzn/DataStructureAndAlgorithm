using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.LinkedListProblems.StudentChen
{
    public class ReorderList143
    {
        //143.重排链表
        //没有返回值return，不用dummy节点
        //双指针
        public void ReorderList(ListNode head)
        {
            if (head == null || head.next == null)
                return;
            //分隔链表
            ListNode middleNode = MiddleNode(head);
            ListNode l1 = head;
            ListNode l2 = middleNode.next;
            //ListNode cur = head;

            //while(cur.val != middleNode.val)
            //{
            //    cur = cur.next;
            //}
            //cur.next = null;
            middleNode.next = null;

            //反转链表l2
            //ListNode l2 = Reverse(middleNode.next);  //如果不在之前声明l2，直接这样写，结果不对
            l2 = ReverseList(l2);

            //merge链表
            MergeTwoLists(l1, l2);

        }
        //奇数返回中间节点，偶数返回中间偏右节点
        public ListNode MiddleNode(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;
            while(fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
        }
        public ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            
            ListNode pre = head, cur = head.next;
            while(cur != null)
            {
                ListNode temp = cur.next;
                cur.next = pre;
                pre = cur;
                cur = temp;
            }
            return pre;
        }
        public void MergeTwoLists(ListNode l1, ListNode l2)
        {

            ListNode l1_tmp, l2_tmp;
            while(l1 != null && l2 != null)
            {
                l1_tmp = l1.next;
                l1.next = l2;
                l1 = l1_tmp;

                l2_tmp = l2.next;
                l2.next = l1;
                l2 = l2_tmp;
            }    
        }
    }
}
