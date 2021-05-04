using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen
{
    public class SearchInsert35
    {
        //35. 搜索插入位置
        //给定一个排序数组和一个目标值，在数组中找到目标值，并返回其索引。
        //如果目标值不存在于数组中，返回它将会被按顺序插入的位置。

        //你可以假设数组中无重复元素。

        //二分查找
        //题目转化为：在一个有序数组中找出第一个大于等于target的下标。


        public int SearchInsert(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            int res = nums.Length;
            while(left <= right)
            {
                int mid = left + (right - left) / 2;
                if(nums[mid] >= target)
                {
                    res = mid;
                    right = mid - 1;   //缩小右边界
                }
                else
                {
                    left = mid + 1;
                }
            }
            return res;
        }
        public int SearchInsert1(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            while(left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return left;
        }
    }
}
