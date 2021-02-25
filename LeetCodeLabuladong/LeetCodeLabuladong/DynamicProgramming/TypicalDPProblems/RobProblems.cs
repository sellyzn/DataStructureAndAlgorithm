using LeetCodeLabuladong.BinaryTreeProblems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.DynamicProgramming.TypicalDPProblems
{
    public class RobProblems
    {
        //198、打家劫舍
        /*
        你是一个专业的小偷，计划偷窃沿街的房屋。每间房内都藏有一定的现金，
        影响你偷窃的唯一制约因素就是相邻的房屋装有相互连通的防盗系统，
        如果两间相邻的房屋在同一晚上被小偷闯入，系统会自动报警。

        给定一个代表每个房屋存放金额的非负整数数组，计算你 
        不触动警报装置的情况下 ，一夜之内能够偷窃到的最高金额。

        示例 1：
        输入：[1,2,3,1]
        输出：4
        解释：偷窃 1 号房屋 (金额 = 1) ，然后偷窃 3 号房屋 (金额 = 3)。
             偷窃到的最高金额 = 1 + 3 = 4 。

        示例 2：
        输入：[2,7,9,3,1]
        输出：12
        解释：偷窃 1 号房屋 (金额 = 2), 偷窃 3 号房屋 (金额 = 9)，
             接着偷窃 5 号房屋 (金额 = 1)。
             偷窃到的最高金额 = 2 + 9 + 1 = 12 。

         */
        int[] memo;
        public int Rob(int[] nums)
        {
            memo = new int[nums.Length];
            for(int i = 0; i < nums.Length; i++)
            {
                nums[i] = -1;
            }
            return Dp(nums, 0);
        }
        public int Dp(int[] nums, int start)
        {
            if (start > nums.Length)
                return 0;
            if (memo[start] != -1)
                return memo[start];
            memo[start] = Math.Max(Dp(nums, start + 1), nums[start] + Dp(nums, start + 2));
            return memo[start];
        }


        public int RobDp(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            int n = nums.Length;
            int[] dp = new int[n + 2];
            dp[n + 1] = 0;
            dp[n] = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                dp[i] = Math.Max(dp[i + 1], nums[i] + dp[i + 2]);
            }
            return dp[0];
        }

        public int RobDpUp(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            int n = nums.Length;
            //记录dp[i+1]和dp[i+2]
            int dp_i_1 = 0, dp_i_2 = 0;
            //记录dp[i]
            int dp_i = 0;
            for(int i = n - 1; i >= 0; i--)
            {
                dp_i = Math.Max(dp_i_1,  nums[i] + dp_i_2);
                dp_i_2 = dp_i_1;
                dp_i_1 = dp_i;
            }
            return dp_i;
        }

        //213、打家劫舍II
        /*
        你是一个专业的小偷，计划偷窃沿街的房屋，每间房内都藏有一定的现金。这个地方所有的房屋都 围成一圈 ，这意味着第一个房屋和最后一个房屋是紧挨着的。同时，相邻的房屋装有相互连通的防盗系统，如果两间相邻的房屋在同一晚上被小偷闯入，系统会自动报警 。

        给定一个代表每个房屋存放金额的非负整数数组，计算你 在不触动警报装置的情况下 ，能够偷窃到的最高金额。

        示例 1：
        输入：nums = [2,3,2]
        输出：3
        解释：你不能先偷窃 1 号房屋（金额 = 2），然后偷窃 3 号房屋（金额 = 2）, 因为他们是相邻的。
 
        示例 2：
        输入：nums = [1,2,3,1]
        输出：4
        解释：你可以先偷窃 1 号房屋（金额 = 1），然后偷窃 3 号房屋（金额 = 3）。
             偷窃到的最高金额 = 1 + 3 = 4 。
   
        示例 3：
        输入：nums = [0]
        输出：0

         */
        public int RobII(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            int n = nums.Length;
            if (n == 1)
                return nums[0];
            return Math.Max(RobRange(nums, 0, n - 2),
                            RobRange(nums, 1, n - 1));
        }
        //计算闭区间[start,end]的最优结果
        public int RobRange(int[] nums, int start, int end)
        {
            int dp_i_1 = 0, dp_i_2 = 0;
            int dp_i = 0;
            for(int i = end; i >= start; i--)
            {
                dp_i = Math.Max(dp_i_1, nums[i] + dp_i_2);
                dp_i_2 = dp_i_1;
                dp_i_1 = dp_i;
            }
            return dp_i;
        }



        //337、打家劫舍III
        /*
        在上次打劫完一条街道之后和一圈房屋后，小偷又发现了一个新的可行窃的地区。
        这个地区只有一个入口，我们称之为“根”。 除了“根”之外，每栋房子有且只有一个“父“房子与之相连。
        一番侦察之后，聪明的小偷意识到“这个地方的所有房屋的排列类似于一棵二叉树”。 
        如果两个直接相连的房子在同一天晚上被打劫，房屋将自动报警。

        计算在不触动警报的情况下，小偷一晚能够盗取的最高金额。

        示例 1:
        输入: [3,2,3,null,3,null,1]

             3
            / \
           2   3
            \   \ 
             3   1

        输出: 7 
        解释: 小偷一晚能够盗取的最高金额 = 3 + 3 + 1 = 7.
        
        示例 2:
        输入: [3,4,5,1,3,null,1]

             3
            / \
           4   5
          / \   \ 
         1   3   1

        输出: 9
        解释: 小偷一晚能够盗取的最高金额 = 4 + 5 = 9.

        */

        Dictionary<TreeNode, int> memoIII = new Dictionary<TreeNode, int>();
        public int RobIII(TreeNode root)
        {
            if (root == null)
                return 0;
            //利用备忘录消除重叠子问题
            if (memoIII.ContainsKey(root))
                return memoIII[root];
            //抢，然后去下下家
            int do_it = root.val
                        + (root.left == null ? 0 : RobIII(root.left.left) + RobIII(root.left.right))     //因为涉及到root.left.left和root.left.right，即以root.left为根节点的孩子，所以要判断root.left是否为null
                        + (root.right == null ? 0 : RobIII(root.right.left) + RobIII(root.right.right));  //同理
            //不抢，然后去下家
            int not_do = RobIII(root.left) + RobIII(root.right);

            int res = Math.Max(do_it, not_do);
            memoIII.Add(root, res);
            return res;
        }

    }
}
