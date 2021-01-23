using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLabuladong.BinaryTree
{
    /* 654.最大二叉树
     
        给定一个不含重复元素的整数数组 nums 。一个以此数组直接递归构建的 最大二叉树 定义如下：
        二叉树的根是数组 nums 中的最大元素。
        左子树是通过数组中 最大值左边部分 递归构造出的最大二叉树。
        右子树是通过数组中 最大值右边部分 递归构造出的最大二叉树。
        返回有给定数组 nums 构建的 最大二叉树 。

     */
    public class ConstructMaximumBinaryTree654
    {
        /* 主函数 */
        public TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            return Build(nums, 0, nums.Length - 1);
        }
        /* 将 nums[lo..hi] 构造成符合条件的树，返回根节点 */
        public TreeNode Build(int[] nums, int lo, int hi)
        {
            // base case
            if (lo > hi)
                return null;

            // 找到数组中的最大值和对应的索引
            int index = -1;
            int maxValue = int.MinValue;
            for (var i = lo; i <= hi; i++)
            {
                if (nums[i] > maxValue)
                {
                    maxValue = nums[i];
                    index = i;
                }
            }

            TreeNode root = new TreeNode(maxValue);
            // 递归调用构造左右子树
            root.left = Build(nums, lo, index - 1);
            root.right = Build(nums, index + 1, hi);
            return root;
        }

        /*
        我们肯定要遍历数组把找到最大值maxVal，把根节点root做出来，然后对maxVal左边的数组和右边的数组进行递归调用，作为root的左右子树。

        按照题目给出的例子，输入的数组为[3,2,1,6,0,5]，对于整棵树的根节点来说，其实在做这件事：

        TreeNode ConstructMaximumBinaryTree([3,2,1,6,0,5]) {
            // 找到数组中的最大值
            TreeNode root = new TreeNode(6);
            // 递归调用构造左右子树
            root.left = ConstructMaximumBinaryTree([3,2,1]);
            root.right = ConstructMaximumBinaryTree([0,5]);
            return root;
        }

        再详细一点，就是如下伪码：

        TreeNode ConstructMaximumBinaryTree(int[] nums) {
            if (nums is empty) return null;
            // 找到数组中的最大值
            int maxVal = int.MinValue;
            int index = 0;
            for (int i = 0; i < nums.length; i++) {
                if (nums[i] > maxVal) {
                    maxVal = nums[i];
                    index = i;
                }
            }

            TreeNode root = new TreeNode(maxVal);
            // 递归调用构造左右子树
            root.left = ConstructMaximumBinaryTree(nums[0..index-1]);
            root.right = ConstructMaximumBinaryTree(nums[index+1..nums.length-1]);
            return root;
        }

        对于每个根节点，只需要找到当前nums中的最大值和对应的索引，然后递归调用左右数组构造左右子树即可。

        明确了思路，我们可以重新写一个辅助函数Build，来控制nums的索引


        */


    }
}
