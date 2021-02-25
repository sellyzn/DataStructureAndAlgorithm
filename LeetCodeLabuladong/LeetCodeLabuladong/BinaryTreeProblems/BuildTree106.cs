using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLabuladong.BinaryTreeProblems
{
    /*106. 从中序与后序遍历序列构造二叉树*/
    public class BuildTree106
    {
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            return Build(inorder, 0, inorder.Length - 1, postorder, 0, postorder.Length - 1);
        }
        public TreeNode Build(int[] inorder, int inStart, int inEnd, int[] postorder, int postStart, int postEnd)
        {
            if (inStart > inEnd)
                return null;
            //root 节点对应的值就是后序遍历数组的最后一个元素
            int rootValue = postorder[postEnd];
            //找到rootValue 在中序遍历数组中的索引
            int index = 0;
            for (int i = inStart; i <= inEnd; inEnd++)
            {
                if (inorder[i] == rootValue)
                {
                    index = i;
                    break;
                }
            }
            //左子树的节点个数
            int leftLength = index - inStart;
            //先构造出当前根节点
            TreeNode root = new TreeNode(rootValue);
            //递归构造左右子树
            root.left = Build(inorder, inStart, index - 1, postorder, postStart, postStart + leftLength);
            root.right = Build(inorder, index + 1, inEnd, postorder, postStart + leftLength + 1, postEnd - 1);
            return root;
        }
    }
}
