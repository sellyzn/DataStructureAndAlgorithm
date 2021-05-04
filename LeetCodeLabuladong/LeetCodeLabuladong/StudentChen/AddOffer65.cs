using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen
{
    public class AddOffer65
    {
        //剑指Offer65. 不用加减乘除做加法
        //位运算：
        //无进位和 与 异或 规律相同
        //进位 和 与运算 规律相同（并左移一位）

        //无进位和n，进位c
        //n = a ⊕ b        非进位和：异或运算
        //c = a & b << 1    进位：与运算+左移一位
        //（和s） = （非进位和n） + （进位c）

        //即可将 s = a + b 转化为：       
        //s=a+b⇒s=n+c
        //循环求 n 和 c ，直至进位 c = 0 ；此时 s = n ，返回 n 即可。


        public int Add(int a, int b)
        {
            while(b != 0)  //当进位为 0 时跳出
            {
                int c = (a & b) << 1; // c = 进位
                a ^= b; // a = 非进位和
                b = c;  //b = 进位
            }
            return a;
        }
    }
}
