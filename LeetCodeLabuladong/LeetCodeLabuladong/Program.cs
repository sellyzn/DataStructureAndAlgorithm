using LeetCodeLabuladong.ArrayProblems;
using LeetCodeLabuladong.BinaryTreeProblems;
using LeetCodeLabuladong.DataStructureDesignProblems;
using LeetCodeLabuladong.DynamicProgramming;
using LeetCodeLabuladong.DynamicProgramming.SubsequenceTypeProblems;
using LeetCodeLabuladong.DynamicProgramming.TypicalDPProblems;
using LeetCodeLabuladong.LinkedListProblems;
using LeetCodeLabuladong.LinkedListProblems.StudentChen;
using LeetCodeLabuladong.StudentChen;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeLabuladong
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //string s1 = "horse";
            //string s2 = "ros";
            //MinDistance72 md = new MinDistance72();
            //int res = md.MinDistance(s1, s2);
            //Console.WriteLine(res);

            //int m = s1.Length;
            //int n = s2.Length;
            //int[,] memo = new int[m, n];
            //for(int i = 0; i < m; i++)
            //{
            //    for(int j = 0; j < n; j++)
            //    {
            //        memo[i, j] = -1;
            //    }
            //}

            //for (int i = 0; i < m; i++)
            //{
            //    Console.WriteLine("i = " + i);
            //    for (int j = 0; j < n; j++)
            //    {
            //        Console.WriteLine(memo[i, j]);
            //    }

            //}

            //string s1 = "b";
            //string s2 = "a";
            //LongestCommonSubsequence1143 lcs = new LongestCommonSubsequence1143();
            //int res = lcs.MinDistance(s1, s2);
            //Console.WriteLine(res);

            //int k = 2;
            ////int[] prices = new int[] { 3, 2, 6, 5, 0, 3 };
            //int[] prices = new int[] { 1,2 };
            //StockTradingProblems3Ddp st = new StockTradingProblems3Ddp();
            //int res1 = st.MaxProfit_k_any_1(k, prices);
            //Console.WriteLine(res1);


            ////string s = "ADOBECODEBANC";
            ////string t = "ABC";
            //SlidingWindow sd = new SlidingWindow();
            ////string res = sd.MinWindow76(s, t);
            ////Console.WriteLine(res);

            //string s1 = "ab";
            //string s2 = "eidboaoo";
            //bool res1 = sd.CheckInclusion567(s1, s2);
            //Console.WriteLine(res1);

            //int[] nums1 = new int[] { 2,4 };
            //int[] nums2 = new int[] { 1,2,3,4 };
            //MonotonicStackProblems ms = new MonotonicStackProblems();
            //int[] res = ms.NextGreaterElementI(nums1, nums2);
            //foreach(int num in res)
            //{
            //    Console.WriteLine(num);
            //}

            //int[] nums = new int[] { -1, 0, 1, 2, -1, -4 };
            ////Array.Sort(nums);
            ////foreach(int num in nums)
            ////{
            ////    Console.WriteLine(num);
            ////}
            //TwoSumCollection tsc = new TwoSumCollection();
            //var res = tsc.ThreeSum(nums);
            //foreach(var l in res)
            //{
            //    foreach(var num in l)
            //    {
            //        Console.WriteLine(num);
            //    }
            //    Console.WriteLine("\n");
            //}



            //int[] nums = new int[] { 0, 0, 1, 1, 1, 2 };
            //BinarySearch bs = new BinarySearch();
            //int res = bs.LeftBound1(nums, 1);
            //Console.WriteLine(res);

            //SearchInsert35 si = new SearchInsert35();
            //int[] nums = new int[] { 1, 3, 5, 6 };
            //Console.WriteLine(si.SearchInsert(nums,7));


            //ListNode head = new ListNode(1);
            //ListNode l1 = new ListNode(2);
            ////ListNode l2 = new ListNode(3);
            ////ListNode l3 = new ListNode(4);
            ////ListNode l4 = new ListNode(5);
            //head.next = l1;
            ////l1.next = l2;
            ////l2.next = l3;
            ////l3.next = l4;



            //ReorderList143 ro = new ReorderList143();
            //ro.ReorderList(head);
            //RotateRight61 rr = new RotateRight61();
            //ListNode res = rr.RotateRight(head, 2);
            //ListNode cur = res;
            //while(cur != null)
            //{
            //    Console.WriteLine(cur.val);
            //    cur = cur.next;
            //}

            //int x = int.MinValue;
            //Reverse7 rv = new Reverse7();
            //int res = rv.Reverse(x);
            //Console.WriteLine(res);
            //PlusOne66 po = new PlusOne66();
            //int[] digits = new int[] { 1, 9 };
            //int[] res = po.PlusOne(digits);
            //foreach(int num in res)
            //{
            //    Console.WriteLine(num);
            //}

            MySqrt69 ms = new MySqrt69();
            Console.WriteLine(ms.MySqrt(2147395599));
        }

        public int KthLargest(TreeNode root, int k)
        {
            this.k = k;
            dfs(root);
            return res;
        }
        int k;
        int res;
        public void dfs(TreeNode root)
        {
            if (root == null)
                return;
            dfs(root.right);
            if (k == 0)
                return;
            if (--k == 0)
                res = root.val;
            dfs(root.left);
        }

        //先序遍历树A中的每个节点nA
        public bool IsSubStructure(TreeNode A, TreeNode B)
        {
            if (A == null || B == null)
                return false;
            //if (A.val == B.val && Recursive(A.left, B.left) && Recursive(A.right, B.right))
            //    return true;
            return Recursive(A, B) || IsSubStructure(A.left, B) || IsSubStructure(A.right, B);
        }
        //判断树A中以nA为根节点的子树是否包含树B
        public bool Recursive(TreeNode A, TreeNode B)
        {
            if (B == null)
                return true;
            if (A == null || A.val != B.val)
                return false;
            return Recursive(A.left, B.left) && Recursive(A.right, B.right);            
        }
    }
}
