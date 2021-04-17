using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen.TreeCollections
{
    public class ConstructMaximumBinaryTree654
    {
        //654. 最大二叉树
        /*
        最大二叉树 定义如下：
        1.二叉树的根是数组 nums 中的最大元素。
        2.左子树是通过数组中 最大值左边部分 递归构造出的最大二叉树。
        3.右子树是通过数组中 最大值右边部分 递归构造出的最大二叉树。

        时间复杂度：O(n^2)。方法 Build 一共被调用 n 次。
        每次递归寻找根节点时，需要遍历当前索引范围内所有元素找出最大值。
        一般情况下，每次遍历的复杂度为 O(logn)，总复杂度为 O(nlogn)。
        最坏的情况下，数组 nums 有序，总的复杂度为 O(n^2)。

        空间复杂度：O(n)。递归调用深度为 n。平均情况下，长度为 n 的数组递归调用深度为 O(logn)。


         */
        public TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return null;
            return Build(nums, 0, nums.Length - 1);
        }
        public TreeNode Build(int[] nums, int left, int right)
        {
            if (left > right)
                return null;
            if (left == right)
                return new TreeNode(nums[left]);
            //找最大元素
            int max = nums[left];
            int index = left;
            for(int i = left; i <= right; i++)
            {
                if(nums[i] > max)
                {
                    max = nums[i];
                    index = i;
                }
            }
            int rootValue = max;
            TreeNode root = new TreeNode(rootValue);
            root.left = Build(nums, left, index - 1);
            root.right = Build(nums, index + 1, right);
            return root;
        }
    }
}
