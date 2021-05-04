using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen
{
    public class IsValid20
    {
        //20.有效的括号

        public bool IsValid(string s)
        {
            Dictionary<char, char> pairs = new Dictionary<char, char>();
            pairs.Add('(',')');
            pairs.Add('[',']');
            pairs.Add('{','}');
            pairs.Add('?', '?');

            Stack<char> stack = new Stack<char>();
            stack.Push('?');
            for(int i = 0; i < s.Length; i++)
            {
                if (pairs.ContainsKey(s[i]))
                    stack.Push(s[i]);
                else if (pairs[stack.Pop()] != s[i])
                    return false;
            }
            return stack.Count == 1;
        }

        //22. 括号生成
        public IList<string> GenerateParenthesis(int n)
        {

        }
    }
}
