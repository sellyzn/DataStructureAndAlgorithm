using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLabuladong.BinaryTreeProblems
{
    /* 230. 二叉搜索树中第K小的元素
     * 
     */
    public class KthSmallest230
    {
        public int KthSmallest(TreeNode root, int k)
        {
            //利用BST的中序遍历特性
            Traverse(root, k);
            return res;
        }
        //记录结果
        int res = 0;
        //记录当前元素的排名
        int rank = 0;
        public void Traverse(TreeNode root, int k)
        {
            if (root == null)
                return;
            Traverse(root.left, k);
            /* 中序遍历代码位置 */
            rank++;
            if (rank == k)
            {
                //找到第k小的元素
                res = root.val;
                return;
            }
            /********************/
            Traverse(root.right, k);
        }
    }
}
