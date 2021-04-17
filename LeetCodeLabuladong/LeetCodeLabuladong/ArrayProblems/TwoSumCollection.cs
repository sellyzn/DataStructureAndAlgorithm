using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLabuladong.ArrayProblems
{
    public class TwoSumCollection
    {
        //public IList<IList<int>> ThreeSum(int[] nums)
        //{
        //    //求和为0的三元组
        //    return TreeSumTarget(nums, 0);
        //}

        ///*计算数组nums中所有和为target的三元组*/
        //public IList<IList<int>> ThreeSumTarget(int[] nums, int target)
        //{
        //    //输入数组nums，返回所有和为target的三元组
        //    //数组排个序
        //    Sort(nums.begin(), nums.end());
        //    int n = nums.Length;
        //    List<List<int>> res;
        //    //穷举threeSum的第一个数
        //    for(int i = 0; i < n; i++)
        //    {
        //        //对target - nums[i] 计算TwoSum
        //        List<List<int>> tuples = TwoSumTarget(nums, i + 1; target - nums[i]);
        //        //如果存在满足条件的二元组，再加上nums[i]就是结果三元组
        //        for(var tuple in tuples)
        //        {
        //        tuple.Add(nums[i]);
        //        res
        //        }

        //    }
        //}


        public IList<IList<int>> TwoSum(int[] nums)
        {
            Array.Sort(nums);
            return nSumTarget(nums, 2, 0, 0);
        }

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            return nSumTarget(nums, 3, 0, 0);
        }

        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            Array.Sort(nums);
            return nSumTarget(nums, 4, 0, target);
        }
        

        /********nSum*********/
        public IList<IList<int>> nSumTarget(int[] nums, int n, int start, int target)
        {
            int len = nums.Length;
            List<IList<int>> res = new List<IList<int>>();

            if (n < 2 || len < n)
                return res;
            if(n == 2)
            {
                int lo = start, hi = len - 1;
                while(lo < hi)
                {
                    int sum = nums[lo] + nums[hi];
                    int left = nums[lo], right = nums[hi];
                    if(sum < target)
                    {
                        while (lo < hi && nums[lo] == left)
                            lo++;
                    }else if(sum > target)
                    {
                        while (lo < hi && nums[hi] == right)
                            hi--;
                    }
                    else
                    {
                        List<int> sub = new List<int> { left, right };
                        res.Add(sub);
                        while (lo < hi && nums[lo] == left)
                            lo++;
                        while (lo < hi && nums[hi] == right)
                            hi--;
                    }
                }
            }
            else
            {
                for(int i = start; i < len; i++)
                {
                    IList<IList<int>> sub = nSumTarget(nums, n - 1, start + 1, target - nums[i]);
                    foreach(var arr in sub)
                    {
                        arr.Add(nums[i]);
                        res.Add(arr);
                    }
                    while (i < len - 1 && nums[i] == nums[i + 1])
                        i++;
                }
            }

            return res;
        }




    }
}
