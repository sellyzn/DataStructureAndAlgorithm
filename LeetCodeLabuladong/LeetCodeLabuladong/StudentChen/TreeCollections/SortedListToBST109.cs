using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen.TreeCollections
{
    public class SortedListToBST109
    {
        //109. 有序链表转换二叉搜索树

        //方法一：找链表中位数节点
        //方法二：获取链表长度
        public TreeNode SortedListToBST(ListNode head)
        {
            return Traverse(head, head, null);
        }
        public TreeNode Traverse(ListNode head, ListNode left, ListNode right)
        {
            if (left == right)
                return null;
            ListNode middle = GetMidian(head);
            TreeNode root = new TreeNode(middle.val);
            root.left = Traverse(head, left, middle);
            root.right = Traverse(head, middle.next, right);
            return root;
        }
        public ListNode GetMidian(ListNode head)
        {            
            if (head == null || head.next == null)
                return head;
            ListNode fast = head;
            ListNode slow = head;
            while(fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
        }

        //题解
        public TreeNode SortedListToBSTtj(ListNode head)
        {
            return Traversetj(head, null);
        }
        public TreeNode Traversetj(ListNode left, ListNode right)
        {
            if (left == right)
                return null;
            ListNode middle = GetMidiantj(left,right);
            TreeNode root = new TreeNode(middle.val);
            root.left = Traversetj(left, middle);
            root.right = Traversetj(middle.next, right);
            return root;
        }
        public ListNode GetMidiantj(ListNode left, ListNode right)
        {            
            ListNode fast = left;
            ListNode slow = left;
            while (fast != right && fast.next != right)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
        }



    }
}
