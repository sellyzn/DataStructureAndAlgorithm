using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen
{
    public class ReverseWordsOffer58I
    {
        //剑指Offer58-I. 反转单词顺序
        //双指针
        //string.Substring(int startIndex, int length)
        public string ReverseWords(string s)
        {
            s = s.Trim(); //删除首尾空格
            if (s == null || s.Length == 0)
                return "";
            int j = s.Length - 1, i = j;
            StringBuilder res = new StringBuilder();
            while(i >= 0)
            {
                while (i >= 0 && s[i] != ' ')   //搜索首个空格
                    i--;
                res.Append(s.Substring(i + 1, j - i) + " ");    //添加单词
                while (i >= 0 && s[i] == ' ')   //跳过单词间空格
                    i--;
                j = i;  // j 指向下个单词的尾字符
            }
            return res.ToString().Trim();   //转化为字符串并返回
        }
    }
}
