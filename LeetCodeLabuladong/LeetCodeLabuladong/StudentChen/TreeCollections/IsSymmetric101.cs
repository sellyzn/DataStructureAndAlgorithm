using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen.TreeCollections
{
    public class IsSymmetric101
    {
        //101.对称二叉树
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null)
                return true;
            return Helper(root.left, root.right);
        }

        public bool Helper(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;
            if (p == null || q == null)
                return false;
            return p.val == q.val && Helper(p.left, q.right) && Helper(p.right, q.left);
        }


		public bool isSymmetric(TreeNode root)
		{
			if (root == null)
			{
				return true;
			}
			//调用递归函数，比较左节点，右节点
			return dfs(root.left, root.right);
		}

		public bool dfs(TreeNode left, TreeNode right)
		{
			//递归的终止条件是两个节点都为空
			//或者两个节点中有一个为空
			//或者两个节点的值不相等
			if (left == null && right == null)
			{
				return true;
			}
			if (left == null || right == null)
			{
				return false;
			}
			if (left.val != right.val)
			{
				return false;
			}
			//再递归的比较 左节点的左孩子 和 右节点的右孩子
			//以及比较  左节点的右孩子 和 右节点的左孩子
			return dfs(left.left, right.right) && dfs(left.right, right.left);
		}

		
    }
}
