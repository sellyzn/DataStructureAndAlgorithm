using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.LinkedListProblems.StudentChen
{
    public class Partition86
    {
        //分隔链表
        //两个dummy node： small, large
        //遍历链表，小于x的节点连接到small，大于等于x的节点连接到large
        //将large.next=null
        //将large连接到small末尾
        //要求所有 小于 x 的节点都出现在 大于或等于 x 的节点之前，并保留两个分区中每个节点的初始相对位置。
        public ListNode Partition(ListNode head, int x)
        {
            if (head == null)
                return null;
            ListNode small = new ListNode(-1);
            ListNode smallTemp = small;
            ListNode large = new ListNode(-1);
            ListNode largeTemp = large;
            ListNode cur = head;
            while (cur != null)
            {
                if (cur.val < x)
                {
                    smallTemp.next = cur;
                    smallTemp = smallTemp.next;
                }
                else
                {
                    largeTemp.next = cur;
                    largeTemp = largeTemp.next;
                }
                cur = cur.next;
            }
            largeTemp.next = null;
            smallTemp.next = large.next;
            return small.next;
        }
    }
}
