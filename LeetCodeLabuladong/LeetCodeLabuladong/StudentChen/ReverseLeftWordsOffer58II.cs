using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen
{
    public class ReverseLeftWordsOffer58II
    {
        //剑指Offer58-II. 左旋转字符串

        public string ReverseLeftWordsSlice(string s, int n)
        {
            return s.Substring(n, s.Length - n) + s.Substring(0, n);
        }

        //traverse + splice
        public string ReverseLeftWords(string s, int n)
        {
            StringBuilder res = new StringBuilder();
            for(int i = n; i < s.Length; i++)
            {
                res.Append(s[i]);
            }
            for(int i = 0; i < n; i++)
            {
                res.Append(s[i]);
            }
            return res.ToString();
        }
        //求余化简
        public string ReverseLeftWordsUp(string s, int n)
        {
            StringBuilder res = new StringBuilder();
            for(int i = n; i < n + s.Length; i++)
            {
                res.Append(s[i % s.Length]);
            }
            return res.ToString();
        }
    }
}
