using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.DataStructureDesignProblems
{
    //面试题03.04. 化栈为队
    public class MyQueue
    {
        private Stack<int> s1, s2;
        public MyQueue()
        {
            s1 = new Stack<int>();
            s2 = new Stack<int>();
        }

        ////队头
        //private Stack<int> s1 = new Stack<int>();
        ////队尾
        //private Stack<int> s2 = new Stack<int>();

        /** 添加元素到队尾  AppendTail */
        public void Push(int x)
        {
            //while(s1.Count != 0)
            //{
            //    s2.Push(s1.Pop());
            //}
            s2.Push(x);
        }

        /** 删除队头的元素并返回 DeleteHead */
        public int Pop()
        {
            Peek();
            return s1.Pop();
        }

        /** 返回队头元素 */
        public int Peek()
        {
            if(s1.Count == 0)
            {
                while(s2.Count != 0)
                {
                    s1.Push(s2.Pop());
                }
            }
            return s1.Peek();
        }

        /** 判断队列是否为空 */
        public bool Empty()
        {
            return s1.Count == 0 && s2.Count == 0;
        }
    }
}
