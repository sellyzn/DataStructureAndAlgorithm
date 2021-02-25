using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLabuladong.BinaryTreeProblems
{
    public class CountNodes222
    {
        /*222. 完全二叉树的节点个数*/
        public int CountNodes(TreeNode root)
        {
            TreeNode l = root;
            TreeNode r = root;
            //记录左、右子树的高度
            int hl = 0;
            int hr = 0;
            while(l != null)
            {
                l = l.left;
                hl++;
            }
            while(r != null)
            {
                r = r.right;
                hr++;
            }
            //如果左右子树的高度相同，则是一颗满二叉树
            if (hl == hr)
                return (int)Math.Pow(2, hl) - 1;
            //如果左右子树高度不同，则按照普通二叉树的逻辑计算
            return 1 + CountNodes(root.left) + CountNodes(root.right);
        }
    }
}
