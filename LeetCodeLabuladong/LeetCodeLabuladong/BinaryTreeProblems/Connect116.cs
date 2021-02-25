using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLabuladong.BinaryTreeProblems
{
    /* 116. 填充每个节点的下一个右侧节点指针
       给定一个 完美二叉树 ，其所有叶子节点都在同一层，每个父节点都有两个子节点。二叉树定义如下：
        struct Node {
          int val;
          Node *left;
          Node *right;
          Node *next;
        }
       填充它的每个 next 指针，让这个指针指向其下一个右侧节点。如果找不到下一个右侧节点，则将 next 指针设置为 NULL。
       初始状态下，所有 next 指针都被设置为 NULL。

     */
    public class Connect116
    {
        //主函数
        public Node Connect(Node root)
        {
            if (root == null)
                return null;
            ConnectTwoNodes(root.left, root.right);
            return root;
        }
        //定义：输入两个节点，将它俩连接起来
        public void ConnectTwoNodes(Node node1, Node node2)
        {
            if (node1 == null || node2 == null)
                return;
            /**** 前序遍历位置 ****/
            //将传入的两个节点连接
            node1.next = node2;

            //连接相同父结点的两个子节点
            ConnectTwoNodes(node1.left, node1.right);
            ConnectTwoNodes(node2.left, node2.right);
            //连接跨越父节点的两个子结点
            ConnectTwoNodes(node1.right, node2.left);
        }

        /*
         * 二叉树的问题难点在于，如何把题目的要求细化成每个节点需要做的事情，
         * 但是如果只依赖一个节点的话，肯定是没办法连接「跨父节点」的两个相邻节点的。
         *          * 
         * 那么，我们的做法就是增加函数参数，一个节点做不到，我们就给他安排两个节点，
         * 将每一层二叉树节点连接起来」可以细化成「将每两个相邻节点都连接起来」
         * 
         */
    }
}
