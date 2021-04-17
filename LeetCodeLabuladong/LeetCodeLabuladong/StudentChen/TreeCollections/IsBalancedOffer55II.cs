using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen.TreeCollections
{
    public class IsBalancedOffer55II
    {
        public bool IsBalanced(TreeNode root)
        {
            if (root == null)
                return true;
            //左子树和右子树也要是平衡树
            return Math.Abs(DepthTree(root.left) - DepthTree(root.right)) <= 1 && IsBalanced(root.left) && IsBalanced(root.right);
        }
        public int DepthTree(TreeNode root)
        {
            if (root == null)
                return 0;
            return Math.Max(DepthTree(root.left), DepthTree(root.right)) + 1;
        }
    }
}
