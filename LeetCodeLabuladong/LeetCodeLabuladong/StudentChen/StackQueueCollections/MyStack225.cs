using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen.StackQueueCollections
{
    //225.用队列实现栈
    public class MyStack225
    {
        Queue<int> q;
        int top_elem = 0;
     
        public MyStack225()
        {
            q = new Queue<int>();
        }

        /** Push element x onto stack. */
        public void Push(int x)
        {
            q.Enqueue(x);
            top_elem = x;
        }

        /** Removes the element on top of the stack and returns that element. */
        public int Pop()
        {
            int len = q.Count;
            while (len > 2)
            {
                q.Enqueue(q.Dequeue());
                len--;
            }
            top_elem = q.Peek();
            q.Enqueue(q.Dequeue());
            return q.Dequeue();
        }

        /** Get the top element. */
        public int Top()
        {
            return top_elem;
        }

        /** Returns whether the stack is empty. */
        public bool Empty()
        {
            return q.Count == 0;
        }
    }
}
