using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen.TreeCollections
{
    public class KthSmallest230
    {
        int res, k;
        public int KthSmallest(TreeNode root, int k)
        {
            this.k = k;
            Recursive(root);
            return res;
        }
        public void Recursive(TreeNode root)
        {
            if (root == null || k == 0)
                return;
            Recursive(root.left);
            if(--k == 0)
            {
                res = root.val;
                return;
            }
            Recursive(root.right);
        }

        public int KthSmallest1(TreeNode root, int k)
        {            
            Traverse(root,k);
            return res;
        }
        int rank = 0;
        public void Traverse(TreeNode root, int k)
        {
            if (root == null)
                return;
            Traverse(root.left,k);
            rank++;
            if(rank == k)
            {
                res = root.val;
                return;
            }
            Traverse(root.right, k);
        }
    }
}
