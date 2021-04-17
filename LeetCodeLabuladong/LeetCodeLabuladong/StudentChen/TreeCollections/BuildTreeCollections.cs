using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen.TreeCollections
{
    public class BuildTreeCollections
    {
        //剑指offer07.重建二叉树
        //105.从前序与中序遍历序列构造二叉树
        public TreeNode BuildTree_prein(int[] preorder, int[] inorder)
        {
            return Build_prein(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1);
        }
        public TreeNode Build_prein(int[] preorder, int preStart, int preEnd, int[] inorder, int inStart, int inEnd)
        {
            if (preStart > preEnd)
                return null;
            int rootValue = preorder[preStart];
            int index = inStart;
            for(int i = inStart; i <= inEnd; i++)
            {
                if (inorder[i] == rootValue)
                    index = i;
            }
            int leftLength = index - inStart;
            TreeNode root = new TreeNode(rootValue);
            root.left = Build_prein(preorder, preStart + 1, preStart + leftLength, inorder, inStart, index - 1);
            root.right = Build_prein(preorder, preStart + leftLength + 1, preEnd, inorder, index + 1, inEnd);
            return root;
        }

        //106.从中序与后序遍历序列构造二叉树
        public TreeNode BuildTree_inpost(int[] inorder, int[] postorder)
        {
            return Build_inpost(inorder, 0, inorder.Length - 1, postorder, 0, postorder.Length - 1);
        }
        public TreeNode Build_inpost(int[] inorder, int inStart, int inEnd, int[] postorder, int postStart, int postEnd)
        {
            if (inStart > inEnd)
                return null;
            int rootValue = postorder[postEnd];
            int index = inStart;
            for (int i = inStart; i <= inEnd; i++)
            {
                if (inorder[i] == rootValue)
                    index = i;
                //if(inorder[i] == rootValue)
                //{
                //    index = i;
                //    break;
                //}
            }
            int leftLength = index - inStart;
            TreeNode root = new TreeNode(rootValue);
            root.left = Build_inpost(inorder, inStart, index - 1, postorder, postStart, postStart + leftLength - 1);
            root.right = Build_inpost(inorder, index + 1, inEnd, postorder, postStart + leftLength, postEnd - 1);
            return root;
        }


        //889.根据前序和后序遍历构造二叉树
        //返回与给定的前序和后序遍历匹配的任何二叉树
        public TreeNode ConstructFromPrePost(int[] pre, int[] post)
        {

        }



        //1008.前序遍历构造二叉搜索树
        public TreeNode BstFromPreorder(int[] preorder)
        {
            if (preorder == null || preorder.Length == 0)
                return null;
            return Build_pre(preorder, 0, preorder.Length - 1);
        }

        public TreeNode Build_pre(int[] preorder, int left, int right)
        {
            if (left > right)
                return null;
            int rootValue = preorder[left];
            TreeNode root = new TreeNode(rootValue);
            if (left == right)
                return root;
            //找左右子树区间的分界线，使用二分查找。
            //在[left,right]区间里找最后一个小于preorder[left]的下标
            //
            //考虑到区间只有2个元素的情况

            int l = left, r = right;
            while(l < r)
            {
                int mid = l + (r - l + 1) / 2;  //+1，偶数
                if (preorder[mid] < preorder[left])
                    //下一轮搜索区间是[mid, r]
                    l = mid;
                else
                    //下一轮搜索区间是[l, mid - 1]
                    r = mid - 1;
            }
            root.left = Build_pre(preorder, left + 1, l);
            root.right = Build_pre(preorder, l + 1, right);

            //int index = left;
            //for(int i = left; i <= right; i++)
            //{
            //    if(preorder[i] > rootValue)
            //    {
            //        index = i;
            //        break;
            //    }
            //}
            //root.left = Build_pre(preorder, left + 1, index - 1);
            //root.right = Build_pre(preorder, index, right);
            return root;
        }

    }
}
