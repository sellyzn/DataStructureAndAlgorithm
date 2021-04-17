using LeetCodeLabuladong.BinaryTreeProblems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen.TreeCollections
{
    public class LowestCommonAncestorOffer68I
    {
        //剑指Offer68-I. 二叉搜索树的最近公共祖先
        //递归
        public TreeNode LowestCommonAncestor_Re(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root.val > p.val && root.val > q.val)
                return LowestCommonAncestor_Re(root.left, p, q);
            else if (root.val < p.val && root.val < q.val)
                return LowestCommonAncestor_Re(root.right, p, q);
            else
                return root;
        }

        //迭代
        public TreeNode LowestCommonAncestor_It(TreeNode root, TreeNode p, TreeNode q)
        {
            while(root != null)
            {
                if (root.val > p.val && root.val > q.val)
                    root = root.left;
                else if (root.val < p.val && root.val < q.val)
                    root = root.right;
                else
                    break;
            }
            return root;
        }

        //剑指Offer68-II. 二叉树的最近公共祖先
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || root == p || root == q)
                return root;
            TreeNode left = LowestCommonAncestor(root.left, p, q);
            TreeNode right = LowestCommonAncestor(root.right, p, q);
            if (left == null && right == null)
                return null;
            else if (left == null && right != null)
                return right;
            else if (left != null && right == null)
                return left;
            else
                return root;
        }
    }
}
