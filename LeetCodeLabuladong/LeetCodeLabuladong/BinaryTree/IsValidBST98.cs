using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLabuladong.BinaryTree
{
    /*98. 验证二叉搜索树
        给定一个二叉树，判断其是否是一个有效的二叉搜索树。

        假设一个二叉搜索树具有如下特征：
            节点的左子树只包含小于当前节点的数。
            节点的右子树只包含大于当前节点的数。
            所有左子树和右子树自身必须也是二叉搜索树。
 
    */
    public class IsValidBST98
    {
        public bool IsValidBST(TreeNode root)
        {
            return IsValidBST(root, null, null);
        }
        /* 限定以 root 为根的子树节点必须满足 max.val > root.val > min.val */
        public bool IsValidBST(TreeNode root, TreeNode min, TreeNode max)
        {
            //base case
            if (root == null)
                return true;
            // 若 root.val 不符合 max 和 min 的限制，说明不是合法 BST
            if (min != null && root.val <= min.val)
                return false;
            if (max != null && root.val >= max.val)
                return false;
            // 限定左子树的最大值是 root.val，右子树的最小值是 root.val
            return IsValidBST(root.left, min, root) && IsValidBST(root.right, root, max);
        }

        /*
         对于某一个节点root，他只能管得了自己的左右子节点，怎么把root的约束传递给左右子树呢？
         */
    }
}
