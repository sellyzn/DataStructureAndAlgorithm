using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLabuladong.BinaryTree
{
    /* 700. 二叉搜索树中的搜索
        给定二叉搜索树（BST）的根节点和一个值。 
        你需要在BST中找到节点值等于给定值的节点。 
        返回以该节点为根的子树。 如果节点不存在，则返回 NULL。 
    */
    public class SearchBST700
    {
        public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null || root.val == val)
                return root;
            return (root.val < val) ? SearchBST(root.right, val) : SearchBST(root.left, val);
        }

        /*
         如果是在二叉树中寻找元素，可以这样写代码：

            boolean isInBST(TreeNode root, int target) {
                if (root == null) return false;
                if (root.val == target) return true;
                // 当前节点没找到就递归地去左右子树寻找
                return isInBST(root.left, target) || isInBST(root.right, target);
            }

         如何充分利用信息，把 BST 这个「左小右大」的特性用上？

         对原始框架进行改造，抽象出一套针对 BST 的遍历框架：

            void BST(TreeNode root, int target) {
                if (root.val == target)
                    // 找到目标，做点什么
                if (root.val < target) 
                    BST(root.right, target);
                if (root.val > target)
                    BST(root.left, target);
            }

         */
    }
}
