using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLabuladong.BinaryTree
{
    public class BSTRelevant
    {
        /*
         * 总结几个技巧：
         * 
            1、如果当前节点会对下面的子节点有整体影响，可以通过辅助函数增长参数列表，借助参数传递信息。

            2、在二叉树递归框架之上，扩展出一套 BST 代码框架：

            void BST(TreeNode root, int target) {
                if (root.val == target)
                    // 找到目标，做点什么
                if (root.val < target) 
                    BST(root.right, target);
                if (root.val > target)
                    BST(root.left, target);
            }
            3、根据代码框架掌握了 BST 的增删查改操作
         */

        /**通过使用辅助函数，增加函数参数列表，在参数中携带额外信息，将这种约束传递给子树的所有节点**/
        public bool IsValidBST(TreeNode root)
        {
            return IsValidBST(root, null, null);
        }

        /* 限定以 root 为根的子树节点必须满足 max.val > root.val > min.val */
        public bool IsValidBST(TreeNode root, TreeNode min, TreeNode max)
        {
            // base case
            if (root == null) return true;
            // 若 root.val 不符合 max 和 min 的限制，说明不是合法 BST
            if (min != null && root.val <= min.val) return false;
            if (max != null && root.val >= max.val) return false;
            // 限定左子树的最大值是 root.val，右子树的最小值是 root.val
            return IsValidBST(root.left, min, root)
                && IsValidBST(root.right, root, max);
        }





        /****在BST中插入一个数****/
        /*
        对数据结构的操作无非遍历 + 访问，遍历就是「找」，访问就是「改」。
        具体到这个问题，插入一个数，就是先找到插入位置，然后进行插入操作。

        总结的 BST 中的遍历框架，就是「找」的问题。直接套框架，加上「改」的操作即可。
        一旦涉及「改」，函数就要返回TreeNode类型，并且对递归调用的返回值进行接收。
        */
        TreeNode InsertIntoBST(TreeNode root, int val)
        {
            // 找到空位置插入新节点
            if (root == null) return new TreeNode(val);
            // if (root.val == val)
            //     BST 中一般不会插入已存在元素
            if (root.val < val)
                root.right = InsertIntoBST(root.right, val);
            if (root.val > val)
                root.left = InsertIntoBST(root.left, val);
            return root;
        }



        /****在BST中删除一个数****/
        /*
            类似插入操作，先「找」再「改」，框架：
            TreeNode deleteNode(TreeNode root, int key) {
                if (root.val == key) {
                    // 找到啦，进行删除
                } else if (root.val > key) {
                    // 去左子树找
                    root.left = deleteNode(root.left, key);
                } else if (root.val < key) {
                    // 去右子树找
                    root.right = deleteNode(root.right, key);
                }
                return root;
            }

            如何删除这个节点，这是难点。因为删除节点的同时不能破坏 BST 的性质。有三种情况：
            情况 1：A恰好是末端节点，两个子节点都为空，那么它可以当场去世了。
            if (root.left == null && root.right == null)
                return null;
            情况 2：A只有一个非空子节点，那么它要让这个孩子接替自己的位置。
            // 排除了情况 1 之后
            if (root.left == null) return root.right;
            if (root.right == null) return root.left;
            情况 3：A有两个子节点，麻烦了，为了不破坏 BST 的性质，A必须找到左子树中最大的那个节点，或者右子树中最小的那个节点来接替自己。
         
         */

        public TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null) return null;
            if (root.val == key)
            {
                // 这两个 if 把情况 1 和 2 都正确处理了
                if (root.left == null) return root.right;
                if (root.right == null) return root.left;
                // 处理情况 3
                TreeNode minNode = GetMin(root.right);
                root.val = minNode.val;
                root.right = DeleteNode(root.right, minNode.val);
            }
            else if (root.val > key)
            {
                root.left = DeleteNode(root.left, key);
            }
            else if (root.val < key)
            {
                root.right = DeleteNode(root.right, key);
            }
            return root;
        }

        public TreeNode GetMin(TreeNode node)
        {
            // BST 最左边的就是最小的
            while (node.left != null) node = node.left;
            return node;
        }




    }
}
