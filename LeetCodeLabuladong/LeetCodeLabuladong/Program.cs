using LeetCodeLabuladong.BinaryTree;
using System;

namespace LeetCodeLabuladong
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public int KthLargest(TreeNode root, int k)
        {
            this.k = k;
            dfs(root);
            return res;
        }
        int k;
        int res;
        public void dfs(TreeNode root)
        {
            if (root == null)
                return;
            dfs(root.right);
            if (k == 0)
                return;
            if (--k == 0)
                res = root.val;
            dfs(root.left);
        }

        //先序遍历树A中的每个节点nA
        public bool IsSubStructure(TreeNode A, TreeNode B)
        {
            if (A == null || B == null)
                return false;
            //if (A.val == B.val && Recursive(A.left, B.left) && Recursive(A.right, B.right))
            //    return true;
            return Recursive(A, B) || IsSubStructure(A.left, B) || IsSubStructure(A.right, B);
        }
        //判断树A中以nA为根节点的子树是否包含树B
        public bool Recursive(TreeNode A, TreeNode B)
        {
            if (B == null)
                return true;
            if (A == null || A.val != B.val)
                return false;
            return Recursive(A.left, B.left) && Recursive(A.right, B.right);            
        }
    }
}
