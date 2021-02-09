using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLabuladong.Array
{
    public class SlidingWindow
    {
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
            Dictionary<char, int> need = new Dictionary<char, int>();
            Dictionary<char, int> window = new Dictionary<char, int>();
            foreach (char c in t)
                need[c]++;

            int left = 0, right = 0;
            int valid = 0;
            //记录最小覆盖字串的起始索引长度
            int start = 0, len = int.MaxValue;
            while(right < s.Length)
            {

            }
        }






    }
}
