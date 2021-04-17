using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen
{
    public class PlusOne66
    {
        //66.加一
        /*
        给定一个由 整数 组成的 非空 数组所表示的非负整数，在该数的基础上加一。

        最高位数字存放在数组的首位， 数组中每个元素只存储单个数字。

        你可以假设除了整数 0 之外，这个整数不会以零开头。

         */


        /*
         是9就改为0，不是9就+1，最后如果全进位，则数组长度+1，且第一位元素设置为1
         */
        public int[] PlusOne(int[] digits)
        {
            //int carry = 0;
            //for(int i = digits.Length - 1; i >= 0; i--)
            //{
            //    int tmp = digits[i];
            //    digits[i] = tmp == 9 ? 0 : digits[i] + carry;
            //    carry = tmp == 9 ? 1 : 0;
            //}
            //if (carry == 1)
            //{
            //    int[] res = new int[digits.Length + 1];
            //    res[0] = carry;
            //    for (int i = 1; i < digits.Length + 1; i++)
            //    {
            //        res[i] = digits[i - 1];
            //    }
            //    return res;
            //}
            //else
            //    return digits;    
            
            for(int i = digits.Length - 1; i >= 0; i--)
            {
                //digits[i]++;
                //digits[i] %= 10;
                //if (digits[i] != 0)
                //    return digits;
                if (digits[i] != 9)
                {
                    digits[i]++;
                    return digits;
                }
                else
                {
                    digits[i] = 0;
                }
            }
            digits = new int[digits.Length + 1];
            digits[0] = 1;
            return digits;
        }
    }
}
