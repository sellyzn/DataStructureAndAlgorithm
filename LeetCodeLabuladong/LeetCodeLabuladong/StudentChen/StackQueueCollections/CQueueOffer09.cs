using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen.StackQueueCollections
{
    //剑指Offer09.用两个栈实现队列
    //两个栈实现队列。两个函数，分别完成在队尾插入和在队头删除的功能，没有元素，则删除操作返回-1.
    
    //思路：
    //两个栈，一个进，一个出：stackIn, stackOut;
    //队尾插入功能：直接在stackIn中push要插入的元素即可
    //队头删除功能：若stackOut不为空，则stackOut.Pop();
    //             若stackOut为空，则将stackIn中的元素全部push到stackOut中，此时，再根据stackOut是否为空，返回-1或stackOut.Pop().
    public class CQueueOffer09
    {
        private Stack<int> stackIn, stackOut;
        public CQueueOffer09()
        {
            stackIn = new Stack<int>();
            stackOut = new Stack<int>();
        }

        public void AppendTail(int value)
        {
            stackIn.Push(value);
        }

        public int DeleteHead()
        {
            if(stackOut.Count != 0)
            {
                return stackOut.Pop();
            }
            else
            {
                while (stackIn.Count != 0)
                    stackOut.Push(stackIn.Pop());
                return stackOut.Count == 0 ? -1 : stackOut.Pop();
            }
        }
    }
}
