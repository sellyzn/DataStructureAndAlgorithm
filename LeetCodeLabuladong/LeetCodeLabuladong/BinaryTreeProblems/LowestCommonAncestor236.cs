using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLabuladong.BinaryTreeProblems
{
    /* 236.二叉树的最近公共祖先
     * 给定一个二叉树，找到该树中两个指定节点的最近公共祖先。
     */
    public class LowestCommonAncestor236
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            //base case
            if (root == null)
                return null;
            if (root == p || root == q)
                return root;

            TreeNode left = LowestCommonAncestor(root.left, p, q);
            TreeNode right = LowestCommonAncestor(root.right, p, q);

            //情况1，如果p和q都在以root为根的树中，那么left和right一定分别是p和q
            if (left != null && right != null)
                return root;
            //情况2，如果P和q都不在以root为根的树中，直接返回null。
            if (left == null && right == null)
                return null;
            //情况3，如果p和q只有一个存在于root为根的树中，函数返回该节点。
            return left == null ? right : left;
        }
    }
}
