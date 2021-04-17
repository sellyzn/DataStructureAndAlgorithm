using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.LinkedListProblems.StudentChen
{
    public class RotateRight61
    {
        public ListNode RotateRight(ListNode head, int k)
        {

            if (head == null || head.next == null || k == 0)
                return head;
            int n = 0;
            ListNode tmp = head;
            while(tmp != null)
            {
                tmp = tmp.next;
                n++;
            }

            int step = n - k % n;
            if (step == n)
                return head;
            tmp = head;
            while(--step > 0)   //注意移动的次数
            {
                tmp = tmp.next;
                //step--;
            }
            //上述操作移动后，tmp指向前半段链表的末尾节点，需要反转的头节点为tmp.next
            ListNode newHead = tmp.next;
            tmp.next = null;
            tmp = newHead;
            while(tmp.next != null)
            {
                tmp = tmp.next;
            }
            tmp.next = head;
            return newHead;
        }
    }
}
