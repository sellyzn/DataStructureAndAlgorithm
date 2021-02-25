using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLabuladong.BinaryTreeProblems
{
    /*105. 从前序与中序遍历序列构造二叉树*/
    public class BuildTree105
    {
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            return Build(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1);
        }
        public TreeNode Build(int[] preorder, int preStart, int preEnd, int[] inorder, int inStart, int inEnd)
        {
            if (preStart > preEnd)
                return null;

            //root节点对应的值就是前序遍历数组的第一个元素
            int rootValue = preorder[preStart];
            //找到rootVal在中序遍历数组中的索引
            int index = 0;
            for (int i = inStart; i <= inEnd; i++)
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
            root.left = Build(preorder, preStart + 1, preStart + leftLength, inorder, inStart, index - 1);
            root.right = Build(preorder, preStart + leftLength + 1, preEnd, inorder, index + 1, inEnd);
            return root;
        }


        /*
         下面这几个问号处应该填什么, 如何确定左右子树对应的preorder和inorder数组中的左右数组对应的起始索引和终止索引, 画图便一目了然：

            root.left = build(preorder, ?, ?,
                              inorder, ?, ?);

            root.right = build(preorder, ?, ?,
                               inorder, ?, ?);
         */
    }
}
