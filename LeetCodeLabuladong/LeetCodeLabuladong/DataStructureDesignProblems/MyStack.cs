using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.DataStructureDesignProblems
{
    public class MyStack
    {     
        Queue<int> q;
        int top_elem = 0;

        public MyStack()
        {
            q = new Queue<int>();
        }

        public void Push(int x)
        {
            q.Enqueue(x);
            top_elem = x;
        }

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

        public int Top()
        {
            return top_elem;
        }

        public bool Empty()
        {
            return q.Count == 0;
        }
    }
}
