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
        //一个队列实现栈
        //Queue<int> q;
        //int top_elem = 0;

        //public MyStack225()
        //{
        //    q = new Queue<int>();
        //}

        ///** Push element x onto stack. */
        //public void Push(int x)
        //{
        //    q.Enqueue(x);
        //    top_elem = x;
        //}

        ///** Removes the element on top of the stack and returns that element. */
        //public int Pop()
        //{
        //    int len = q.Count;
        //    while (len > 2)
        //    {
        //        q.Enqueue(q.Dequeue());
        //        len--;
        //    }
        //    top_elem = q.Peek();
        //    q.Enqueue(q.Dequeue());
        //    return q.Dequeue();
        //}

        ///** Get the top element. */
        //public int Top()
        //{
        //    return top_elem;
        //}

        ///** Returns whether the stack is empty. */
        //public bool Empty()
        //{
        //    return q.Count == 0;
        //}

        ////用两个队列实现栈

        //Queue<int> q1, q2;        

        //public MyStack225()
        //{
        //    q1 = new Queue<int>();
        //    q2 = new Queue<int>();
        //}

        ///** Push element x onto stack. */
        //public void Push(int x)
        //{
        //    //将元素入队到q2;
        //    q2.Enqueue(x);
        //    //将q1中的元素全部入队到q2中去
        //    while(q1.Count != 0)
        //    {
        //        q2.Enqueue(q1.Dequeue());
        //    }
        //    //利用中间变量temp，交换q1, q2
        //    Queue<int> temp = q1;
        //    q1 = q2;
        //    q2 = temp;

        //}

        ///** Removes the element on top of the stack and returns that element. */
        //public int Pop()
        //{
        //    return q1.Dequeue(); 
        //}

        ///** Get the top element. */
        //public int Top()
        //{
        //    return q1.Peek();
        //}

        ///** Returns whether the stack is empty. */
        //public bool Empty()
        //{
        //    return q1.Count == 0;
        //}


        //
        Queue<int> queue;

        public MyStack225()
        {
            queue = new Queue<int>();            
        }

        /** Push element x onto stack. */
        public void Push(int x)
        {
            //计算入栈前的元素个数
            int n = queue.Count;
            //元素入队列
            queue.Enqueue(x);
            //将队列的前n个元素出队，并入队到队列
            for(int i = 0; i < n; i++)
            {
                queue.Enqueue(queue.Dequeue());
            }
        }

        /** Removes the element on top of the stack and returns that element. */
        public int Pop()
        {
            return queue.Dequeue();
        }

        /** Get the top element. */
        public int Top()
        {
            return queue.Peek();
        }

        /** Returns whether the stack is empty. */
        public bool Empty()
        {
            return q1.Count == 0;
        }

    }
}
