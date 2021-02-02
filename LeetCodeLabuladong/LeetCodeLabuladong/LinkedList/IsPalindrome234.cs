using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLabuladong.LinkedList
{
    public class IsPalindrome234
    {
        //stack
        public bool IsPalindrome1(ListNode head)
        {
            Stack<ListNode> stack = new Stack<ListNode>();
            ListNode cur = head;
            while(cur != null)
            {
                stack.Push(cur);
                cur = cur.next;
            }
            ListNode newHead = stack.Pop();
            ListNode tmp = newHead;
            while(stack.Count != 0)
            {
                tmp.next = stack.Pop();
                tmp = tmp.next;
            }
            return head == newHead;
        }


        //将值复制到数组中后用双指针法
        public bool IsPalindrome2(ListNode head)
        {
            List<int> arr = new List<int>();
            ListNode cur = head;
            while(cur != null)
            {
                arr.Add(cur.val);
                cur = cur.next;
            }

            int front = 0;
            int back = arr.Count - 1;
            while(front < back)
            {
                if (arr[front] != arr[back])
                    return false;
                front++;
                back--;
            }
            return true;
        }





        //递归+双指针法
        //左侧指针
        ListNode left;
        public bool IsPalindrome3(ListNode head)
        {
            left = head;
            return Traverse(head);
        }
        //倒序打印单链表中的元素值
        public bool Traverse(ListNode right)
        {
            if (right == null)
                return true;
            bool res = Traverse(right.next);
            //后序遍历代码
            res = res && (right.val == left.val);
            left = left.next;
            return res;
        }



        //快慢指针法（优化空间复杂度）
        public bool IsPalindrome4(ListNode head)
        {
            if (head == null)
                return true;

            //通过双指针技巧中的快慢指针，找到链表的中点
            ListNode slow = head;
            ListNode fast = head;
            while(fast != null && fast.next!= null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }//现在slow指针指向链表中点

            //如果fast指针没有指向null，说明链表长度为奇数，需要将slow再向前进一步
            if (fast != null)
                slow = slow.next;

            //从slow开始反转后面的链表，然后进行回文串比较
            ListNode left = head;
            ListNode right = Reverse(slow);
            while(right != null)
            {
                if (left.val != right.val)
                    return false;
                left = left.next;
                right = right.next;
            }
            //还原输入链表的原始结构
            //if (left.next != null)
            //    left = left.next;
            //left.next = Reverse(right);
            return true;
        }
        //反转链表
        public ListNode Reverse(ListNode head)
        {
            ListNode pre = null;
            ListNode cur = head;
            while(cur != null){
                ListNode next = cur.next;
                cur.next = pre;
                pre = cur;
                cur = next;
            }
            return pre;
        }
    }
}
