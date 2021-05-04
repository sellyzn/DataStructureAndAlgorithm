
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen
{
    public class SingleNumbersOffer56
    {
        //剑指 Offer 56 - I. 数组中数字出现的次数
        //260. 只出现一次的数字 III
        //一个整型数组 nums 里除两个数字之外，其他数字都出现了两次。
        //请写程序找出这两个只出现一次的数字。要求时间复杂度是O(n)，空间复杂度是O(1)。

        //分组异或
        /*
         如何分组？
        1.两个只出现一次的数字在 不同的组中
        2.相同的数字会被分到相同的组中


        算法

        先对所有数字进行一次异或，得到两个出现一次的数字的异或值。
        在异或结果中找到任意为 1 的位。
        根据这一位对所有的数字进行分组。
        在每个组内进行异或操作，得到两个数字。


         */
        public int[] SingleNumbers(int[] nums)
        {
            //1.对所有数字进行异或，得到两个出现一次的数字的异或值
            int ret = 0;
            foreach (int num in nums)
            {
                ret ^= num;
            }
            //在抑或结果中找到任意为1的位
            int div = 1;
            while((div & ret) == 0)    //与操作&，找到为1的最低位
            {
                div <<= 1;
            }

            //根据这一位对所有的数字进行分组，在每个组内进行异或操作
            int a = 0, b = 0;
            foreach (int num in nums)
            {
                if((div & num) != 0)    //与操作&，区分是否为1
                {
                    a ^= num;   //异或操作
                }
                else
                {
                    b ^= num;   //异或操作
                }
            }
            //得到两个数字
            return new int[] { a, b };

        }
        //剑指 Offer 56 - II. 数组中数字出现的次数 II
        //在一个数组 nums 中除一个数字只出现一次之外，其他数字都出现了三次。请找出那个只出现一次的数字。
        
        public int SingleNumberII(int[] nums)
        {
            int once = 0, twice = 0;
            foreach(int num in nums)
            {
                once = ~twice & (once ^ num);
                twice = ~once & (twice ^ num);
            }
            return once;
        }
    }
}
