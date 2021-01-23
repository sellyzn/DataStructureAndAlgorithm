using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLabuladong.BinaryTree
{
    /*652. 寻找重复的子树
     * 
        给定一棵二叉树，返回所有重复的子树。对于同一类的重复子树，你只需要返回其中任意一棵的根结点即可。
        两棵树重复是指它们具有相同的结构以及相同的结点值。
        
    */
    public class FindDuplicateSubtrees652
    {
        //记录所有子树以及出现的次数
        Dictionary<string, int> memo = new Dictionary<string, int>();
        //记录重复的子树根节点
        List<TreeNode> res = new List<TreeNode>();
        /*主函数*/
        public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
        {
            Traverse(root);
            return res;
        }
        /*辅助函数*/
        public string Traverse(TreeNode root)
        {
            if (root == null)
                return "#";
            string left = Traverse(root.left);
            string right = Traverse(root.right);
            string subTree = left + "," + right + "," + root.val;
            if (!memo.ContainsKey(subTree)) //判断
            {
                memo.Add(subTree, 1);
            }
            else if (memo[subTree] == 1) //多次重复也只会被加入结果集一次
            {
                res.Add(root);
                memo[subTree]++;  //给子树对应的出现次数加一
            }
            else if (memo[subTree] > 1)
            {
                memo[subTree]++;  //给子树对应的出现次数加一
            }
            return subTree;
        }
    }
}
