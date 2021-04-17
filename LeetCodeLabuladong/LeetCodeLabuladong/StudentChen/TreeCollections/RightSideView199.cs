using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen.TreeCollections
{
    public class RightSideView199
    {
        //二叉树的右视图
        /*
        给定一棵二叉树，想象自己站在它的右侧，按照从顶部到底部的顺序，返回从右侧所能看到的节点值。

        示例:
        输入: [1,2,3,null,5,null,4]
        输出: [1, 3, 4]
        解释:

           1            <---
         /   \
        2     3         <---
         \     \
          5     4       <---

         */

        //BFS，层序遍历，记录每层最后一个节点
        public IList<int> RightSideView(TreeNode root)
        {
            IList<int> res = new List<int>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            if (root == null)
                return res;
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                //保存每一层节点的值                
                Stack<int> stack = new Stack<int>();
                int currentLevelLength = queue.Count; //记录当前层级的节点数目长度
                //截取队列中每一层对应的节点数目长度，进行遍历，并加入下一层的节点（若有）
                for (int i = 1; i <= currentLevelLength; i++)
                {
                    TreeNode node = queue.Dequeue();
                    stack.Push(node.val);
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }
                //保存每一层节点数组
                
                res.Add(stack.Pop());
            }
            return res;

        }

        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            List<IList<int>> res = new List<IList<int>>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            if (root == null)
                return res;
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                //保存每一层节点的数组
                List<int> subList = new List<int>();
                int currentLevelLength = queue.Count; //记录当前层级的节点数目长度
                //截取队列中每一层对应的节点数目长度，进行遍历，并加入下一层的节点（若有）
                for (int i = 1; i <= currentLevelLength; i++)
                {
                    TreeNode node = queue.Dequeue();
                    subList.Add(node.val);
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }
                //保存每一层节点数组
                res.Add(subList);
            }
            return res;
        }
    }
}
