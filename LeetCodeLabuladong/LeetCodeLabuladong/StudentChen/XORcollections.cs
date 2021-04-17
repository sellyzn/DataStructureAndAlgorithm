using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen
{
    class XORcollections
    {
        //136.只出现一次的数字
        /*
        给定一个非空整数数组，除了某个元素只出现一次以外，其余每个元素均出现两次。找出那个只出现了一次的元素。

        说明：
        你的算法应该具有线性时间复杂度。 你可以不使用额外空间来实现吗？

         */
        public int SingleNumber(int[] nums)
        {
            int res = 0;
            foreach (int num in nums)
            {
                res ^= num;
            }
            return res;
        }


        //137.只出现一次的数字II
        /*
        给定一个非空整数数组，除了某个元素只出现一次以外，其余每个元素均出现了三次。找出那个只出现了一次的元素。

        说明：
        你的算法应该具有线性时间复杂度。 你可以不使用额外空间来实现吗？

         */
        public int SingleNumberII(int[] nums)
        {
            int once = 0, twice = 0;
            foreach (int num in nums)
            {
                //位运算符:
                // ~ : 取反运算符,按二进制位进行取反运算
                // & : 按位与操作
                // ^ : 异或运算符, 相同为0,不同为1.
                once = ~twice & (once ^ num);
                twice = ~once & (twice ^ num);
            }
            return once;
        }


        //260.只出现一次的数字III
        /*
        给定一个整数数组 nums，其中恰好有两个元素只出现一次，其余所有元素均出现两次。 找出只出现一次的那两个元素。你可以按 任意顺序 返回答案。

        进阶：你的算法应该具有线性时间复杂度。你能否仅使用常数空间复杂度来实现？

         */

        /*
         * 思路:
        把所有数字分成两组，使得：
        1.两个只出现一次的数字在不同的组中；
        2.相同的数字会被分到相同的组中.
        
        算法:
        先对所有数字进行一次异或，得到两个出现一次的数字的异或值。
        在异或结果中找到任意为 1 的位。
        根据这一位对所有的数字进行分组。
        在每个组内进行异或操作，得到两个数字。
         */
        public int[] SingleNumberIII(int[] nums)
        {
            //对所有数字进行异或,得到两个出现一次的数字的异或值 ret
            int ret = 0;
            foreach (int num in nums)
            {
                ret ^= num;
            }
            //在异或结果ret中任意为 1 的位(选取不为0的最低位)
            int div = 1;
            while((div & ret) == 0)
            {
                div <<= 1;
            }
            //根据上述位对所有的数字进行分组()
            /*
            如果我们把 a 和 b 写成二进制的形式，ai和 bi的关系xi=1 表示 ai和 bi不等，xi=0 表示 ai和 bi相等。

             */
            int a = 0, b = 0;
            foreach (int num in nums)
            {
                if ((div & num) != 0)  //div == ??
                {
                    a ^= num;
                }
                else
                {
                    b ^= num;
                }
            }
            return new int[] { a, b };
        }


    }
}
