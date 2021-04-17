using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen.TreeCollections
{
    public class DiameterOfBinaryTree543
    {
        //543.二叉树的直径
        public int DiameterOfBinaryTree(TreeNode root)
        {
            if (root == null)
                return 0;
            //return GetDepth(root.left) + GetDepth(root.right);
            int leftDiameter = root.left == null ? 0 : GetDepth(root.left);
            int rightDiameter = root.right == null ? 0 : GetDepth(root.right);
            return leftDiameter + rightDiameter;
        }
        public int GetDepth(TreeNode root)
        {
            if (root == null)
                return 0;
            return Math.Max(GetDepth(root.left), GetDepth(root.right)) + 1;
        }

        int res = 0;
        public int DiameterOfBinaryTree_tj(TreeNode root)
        {
            GetDepth_tj(root);
            return res;
        }
        public int GetDepth_tj(TreeNode root)
        {
            if (root == null)
                return 0;
            int leftDepth = GetDepth_tj(root.left);
            int rightDepth = GetDepth_tj(root.right);
            res = Math.Max(res, leftDepth + rightDepth);
            return Math.Max(leftDepth,rightDepth) + 1;
        }
    }
}
