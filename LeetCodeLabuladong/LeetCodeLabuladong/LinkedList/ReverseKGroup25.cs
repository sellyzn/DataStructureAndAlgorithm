using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLabuladong.LinkedList
{
    public class ReverseKGroup25
    {
        //反转以a为头结点的链表 == 反转a到null之间的结点
        public ListNode ReverseA(ListNode a)
        {
            ListNode pre = null;
            ListNode cur = a;
            ListNode nxt = a;
            while(cur != null)
            {
                nxt = cur.next;
                //逐个结点反转
                cur.next = pre;
                //更新指针位置
                pre = cur;
                cur = nxt;
            }
            //返回反转后的头结点
            return pre;
        }

        //反转区间[a,b)的元素，注意是左闭右开
        public ListNode ReverseAtoB(ListNode a, ListNode b)
        {
            ListNode pre = null;
            ListNode cur = a;
            ListNode nxt = a;
            //终止条件改一下即可
            while(cur != b)
            {
                nxt = cur.next;
                cur.next = pre;
                pre = cur;
                cur = nxt;
            }
            //返回反转后的头结点
            return pre;
        }

        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (head == null)
                return null;
            //区间[a,b)包含k个待反转元素
            ListNode a = head;
            ListNode b = head;
            for(int i = 0; i < k; i++)
            {
                //不足k个，不需要反转，base case
                if (b == null)
                    return head;
                b = b.next;
            }
            //反转前k个元素
            ListNode newHead = ReverseAtoB(a, b);
            //递归反转后续链表，并连接起来
            a.next = ReverseKGroup(b, k);
            return newHead;
        }

    }

}
