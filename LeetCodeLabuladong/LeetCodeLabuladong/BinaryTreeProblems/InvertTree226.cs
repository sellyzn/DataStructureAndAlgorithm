using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLabuladong.BinaryTreeProblems
{
    /* 226. 翻转二叉树
     * 思路：交换每个节点的左右子节点
     */
    public class InvertTree226
    {
        //将整棵树的节点翻转
        public TreeNode InvertTree(TreeNode root)
        {
            //base case
            if (root == null)
                return null;

            /****前序遍历位置****/
            TreeNode tmp = root.left;
            root.left = root.right;
            root.right = tmp;
            
            //让左右子结点继续翻转它们的子节点
            InvertTree(root.left);
            InvertTree(root.right);

            return root;
        }
    }

    /* 树的递归框架：
     
        //二叉树遍历框架:
        void traverse(TreeNode root)
        {
            // 前序遍历
            traverse(root.left);
            // 中序遍历
            traverse(root.right);
            // 后序遍历
        }

     * 快速排序就是个二叉树的前序遍历，归并排序就是个二叉树的后续遍历
     * 快速排序的逻辑是，若要对nums[lo..hi]进行排序，我们先找一个分界点p，通过交换元素使得nums[lo..p-1]都小于等于nums[p]，且nums[p+1..hi]都大于nums[p]，然后递归地去nums[lo..p-1]和nums[p+1..hi]中寻找新的分界点，最后整个数组就被排序了。

        快速排序的代码框架如下：
        void sort(int[] nums, int lo, int hi) {
            /////////前序遍历位置////////
            // 通过交换元素构建分界点 p
            int p = partition(nums, lo, hi);
            ////////////////////////////
            
            sort(nums, lo, p - 1);
            sort(nums, p + 1, hi);
        }

     * 先构造分界点，然后去左右子数组构造分界点------前序遍历框架  

     * 归并排序的逻辑，若要对nums[lo..hi]进行排序，我们先对nums[lo..mid]排序，再对nums[mid+1..hi]排序，最后把这两个有序的子数组合并，整个数组就排好序了。

        归并排序的代码框架如下：

        void sort(int[] nums, int lo, int hi) {
            int mid = (lo + hi) / 2;
            sort(nums, lo, mid);
            sort(nums, mid + 1, hi);

            /////// 后序遍历位置 ////////
            // 合并两个排好序的子数组
            merge(nums, lo, mid, hi);
            ////////////////////////////
        }

        
     * 先对左右子数组排序，然后合并（类似合并有序链表的逻辑）------后序遍历框架
     * 
     */
}
