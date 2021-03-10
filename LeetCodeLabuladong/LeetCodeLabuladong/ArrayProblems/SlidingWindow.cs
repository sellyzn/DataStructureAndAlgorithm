using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeLabuladong.ArrayProblems
{
    public class SlidingWindow
    {
        /*
         滑动窗口算法的思路：

        1、在字符串S中使用双指针中的左右指针技巧，初始化 left = right = 0， 
           把索引左闭右开区间 [left, right) 称为一个「窗口」。

        2、先不断地增加 right 指针，扩大窗口  [left, right)，
           直到窗口中的字符串符合要求（包含了T中的所有字符）。

        3、此时，停止增加 right，转而不断增加 left 指针，缩小窗口 [left, right)， 
           直到窗口中的字符串不再符合要求（不包含T中的所有字符了）。
           同时，每次增加 left，我们都要更新一轮结果。

        4、重复第 2 和第 3 布，直到 right 到达字符串 S 的尽头。

         */


        /* 滑动窗口算法框架 */
        //public void SliddingWindow(string s, string t)
        //{
        //    Dictionary<char, int> need = new Dictionary<char, int>();
        //    Dictionary<char, int> window = new Dictionary<char, int>();
        //    foreach (char c in t)
        //        need[c]++;

        //    int left = 0;
        //    int right = 0;
        //    int valid = 0;
        //    while(right < s.Length)
        //    {
        //        // c 是将移入窗口的字符
        //        char c = s[right];
        //        //右移窗口
        //        right++;
        //        //进行窗口内数据的一些列更新
        //        //...

        //        /*** debug输出的位置 ***/

        //        /**********************/

        //        //判断左侧窗口是否要收缩
        //        while(window needs shrink)
        //        {
        //                //
        //                char d = s[left];
        //                //左移窗口
        //                left++;
        //                //进行窗口内数据的一些列更新
        //                //...
        //        }          

        //    }
        //}



        public string MinWindow76(string s, string t)
        {
            // need 和 window 相当于计数器
            // need 记录 T 中字符出现的次数
            // window 记录「窗口」中相应字符出现的次数
            Dictionary<char, int> need = new Dictionary<char, int>();
            Dictionary<char, int> window = new Dictionary<char, int>();

            //遍历目标字串，记录 T 中字符出现的次数
            foreach (char c in t)
            {
                if (need.ContainsKey(c))
                    need[c]++;
                else
                    need[c] = 1;
            }

            int left = 0, right = 0;
            // valid 变量表示窗口中满足 need 条件的字符个数。
            //如果 valid 和 need.Count() 的大小相同，则说明窗口已满足条件，已经完全覆盖了串T。
            int valid = 0;
            //记录最小覆盖字串的起始索引长度
            int start = 0, len = int.MaxValue;
            while (right < s.Length)
            {
                // c 是将被移入窗口的字符
                char c = s[right];
                //右移窗口
                right++;
                //进行窗口内数据的一系列更新
                if (need.ContainsKey(c))
                {
                    if (need[c] > 0)  //如果T中有字符c
                    {
                        if (window.ContainsKey(c))
                            window[c]++;  //则window记录字符c的次数
                        else
                            window[c] = 1;
                        if (window[c] == need[c])  //如果window中字符c的次数和need中相等
                            valid++;  //则满足need条件 的字符个数值+1
                    }
                }
                else
                    continue;
                //判断左侧窗口是否收缩
                while(valid == need.Count())
                {
                    //在这里更新最小覆盖子串
                    if(right - left < len)
                    {
                        start = left;
                        len = right - left;
                    }
                    // d 是将移出窗口的字符
                    char d = s[left];
                    //左移窗口
                    left++;
                    //进行窗口内数据的一系列更新
                    if (need.ContainsKey(d))
                    {
                        if (need[d] > 0)
                        {
                            if (window[d] == need[d])
                                valid--;
                            window[d]--;
                        }
                    }
                    else
                        continue;
                }
            }
                //返回最小覆盖子串
                //return len == int.MaxValue ? "" : s.Substring(start, len);
            string res = "";
            if (len == int.MaxValue)
                return "";
            else
            {
                for (int i = start; i < start + len; i++)
                {
                    res += s[i];
                }
                return res;
            }
        }





        public bool CheckInclusion567(string t, string s)
        {
            Dictionary<char, int> need = new Dictionary<char, int>();
            Dictionary<char, int> window = new Dictionary<char, int>();
            
            foreach(char c in t)
            {
                if (need.ContainsKey(c))
                    need[c]++;
                else
                    need[c] = 1;
            }

            int left = 0, right = 0;
            int valid = 0;            
            while(right < s.Length)
            {
                char c = s[right];
                right++;

                if (need.ContainsKey(c))
                {
                    //if(need[c] > 0)
                    //{
                        if (window.ContainsKey(c))
                            window[c]++;
                        else
                            window[c] = 1;
                        if (window[c] == need[c])
                            valid++;
                    //}
                }
                //else
                //{
                //    continue;
                //}
                
                while(right - left >= t.Length)
                {
                    if (valid == need.Count())
                        return true;
                    char d = s[left];
                    left++;
                    if (need.ContainsKey(d))
                    {
                        //if(need[d] > 0)
                        //{
                            window[d]--;
                            if (window[d] == need[d])
                                valid--;
                        //}
                    }
                    //else
                    //{
                    //    continue;
                    //}
                }
            }
            return false;
        }


        //438、找到字符串中所有字母异位词
        public IList<int> FindAnagrams438(string s, string p)
        {
            Dictionary<char, int> need = new Dictionary<char, int>();
            Dictionary<char, int> window = new Dictionary<char, int>();

            List<int> res = new List<int>();

            foreach (char c in p)
            {
                if (need.ContainsKey(c))
                    need[c]++;
                else
                    need[c] = 1;
            }

            int left = 0, right = 0;
            int valid = 0;
            while (right < s.Length)
            {
                char c = s[right];
                right++;

                if (need.ContainsKey(c))
                {
                    //if(need[c] > 0)
                    //{
                    if (window.ContainsKey(c))
                        window[c]++;
                    else
                        window[c] = 1;
                    if (window[c] == need[c])
                        valid++;
                    //}
                }
                //else
                //{
                //    continue;
                //}

                while (right - left >= p.Length)
                {
                    if (valid == need.Count())
                        res.Add(left);
                    char d = s[left];
                    left++;
                    if (need.ContainsKey(d))
                    {
                        //if(need[d] > 0)
                        //{
                        window[d]--;
                        if (window[d] == need[d])
                            valid--;
                        //}
                    }
                    //else
                    //{
                    //    continue;
                    //}
                }
            }
            return res;
        }



        //3、无重复字符的最长子串
        public int LengthOfLongestSubstring(string s)
        {
            if (s == null || s.Length == 0)
                return 0;
            Dictionary<char, int> window = new Dictionary<char, int>();
            int left = 0, right = 0;
            int res = 0;
            while(right < s.Length)
            {
                char c = s[right];
                right++;
                //window[c]++;
                if (window.ContainsKey(c))
                    window[c]++;
                else
                    window[c] = 1;

                while (window[c] > 1)
                {
                    char d = s[left];
                    left++;
                    window[d]--;
                }
                res = Math.Max(res, right - left);
            }
            return res;
        }
    }
}
