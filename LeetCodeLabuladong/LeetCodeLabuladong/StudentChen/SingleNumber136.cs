using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen
{
    public class SingleNumber136
    {
        //136.只出现一次的数字
        /*
        给定一个非空整数数组，除了某个元素只出现一次以外，其余每个元素均出现两次。
        找出那个只出现了一次的元素。

        说明：
        你的算法应该具有线性时间复杂度。 你可以不使用额外空间来实现吗？

         */

        //异或运算^
        /*
        异或运算有以下三个性质:

        1.任何数和 00 做异或运算，结果仍然是原来的数，即 a⊕0=a。
        2.任何数和其自身做异或运算，结果是 0，即 a⊕a=0。
        3.异或运算满足交换律和结合律，即 a⊕b⊕a=b⊕a⊕a=b⊕(a⊕a)=b⊕0=b。

        复杂度分析:
        时间复杂度：O(n)O(n)，其中 nn 是数组长度。只需要对数组遍历一次。
        空间复杂度：O(1)O(1)。
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

        //136.只出现一次的数字II
        /*
        给定一个非空整数数组，除了某个元素只出现一次以外，其余每个元素均出现了三次。
        找出那个只出现了一次的元素。

        说明：
        你的算法应该具有线性时间复杂度。 你可以不使用额外空间来实现吗？

         */

        /*
         思路:

        使用位运算符可以实现 O(1) 的空间复杂度。
       
        ∼x表示位运算 NOT
        x&y表示位运算 AND
        x⊕y表示位运算 XOR

        XOR:
        该运算符用于检测出现奇数次的位：1、3、5 等。

        0 与任何数 XOR 结果为该数。
        0⊕x=x

        两个相同的数 XOR 结果为 0。
        x⊕x=0

        AND 和 NOT:
        为了区分出现一次的数字和出现三次的数字，使用两个位掩码：seen_once 和 seen_twice。

        思路是：
        仅当 seen_twice 未变时，改变 seen_once。
        仅当 seen_once 未变时，改变seen_twice。
        位掩码 seen_once 仅保留出现一次的数字，不保留出现三次的数字。

        复杂度分析:
        时间复杂度：\mathcal{O}(N)O(N)，遍历输入数组。
        空间复杂度：\mathcal{O}(1)O(1)，不使用额外空间。
         */

        /*
        once = ~twice & (once ^ num);
        twice = ~once & (twice ^ num);
        第一次出现时，once和twice均为0，once^num相当于把num添加到once，表示num出现了一次，~once表示不把num添加到twice；
        第二次出现时，num已经添加到once了，num^num=0，once=0，相当于将num从once中删除，twice^num相当于把num添加到twice中；
        第三次出现时，第二次的twice为1，~twice为0，所以once依然为0，第三次的twice=num^num=0，相当于把num从twice中删除；
         */

        public int SingleNumberII(int[] nums)
        {
            int once = 0, twice = 0;
            foreach (int num in nums)
            {
                once = ~twice & (once ^ num);
                twice = ~once & (twice ^ num);
            }
            return once;
        }

    }
}
