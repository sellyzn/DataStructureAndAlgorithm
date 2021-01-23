using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeLabuladong.BinaryTree
{
    public class SerializeDeserialize297
    {
        // Encodes a tree to a single string.
        string NULL = "#";
        string SEP = ",";
        public string serialize(TreeNode root)
        {
            StringBuilder sb = new StringBuilder();
            serialize(root, sb);
            return sb.ToString();
        }
        public void serialize(TreeNode root, StringBuilder sb)
        {
            if (root == null)
            {
                sb.Append(NULL).Append(SEP);
                return;
            }
            sb.Append(root.val).Append(SEP);
            serialize(root.left, sb);
            serialize(root.right, sb);
        }

        // Decodes your encoded data to tree.
        /*主函数，将字符串反序列化位二叉树结构*/
        public TreeNode deserialize(string data)
        {
            //将字符串转化为列表
            var nodes = new LinkedList<string>();
            foreach (var s in data.Split(SEP))
            {
                nodes.AddLast(s);
            }
            return deserialize(nodes);
        }
        /*辅助函数，通过nodes列表构造二叉树*/
        public TreeNode deserialize(LinkedList<string> nodes)
        {
            if (nodes.Count == 0)
                return null;
            /******前序遍历位置******/
            //列表最左侧就是根节点
            LinkedListNode<string> first = nodes.First;            
            nodes.RemoveFirst();
            if (first.Equals(NULL))
                return null;
            TreeNode root = new TreeNode(int.Parse(first.ToString()));

            root.left = deserialize(nodes);
            root.right = deserialize(nodes);

            return root;
    }
    }
}
