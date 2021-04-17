using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen.TreeCollections
{
    //剑指 Offer 54. 二叉搜索树的第k大节点
    /*
    1.终止条件： 当节点 root 为空（越过叶节点），则直接返回；
    2.递归右子树： 即 dfs(root.right) ；
    3.三项工作：
        提前返回： 若 k=0 ，代表已找到目标节点，无需继续遍历，因此直接返回；
        统计序号： 执行 k=k−1 （即从 k 减至 0 ）；
        记录结果： 若 k=0 ，代表当前节点为第 k 大的节点，因此记录 res=root.val ；
    4.递归左子树： 即 dfs(root.left) ；


     */
    public class KthLargestOffer54
    {
        int res, count;
        public int KthLargest(TreeNode root, int k)
        {
            this.count = k;
            DFS(root);
            return res;
        }
        public void DFS(TreeNode root)
        {
            if (root == null)
                return;
            DFS(root.right);
            if (count == 0)   //提前返回
                return;
            if (--count == 0)  //为什么要先--？？因为前面已经遍历了右节点，当前节点的序号要-1.
                res = root.val;
            DFS(root.left);
        }

        public void Dfs(TreeNode root)
        {
            if (root == null || count == 0)
                return;
            Dfs(root.right);
            if(--count == 0)
            {
                res = root.val;
                return;
            }
            Dfs(root.left);
        }        
    }
}
