using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.LinkedListProblems.StudentChen
{
    public class SwapPairs24
    {
        //24.两两交换链表中的节点
        /*
        给定一个链表，两两交换其中相邻的节点，并返回交换后的链表。
        你不能只是单纯的改变节点内部的值，而是需要实际的进行节点交换。
         */

        //迭代
        /*
         令 temp 表示当前到达的节点，初始时 temp = dummy。每次需要交换 temp 后面的两个节点。
        如果 temp 后面没有节点或者只有一个节点，则没有更多的节点需要交换，因此结束交换。
        否则，获得 temp 后面的两个节点 node1 和 node2，通过更新节点的指针关系实现两两交换节点。
        
        temp -> node1 -> node2
                   ||
                   \/
        temp -> node2 -> node1

         */
        //时间复杂度：O(N)
        //空间复杂度：O(1)
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null)
                return null;
            ListNode dummy = new ListNode(-1);
            dummy.next = head;
            ListNode temp = dummy;
            while(temp.next != null && temp.next.next != null)
            {
                ListNode node1 = temp.next;
                ListNode node2 = temp.next.next;
                temp.next = node2;
                node1.next = node2.next;
                node2.next = node1;
                temp = node1;
            }
            return dummy.next;
        }

        //递归
        /*
         终止条件：链表没有节点，或者链表只有一个节点
        链表中至少有两个节点，则在交换后，原始链表的头节点变成新的链表的第二个节点，原始链表的第二个节点变成新的链表的头节点。
        链表中的其余节点的两两交换递归实现。
         */
        //时间复杂度：O(N)
        //空间复杂度：O(N)
        public ListNode SwapPairsRec(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            ListNode newHead = head.next;
            head.next = SwapPairsRec(newHead.next);
            newHead.next = head;
            return newHead;
        }

    }
}
