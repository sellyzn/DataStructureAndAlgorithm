using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen.TreeCollections
{
    //Offer34.二叉树中和为某一值的路径
    //113.路径总和II

    /*
    算法流程：
    pathSum(root, sum) 函数：
        初始化： 结果列表 res ，路径列表 path 。
        返回值： 返回 res 即可。

    recur(root, tar) 函数：
        递推参数： 当前节点 root ，当前目标值 tar 。
        终止条件： 若节点 root 为空，则直接返回。
        递推工作：
            1)路径更新： 将当前节点值 root.val 加入路径 path ；
            2)目标值更新： tar = tar - root.val（即目标值 tar 从 sum 减至 0 ）；
            3)路径记录： 当 ① root 为叶节点 且 ② 路径和等于目标值 ，则将此路径 path 加入 res 。
            4)先序遍历： 递归左 / 右子节点。
            5)路径恢复： 向上回溯前，需要将当前节点从路径 path 中删除，即执行 path.pop() 。

    复杂度分析：
        时间复杂度 O(N) ： N 为二叉树的节点数，先序遍历需要遍历所有节点。
        空间复杂度 O(N) ： 最差情况下，即树退化为链表时，path 存储所有树节点，使用 O(N) 额外空间。


     */
    public class PathSum34
    {
        IList<IList<int>> res = new List<IList<int>>();
        IList<int> path = new List<int>();
        public IList<IList<int>> PathSum(TreeNode root, int target)
        {
            Recursive(root, target);
            return res;
        }

        public void Recursive(TreeNode root, int target)
        {
            if (root == null)
                return;
            path.Add(root.val);
            target -= root.val;
            if (target == 0 && root.left == null && root.right == null)
                res.Add(new List<int>(path));
            Recursive(root.left, target);
            Recursive(root.right, target);
            path.RemoveAt(path.Count - 1);
        }

    }
}
