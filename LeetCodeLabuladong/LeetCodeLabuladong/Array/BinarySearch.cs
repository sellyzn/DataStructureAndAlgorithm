using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLabuladong.Array
{
    public class BinarySearch
    {
        /*二分查找经典应用：
         * 1、在有序数组中搜索给定的某个目标值的索引
         * 2、如果目标值存在重复，修改版的二分查找可以返回目标值的左侧边界索引或者右侧边界索引
         * 
         */

        //寻找一个数（基本的二分搜索）
        public int BinarySearch1(int[] nums,int target)
        {
            int left = 0;
            int right = nums.Length - 1;   //
            while(left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] < target)
                    left = mid + 1;
                else if (nums[mid] > target)
                    right = mid - 1;
            }
            return -1;
        }


        //寻找左侧边界的二分搜索
        public int LeftBound1(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length;  //搜索区间为左闭右开[left,right)
            while(left < right)   //终止条件是left == right,此时搜索区间[left,left)为空，所以可以正确种植。
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                    right = mid;
                else if (nums[mid] < target)
                    left = mid + 1;
                else if (nums[mid] > target)
                    right = mid;  //为什么left=mid+1,right=mid？搜索区间是[left,right)左闭右开，所以当nums[mid]被检测之后，下一步的搜索区间应该去点mid分割成两个区间，即[left,mid)或[mid+1,right).
            }
            //return left;
            if (left == nums.Length)
                return -1;
            return nums[left] == target ? left : -1;
        } 

        //寻找左边界搜索区间改成两端都闭
        public int LeftBound2(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            //搜索区间为[left,right]
            while(left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                    //收缩右侧边界，锁定右侧边界
                    right = mid - 1;
                else if (nums[mid] < target)
                    //搜索区间变为[mid+1,right]
                    left = mid + 1;
                else if (nums[mid] > target)
                    //搜索区间变为[left,mid-1]
                    right = mid - 1;
            }
            //最后检查left越界的情况
            if (left >= nums.Length || nums[left] != target)
                return -1;
            return left;
        }


        //寻找右侧边界的二分查找
        //搜索区间：左闭右开
        public int RightBound1(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length;
            while(left < right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                    //不返回，锁定左侧边界
                    left = mid + 1;
                else if (nums[mid] < target)
                    left = mid + 1;
                else if (nums[mid] > target)
                    right = mid;
            }
            //return left - 1;
            if (left == 0)
                return -1;
            return nums[left - 1] == target ? (left - 1) : -1;
        }

        //搜索区间：左闭右闭
        public int RightBound2(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            while(left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                    //不返回，锁定左侧边界
                    left = mid + 1;
                else if (nums[mid] < target)
                    left = mid + 1;
                else if (nums[mid] > target)
                    right = mid - 1;
            }
            //最后检查right越界的情况
            if (right < 0 || nums[right] != target)
                return -1;
            return right;
        }

        /*


        第一个，最基本的二分查找算法：

        因为我们初始化 right = nums.length - 1
        所以决定了我们的「搜索区间」是[left, right]
        所以决定了 while (left <= right)
        同时也决定了 left = mid + 1 和 right = mid - 1

        因为我们只需找到一个 target 的索引即可
        所以当 nums[mid] == target 时可以立即返回

        第二个，寻找左侧边界的二分查找：

        因为我们初始化 right = nums.length
        所以决定了我们的「搜索区间」是[left, right)
        所以决定了 while (left < right)
        同时也决定了 left = mid + 1 和 right = mid

        因为我们需找到 target 的最左侧索引
        所以当 nums[mid] == target 时不要立即返回
        而要收紧右侧边界以锁定左侧边界

        第三个，寻找右侧边界的二分查找：

        因为我们初始化 right = nums.length
        所以决定了我们的「搜索区间」是[left, right)
        所以决定了 while (left < right)
        同时也决定了 left = mid + 1 和 right = mid

        因为我们需找到 target 的最右侧索引
        所以当 nums[mid] == target 时不要立即返回
        而要收紧左侧边界以锁定右侧边界

        又因为收紧左侧边界时必须 left = mid + 1
        所以最后无论返回 left 还是 right，必须减一

        */


        //二分查找的一个技巧是： 不要出现else，而是把所有情况用else if写清楚。


        public int Binarysearch(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else if (nums[mid] == target)
                {
                    // 直接返回
                    return mid;
                }
            }
            // 直接返回
            return -1;
        }

        int LeftBound(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else if (nums[mid] == target)
                {
                    // 别返回，锁定左侧边界
                    right = mid - 1;
                }
            }
            // 最后要检查 left 越界的情况
            if (left >= nums.Length || nums[left] != target)
                return -1;
            return left;
        }


        int RightBound(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else if (nums[mid] > target)
                {
                    right = mid - 1;
                }
                else if (nums[mid] == target)
                {
                    // 别返回，锁定右侧边界
                    left = mid + 1;
                }
            }
            // 最后要检查 right 越界的情况
            if (right < 0 || nums[right] != target)
                return -1;
            return right;
        }

    }
}
