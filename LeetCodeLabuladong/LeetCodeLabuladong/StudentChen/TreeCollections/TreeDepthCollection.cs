using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen.TreeCollections
{
    public class TreeDepthCollection
    {
        //二叉树的深度
        public int Depth(TreeNode root)
        {
            if (root == null)
                return 0;
            return Math.Max(Depth(root.left), Depth(root.right)) + 1;
        }

        //二叉树的最大深度(就是二叉树的深度)
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            return Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
        }

        //二叉树的最小深度
        /*
        叶子节点的定义是左孩子和右孩子都为 null 时叫做叶子节点
        当 root 节点左右孩子都为空时，返回 1
        当 root 节点左右孩子有一个为空时，返回不为空的孩子节点的深度
        当 root 节点左右孩子都不为空时，返回左右孩子较小深度的节点值

         */
        public int MinDepth(TreeNode root)
        {
            //if (root == null)
            //    return 0;
            //if (root.left == null && root.right == null)
            //    return 1;
            //int min_depth = int.MaxValue;
            //if (root.left != null)
            //{
            //    min_depth = Math.Min(MinDepth(root.left), min_depth);
            //}
            //if (root.right != null)
            //{
            //    min_depth = Math.Min(MinDepth(root.right), min_depth);
            //}

            //return min_depth + 1;  
            if (root == null)
                return 0;
            int min_left = MinDepth(root.left);
            int min_right = MinDepth(root.right);
            return (root.left == null || root.right == null) ? min_left + min_right + 1 : Math.Min(min_left, min_right) + 1;
        }
    }
}
