using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen.TreeCollections
{
    public class InvertTree226
    {
        //226. 翻转二叉树
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
                return null;
            TreeNode temp = root.left;
            root.left = InvertTree(root.right);
            root.right = InvertTree(temp);
            return root;
        }
    }
}
