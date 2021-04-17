using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen.TreeCollections
{
    //114.二叉树展开为链表
    public class Flatten114
    {
        public void Flatten(TreeNode root)
        {
            if (root == null)
                return;
            Flatten(root.left);
            Flatten(root.right);
            TreeNode left = root.left;
            TreeNode right = root.right;
            root.left = null;
            root.right = left;
            TreeNode tmp = root;
            while(tmp.right != null)  //注意是tmp.right != null，而不是tmp != null
            {
                tmp = tmp.right;
            }
            tmp.right = right;
        }
    }
}
