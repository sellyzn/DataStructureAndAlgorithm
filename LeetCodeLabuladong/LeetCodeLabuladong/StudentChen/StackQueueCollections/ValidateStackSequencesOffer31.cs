using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen.StackQueueCollections
{
    public class ValidateStackSequencesOffer31
    {
        //剑指Offer31.栈的压入、弹出序列
        /*
         借助一个辅助栈stack，模拟压入/弹出操作的排列，根据是否模拟成功，即可得结果。
        入栈操作：按照压栈序列的顺序执行。
        出栈操作：每次入栈后，循环判断“栈顶元素=弹出序列的当前元素”是否成立，将符合弹出序列顺序的栈顶元素全部弹出。

        1.初始化：辅助栈stack，弹出序列的索引i；
        2.遍历压栈序列：各元素记为num;
            1)元素 num 入栈；
            2)循环出栈：若 stack 的栈顶元素 = 弹出序列元素 popped[i] ，则执行出栈与 i++ ；
        3.返回值： 若 stack 为空，则此弹出序列合法。


         */
        public bool ValidateStackSequences(int[] pushed, int[] popped)
        {
            Stack<int> stack = new Stack<int>();
            int i = 0;
            foreach (int num in pushed)
            {
                stack.Push(num);
                while(stack.Count != 0 && stack.Peek() == popped[i]){
                    stack.Pop();
                    i++;
                }
            }
            return stack.Count == 0;
        }
    }
}
