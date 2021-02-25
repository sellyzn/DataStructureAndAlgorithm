using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLabuladong.BinaryTreeProblems
{
    //Definition for a binary tree node
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
