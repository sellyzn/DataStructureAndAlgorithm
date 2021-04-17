using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen.TreeCollections
{
    public class ConvertBST538
    {
        //538.把二叉搜索树转换为累加树
        //给出二叉 搜索 树的根节点，该树的节点值各不相同，请你将其转换为累加树（Greater Sum Tree），
        //使每个节点 node 的新值等于原树中大于或等于 node.val 的值之和。


        //反序中序遍历 + sum记录节点值之和并更新当前节点的值 即可
        /*
        复杂度分析:
        时间复杂度：O(n)，其中 n 是二叉搜索树的节点数。每一个节点恰好被遍历一次。
        空间复杂度：O(n)，为递归过程中栈的开销，平均情况下为 O(logn)，最坏情况下树呈现链状，为 O(n)。

         */
        public TreeNode ConvertBST(TreeNode root)
        {
            Traverse(root);
            return root;
        }
        int sum = 0;
        public void Traverse(TreeNode root)
        {
            if (root == null)
                return;
            Traverse(root.right);
            sum += root.val;
            root.val = sum;
            Traverse(root.left);
        }
    }
}
