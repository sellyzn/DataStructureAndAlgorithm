using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen
{
    public class SearchOffer53I
    {
        //剑指Offer 53-I. 在排序数组中查找数字I

        public int Search(int[] nums, int target)
        {
            //搜索左边界
            int i = 0, j = nums.Length - 1;
            while(i <= j)
            {
                int mid = i + (j - i) / 2;
                if (nums[mid] < target)
                    i = mid + 1;
                else
                    j = mid - 1;
            }
            int left = i;

            //搜索右边界
            i = 0;
            j = nums.Length - 1;
            while(i <= j)
            {
                int mid = i + (j - i) / 2;
                if (nums[mid] <= target)
                    i = mid + 1;
                else
                    j = mid - 1;
            }
            int right = j;

            //计算长度
            return right - left + 1;
        }

        public int SearchUp(int[] nums, int target)
        {
            return SearchRightEdge(nums,target) - SearchRightEdge(nums,target - 1);
        }
        public int SearchRightEdge(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;
            //while(left <= right)
            //{
            //    int mid = left + (right - left) / 2;
            //    if (nums[mid] > target)
            //        right = mid - 1;
            //    else
            //        left = mid + 1;
            //}
            //return right;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] > target)
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            return left; //返回大于target的第一个元素位置
        }

    }
}
