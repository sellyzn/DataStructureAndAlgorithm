using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen.TreeCollections
{
    public class MirrorTreeOffer27
    {
        //剑指 Offer 27. 二叉树的镜像
        /*
         * 请完成一个函数，输入一个二叉树，该函数输出它的镜像。
         */

        public TreeNode MirrorTree(TreeNode root)
        {
            if (root == null)
                return null;
            TreeNode temp = root.left;
            root.left = MirrorTree(root.right);
            root.right = MirrorTree(temp);
            return root;
        }
    }
}
