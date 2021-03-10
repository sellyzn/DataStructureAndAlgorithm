using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.DataStructureDesignProblems
{
    public class MonotonicStackProblems
    {
        // original
        //给你一个数组，返回一个等长的数组，对应索引存储着下一个更大元素，如果没有更大的元素，就存 -1.
        //单调栈
        public int[] NextGreaterElement(int[] nums)
        {
            int[] res = new int[nums.Length];  //存放答案的数组
            Stack<int> s = new Stack<int>(); 
            //倒着网栈里放
            for(int i = nums.Length - 1; i >= 0; i--)
            {
                //判定个子高矮
                while(s.Count() != 0 && s.Peek() <= nums[i])
                {
                    //矮个起开，反正也被挡着了。。。
                    s.Pop();
                }
                //nums[i] 身后的next greater number
                res[i] = s.Count() == 0 ? -1 : s.Peek();
                //
                s.Push(nums[i]);
            }
            return res;
        }

        //496、下一个更大元素I
        //1、忽略nums1， 先对nums2中的元素，求出其下一个更大元素。
        //2、将nums2[i]与对应的答案放入hashmap（Dictionary）中，然后对nums1进行遍历。
        public int[] NextGreaterElementI(int[] nums1,  int[] nums2)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            Stack<int> s = new Stack<int>();
            for(int i = nums2.Length - 1; i >= 0; i--)
            {
                while(s.Count != 0 && s.Peek() <= nums2[i])
                {
                    s.Pop();
                }
                int temp = s.Count() == 0 ? -1 : s.Peek();
                dict.Add(nums2[i], temp);
                s.Push(nums2[i]);
            }
            int[] res = new int[nums1.Length];
            for(int i = 0; i < nums1.Length; i++)
            {
                res[i] = dict[nums1[i]];
            }
            return res;
        }


        //1118、一个月有多少天
        //给你一个数组T，这个数组存放的是近几天的天气气温，你返回一个等长的数组，
        //计算：对于每一天，你还要至少等多少天才能等到一个更暖和的气温；如果等不到那一天，填 0。


        public int[] DailyTemperatures(int[] T)
        {
            int[] res = new int[T.Length];
            //这里放元素索引，而不是元素
            Stack<int> s = new Stack<int>();
            //单调栈模板
            for(int i = T.Length - 1; i >= 0; i--)
            {
                while(s.Count != 0 && T[s.Peek()] <= T[i])
                {
                    s.Pop();
                }
                // 得到索引间距
                res[i] = s.Count == 0 ? 0 : (s.Peek() - i);
                //将索引入栈，而不是元素值
                s.Push(i);
            }
            return res;
        }

        //环形数组
        //503、下一个更大元素II
        //套路：将数组长度翻倍
        //通过%运算符求模（余数），来获得环形特效

        public int[] NextGreaterElementsII(int[] nums)
        {
            int n = nums.Length;
            int[] res = new int[n];
            Stack<int> s = new Stack<int>();
            for(int i = 2 * n - 1; i >= 0; i--)
            {
                while(s.Count != 0 && s.Peek() <= nums[i % n])
                {
                    s.Pop();
                }
                res[i % n] = s.Count == 0 ? -1 : s.Peek();
                s.Push(nums[i % n]);
            }
            return res;
        }






    }
}
