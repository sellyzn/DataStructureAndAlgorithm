using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.LinkedListProblems.StudentChen
{
    public class OddEvenList328
    {
        //分离节点后合并
        public ListNode OddEvenList(ListNode head)
        {
            if (head == null)
                return null;
            ListNode evenHead = head.next;
            ListNode odd = head, even = evenHead;
            while(even != null && even.next != null)
            {
                odd.next = even.next;
                odd = odd.next;
                even.next = odd.next;
                even = even.next;
            }
            odd.next = evenHead;
            return head;
        }
    }
}
