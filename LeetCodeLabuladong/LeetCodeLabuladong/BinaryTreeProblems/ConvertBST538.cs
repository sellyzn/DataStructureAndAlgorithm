using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLabuladong.BinaryTreeProblems
{
    /*538. 把二叉搜索树转换为累加树
    给出二叉 搜索 树的根节点，该树的节点值各不相同，请你将其转换为累加树（Greater Sum Tree），
    使每个节点 node 的新值等于原树中大于或等于 node.val 的值之和。
 
    */
    public class ConvertBST538
    {
        public TreeNode ConvertBST(TreeNode root)
        {
            Traverse(root);
            return root;
        }
        //记录累加和
        int sum = 0;
        public void Traverse(TreeNode root)
        {
            if (root == null)
                return;
            Traverse(root.right);
            //维护累加和
            sum += root.val;
            //将BST转化成累加树
            root.val = sum;
            Traverse(root.left);
        }

        /*
            按照二叉树的通用思路，需要思考每个节点应该做什么，但是这道题上很难想到什么思路。

            BST 的每个节点左小右大，这似乎是一个有用的信息，既然累加和是计算大于等于当前值的所有元素之和，那么每个节点都去计算右子树的和，不就行了吗？

            这是不行的。对于一个节点来说，确实右子树都是比它大的元素，但问题是它的父节点也可能是比它大的元素呀？这个没法确定的，我们又没有触达父节点的指针，所以二叉树的通用思路在这里用不了。

            其实，正确的解法很简单，还是利用 BST 的中序遍历特性。


            void traverse(TreeNode root) {
            if (root == null) return;
            // 先递归遍历右子树
            traverse(root.right);
            // 中序遍历代码位置
            print(root.val);
            // 后递归遍历左子树
            traverse(root.left);
            }
            这段代码可以从大到小降序打印 BST 节点的值，如果维护一个外部累加变量sum，然后把sum赋值给 BST 中的每一个节点，不就将 BST 转化成累加树了吗？

            核心还是 BST 的中序遍历特性，只不过我们修改了递归顺序，降序遍历 BST 的元素值，从而契合题目累加树的要求。

         */
    }
}
