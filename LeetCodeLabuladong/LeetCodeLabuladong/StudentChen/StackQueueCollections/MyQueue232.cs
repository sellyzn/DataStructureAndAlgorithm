using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen.StackQueueCollections
{
    //232.用栈实现队列
    
    public class MyQueue232
    {
        private Stack<int> s1, s2;
       
        public MyQueue232()
        {
            s1 = new Stack<int>();
            s2 = new Stack<int>();
        }

        /** Push element x to the back of queue. */
        public void Push(int x)
        {
            s2.Push(x);
        }

        /** Removes the element from in front of queue and returns that element. */
        public int Pop()
        {
            Peek();
            return s1.Pop();
        }

        /** Get the front element. */
        public int Peek()
        {
            if (s1.Count == 0)
            {
                while (s2.Count != 0)
                {
                    s1.Push(s2.Pop());
                }
            }
            return s1.Peek();
        }

        /** Returns whether the queue is empty. */
        public bool Empty()
        {
            return s1.Count == 0 && s2.Count == 0;
        }
    }
}
