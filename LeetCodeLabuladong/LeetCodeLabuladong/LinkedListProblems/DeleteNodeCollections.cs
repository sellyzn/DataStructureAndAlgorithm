using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.LinkedListProblems
{
    public class DeleteNodeCollections
    {
        //删除链表的节点
        //
        public ListNode DeleteNode(ListNode head, int val)
        {
            if (head == null)
                return null;
            if (head.val == val)
                return head.next;
            ListNode dummy = new ListNode(0);
            dummy.next = head;
            ListNode pre = dummy;
            ListNode cur = head.next; ;
            while(cur != null)
            {
                if(cur.val == val)
                {
                    pre.next = cur.next;
                    cur = cur.next;
                }
                else
                {
                    cur = cur.next;
                    pre = pre.next;
                }
            }
            return dummy.next;
        }

        //删除链表中间节点
        //
        public void DeleateMidNode(ListNode node)
        {
            node.val = node.next.val;
            node.next = node.next.next;
        }

        //删除链表中倒数第k个节点
        //快慢指针
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode dummy = new ListNode(0);
            dummy.next = head;
            ListNode fast = head;
            ListNode slow = dummy;
            for (int i = 0; i < n; i++)
            {
                fast = fast.next;
            }
            while (fast != null)
            {
                fast = fast.next;
                slow = slow.next;
            }
            slow.next = slow.next.next;
            return dummy.next;
        }

        //删除排序链表中的重复元素
        //快慢指针
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null)
                return null;
            
            ListNode fast = head;
            ListNode slow = head;
            while(fast != null)
            {
                if(fast.val != slow.val)
                {
                    slow.next = fast;
                    slow = slow.next;
                }
                fast = fast.next;
            }
            slow.next = null;   //
            return head;
        }

        

        //删除排序链表中的重复元素II
        //
        public ListNode DeleteDuplicatesII(ListNode head)
        {
            if (head == null)
                return null;
            ListNode dummy = new ListNode(0);
            dummy.next = head;

            ListNode cur = dummy;
            while (cur.next != null && cur.next.next != null)
            {
                if(cur.next.val == cur.next.next.val)
                {
                    int x = cur.next.val;
                    while(cur.next != null && cur.next.val == x)
                    {
                        cur.next = cur.next.next;
                    }
                }
                else
                {
                    cur = cur.next;
                }
            }

            return dummy.next;
        }


    }
}
