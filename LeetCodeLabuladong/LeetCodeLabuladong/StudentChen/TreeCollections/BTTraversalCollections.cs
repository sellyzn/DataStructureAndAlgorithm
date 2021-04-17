using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen.TreeCollections
{
    public class BTTraversalCollections
    {
        ////////////////// 迭代方法 ///////////////

        //144.二叉树的前序遍历
        /*
         List<int> res 保存遍历的结果
        用栈stack来辅助

        大循环条件：cur != null ||  stack.Count() != 0
        用一个while循环（cur != null），将根节点cur和所有的左孩子节点入栈并加入结果中，直至cur为空。
        若此时，stack不为空，则弹出一个栈顶元素，将该栈顶元素作为当前的cur，到达它的右孩子。


        1.每拿到一个 节点 就把它保存在 栈 中
        2.继续对这个节点的 左子树 重复 过程1，直到左子树为 空
        3.因为保存在 栈 中的节点都遍历了 左子树 但是没有遍历 右子树，所以对栈中节点 出栈 并对它的 右子树 重复 过程1
        4.直到遍历完所有节点


         */
        public IList<int> PreorderTraversal(TreeNode root)
        {
            List<int> res = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode cur = root;
            while(cur != null || stack.Count() != 0)
            {
                while(cur != null)
                {
                    res.Add(cur.val);
                    stack.Push(cur);
                    cur = cur.left;
                }
                if(stack.Count != 0)
                {
                    cur = stack.Pop();
                    cur = cur.right;
                }
            }
            return res;
        } 


        //94.二叉树的中序遍历
        /*
         
         */
        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> res = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode cur = root;
            while(cur != null || stack.Count() != 0)
            {
                while(cur != null)
                {
                    stack.Push(cur);
                    cur = cur.left;
                }
                if(stack.Count() != 0) {
                    cur = stack.Pop();
                    res.Add(cur.val);
                    cur = cur.right;
                }
            }
            return res;
        }

        //145.二叉树的后序遍历
        /*
         
         */
        public IList<int> PostorderTraversal(TreeNode root)
        {
            List<int> res = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode cur = root;
            TreeNode lastVisit = root;
            while(cur != null || stack.Count() != 0)
            {
                //遍历左子树，入栈
                while(cur != null)
                {
                    stack.Push(cur);
                    cur = cur.left;
                }
                //cur = stack.Pop();
                cur = stack.Peek();  //查看当前栈顶元素（此时不弹出）
                //如果其右子树为空，或者右子树已经访问
                //则可以直接输出当前节点的值
                //将当前节点cur标记为lastVisit，并将cur置空
                //弹出栈顶元素
                if(cur.right == null || lastVisit == cur.right)
                {
                    res.Add(cur.val);
                    lastVisit = cur;
                    cur = null;
                    stack.Pop();
                }
                else
                {
                    //stack.Push(cur);
                    cur = cur.right;  //否则，继续遍历右子树
                }
            }
            return res;
        }


        //102.二叉树的层序遍历
        //借助辅助队列
        /*
        1.特例处理： 当树的根节点为空，则直接返回空列表 [] ；
        2.初始化： 打印结果列表 res = [] ，包含根节点的队列 queue = [root] ；
        3.BFS 循环： 当队列 queue 为空时跳出；
            1)出队： 队首元素出队，记为 node；
            2)打印： 将 node.val 添加至列表 tmp 尾部；
            3)添加子节点： 若 node 的左（右）子节点不为空，则将左（右）子节点加入队列 queue ；
        4.返回值： 返回打印结果列表 res 即可。

         */

        public IList<int> LeverOrderOriginal(TreeNode root)
        {
            List<int> res = new List<int>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            if (root == null)
                return res;
            queue.Enqueue(root);
            while(queue.Count != 0)
            {
                TreeNode node = queue.Dequeue();
                res.Add(node.val);
                if (node.left != null)
                    queue.Enqueue(node.left);
                if (node.right != null)
                    queue.Enqueue(node.right);
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
            while(queue.Count != 0)
            {
                //保存每一层节点的数组
                List<int> subList = new List<int>();
                int currentLevelLength = queue.Count; //记录当前层级的节点数目长度
                //截取队列中每一层对应的节点数目长度，进行遍历，并加入下一层的节点（若有）
                for(int i = 1; i <= currentLevelLength; i++)
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

        //107.二叉树的层序遍历II
        //自底向上的层序遍历
        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            IList<IList<int>> res = new List<IList<int>>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            if (root == null)
                return res;
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                
                IList<int> subList = new List<int>();
                int currentLevelLength = queue.Count; 
                
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
                //res.AddFirst(subList);
                res.Insert(0, subList);
            }
            return res;
        }


        //剑指offer32-I：从上到下打印二叉树
        public int[] LevelOrderOfferI(TreeNode root)
        {
            if (root == null)
                return new int[0];
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            List<int> ans = new List<int>();
            while(queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                ans.Add(node.val);
                if (node.left != null)
                    queue.Enqueue(node.left);
                if (node.right != null)
                    queue.Enqueue(node.right);
            }
            int length = ans.Count;
            int[] res = new int[length];
            for(int i = 0; i < length; i++)
            {
                res[i] = ans[i];
            }
            return res;
        }

        //剑指offer32-II：从上到下打印二叉树
        //同102

        //剑指offer32-III：从上到下打印二叉树
        //打印顺序：第一行从左到右，第二行从右到左，第三行从左到右，以此类推。

        //思路同102，区别是：
        //添加变量level，记录层数（初始值为0，也就是第一行），
        //若level为偶数值，则直接将subList添加到res中；
        //若level为奇数值，则，用一个辅助栈，将subList中的元素入栈，然后再依次出栈，保存到新的subListOdd中，添加到res中。
        //每一层遍历完，要level++。
        public IList<IList<int>> LevelOrderOfferIII(TreeNode root)
        {
            IList<IList<int>> res = new List<IList<int>>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            if (root == null)
                return res;
            int level = 0;
            queue.Enqueue(root);
            while(queue.Count > 0)
            {
                IList<int> subList = new List<int>();
                int currentLevelLength = queue.Count;
                for(int i = 1; i <= currentLevelLength; i++)
                {
                    TreeNode node = queue.Dequeue();
                    subList.Add(node.val);
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }

                if(level % 2 == 0)
                {
                    res.Add(subList);
                }
                else
                {
                    Stack<int> stack = new Stack<int>();
                    IList<int> subListOdd = new List<int>();
                    foreach(int  item in subList)
                    {
                        stack.Push(item);
                    }
                    while(stack.Count > 0)
                    {
                        subListOdd.Add(stack.Pop());
                    }
                    res.Add(subListOdd);
                }
                level++;
            }

            return res;
        }
    }
}
