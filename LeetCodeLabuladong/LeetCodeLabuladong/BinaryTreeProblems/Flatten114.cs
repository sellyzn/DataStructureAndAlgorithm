using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLabuladong.BinaryTreeProblems
{
    /* 114. 二叉树展开为链表
     
       给定一个二叉树，原地将它展开为一个单链表。
       例如，给定二叉树

            1
           / \
          2   5
         / \   \
        3   4   6
        将其展开为：

        1
         \
          2
           \
            3
             \
              4
               \
                5
                 \
                  6

     */
    public class Flatten114
    {
        //定义：将以root为根的树拉平为链表
        public void Flatten(TreeNode root)
        {
            //base case
            if (root == null)
                return;

            Flatten(root.left);
            Flatten(root.right);

            /****后序遍历位置****/
            //1. 左右子树已经被拉平成一条链表
            TreeNode left = root.left;
            TreeNode right = root.right;
            //2. 将左子树作为右子树
            root.left = null;
            root.right = left;
            //3. 将原先的右子树接到当前的右子树的末端
            TreeNode tmp = root;
            while (tmp.right != null)
            {
                tmp = tmp.right;
            }
            tmp.right = right;
        }


        /* 如何按题目要求把一棵树拉平成一条链表？以下流程：
        * 1、将root的左子树和右子树拉平。
        * 2、将root的右子树接到左子树下方，然后将整个左子树作为右子树。
        * 
        *             
        *   1
           / \
          2   5
         / \   \
        3   4   6
       
            ||
            \/

            1
           / \
          2   5
           \   \
            3   6
             \
              4

            ||
            \/

            1
             \
              2
               \
                3
                 \
                  4
                   \
                    5
                     \
                      6
        * 
        */
    }
}
