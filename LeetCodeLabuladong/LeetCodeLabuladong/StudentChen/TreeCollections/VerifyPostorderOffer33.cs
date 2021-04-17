using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen.TreeCollections
{
    public class VerifyPostorderOffer33
    {
        //剑指 Offer 33. 二叉搜索树的后序遍历序列
        /*
         输入一个整数数组，判断该数组是不是某二叉搜索树的后序遍历结果。
        如果是则返回 true，否则返回 false。假设输入的数组的任意两个数字都互不相同。
         */
        public bool VerifyPostorder(int[] postorder)
        {
            return Recursive(postorder, 0, postorder.Length - 1);
        }
        public bool Recursive(int[] postorder, int left, int right)
        {
            if (left >= right)
                return true;
            int root = postorder[right];
            int m = left;
            while (postorder[m] < root)
                m++;
            for (int i = m; i <= right - 1; i++)
            {
                if (postorder[i] <= root)
                    return false;
            }
            return Recursive(postorder, left, m - 1) && Recursive(postorder, m, right - 1);
        }
        
    }
}
