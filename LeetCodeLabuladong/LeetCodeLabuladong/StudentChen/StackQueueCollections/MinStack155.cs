using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen.StackQueueCollections
{
    //155.最小栈
    //剑指Offer30. 包含min函数的栈
    //定义栈的数据结构，请在该类型中实现一个能够得到栈的最小元素的 min 函数。
    //在该栈中，调用 min、push 及 pop 的时间复杂度都是 O(1)。
    public class MinStack155
    {
        private Stack<int> stack;
        private Stack<int> minStack;
        public MinStack155()
        {
            stack = new Stack<int>();
            minStack = new Stack<int>();
        }

        public void Push(int val)
        {
            stack.Push(val);
            if (minStack.Count == 0 || val <= minStack.Peek())
                minStack.Push(val);
        }

        public void Pop()
        {
            if (stack.Pop().Equals(minStack.Peek()))  //if(stack.Pop() == GetMin())
                minStack.Pop();
        }

        public int Top()
        {
            return stack.Peek();
        }

        public int GetMin()
        {
            return minStack.Peek();
        }
    }
}
