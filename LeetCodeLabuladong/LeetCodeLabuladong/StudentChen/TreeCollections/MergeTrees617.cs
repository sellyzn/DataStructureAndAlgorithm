﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen.TreeCollections
{
    public class MergeTrees617
    {
        //617. 合并二叉树
        /*
        给定两个二叉树，想象当你将它们中的一个覆盖到另一个上时，两个二叉树的一些节点便会重叠。

        你需要将他们合并为一个新的二叉树。合并的规则是如果两个节点重叠，那么将他们的值相加作为节点合并后的新值，否则不为 NULL 的节点将直接作为新二叉树的节点。

         */

        //DFS
        public TreeNode MergeTrees(TreeNode  root1, TreeNode root2)
        {
            //if (root1 == null && root2 == null)
            //    return null;
            //TreeNode root;
            //if (root1 != null && root2 != null)
            //    root = new TreeNode(root1.val + root2.val);
            //root = root1 != null ? new TreeNode(root1.val) : new TreeNode(root2.val);
            //root.left = MergeTrees(root1.left, root2.left);
            //root.right = MergeTrees(root1.right, root2.right);
            //return root;
            if (root1 == null)
                return root2;
            if (root2 == null)
                return root1;
            TreeNode root = new TreeNode(root1.val + root2.val);
            root.left = MergeTrees(root1.left, root2.left);
            root.right = MergeTrees(root1.right, root2.right);
            return root;
        }
    }
}
