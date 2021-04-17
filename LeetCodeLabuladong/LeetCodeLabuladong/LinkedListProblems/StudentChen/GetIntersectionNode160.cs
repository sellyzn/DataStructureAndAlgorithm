using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.LinkedListProblems.StudentChen
{
    public class GetIntersectionNode160
    {
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            ListNode A = headA, B = headB;
            while(A != B)
            {
                A = A != null ? A.next : headB;
                B = B != null ? B.next : headA;
            }
            return A;
        }
    }
}
