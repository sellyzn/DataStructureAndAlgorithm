using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen.TreeCollections
{
    public class SortedArrayToBST108
    {
        public TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return null;
            return Traverse(nums, 0, nums.Length - 1);
        }
        public TreeNode Traverse(int[] nums, int left, int right)
        {
            if (left > right)
                return null;
            int mid = left + (right - left) / 2;
            TreeNode root = new TreeNode(nums[mid]);
            root.left = Traverse(nums, left, mid - 1);
            root.right = Traverse(nums, mid + 1, right);
            return root;
        }
    }
}
