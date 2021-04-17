﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeLabuladong.StudentChen.TreeCollections
{
    public class IsSubStructureOffer26
    {
        //Offer26. 树的子结构
        /*
        判断树 B 是否是树 A 的子结构，需完成以下两步工作：
        1.先序遍历树 A 中的每个节点 n_A；（对应函数 isSubStructure(A, B)）
        2.判断树 A 中 以 n_A 为根节点的子树 是否包含树 BB 。（对应函数 recur(A, B)）

         * 
        算法流程：
        名词规定：树 AA 的根节点记作 节点 A ，树 B 的根节点称为 节点 B 。

        recur(A, B) 函数：
        终止条件：
            当节点 B 为空：说明树 B 已匹配完成（越过叶子节点），因此返回 true ；
            当节点 A 为空：说明已经越过树 A 叶子节点，即匹配失败，返回 false ；
            当节点 A 和 B 的值不同：说明匹配失败，返回 false ；
        返回值：
            判断 A 和 B 的左子节点是否相等，即 recur(A.left, B.left) ；
            判断 A 和 B 的右子节点是否相等，即 recur(A.right, B.right) ；

        isSubStructure(A, B) 函数：
        特例处理： 当 树 A 为空 或 树 B 为空 时，直接返回 false ；
        返回值： 若树 B 是树 A 的子结构，则必满足以下三种情况之一，因此用或 || 连接；
            1)以 节点 A 为根节点的子树 包含树 B ，对应 recur(A, B)；
            2)树 B 是 树 A 左子树 的子结构，对应 isSubStructure(A.left, B)；
            3)树 B 是 树 A 右子树 的子结构，对应 isSubStructure(A.right, B)；

        以上 2. 3. 实质上是在对树 A 做 先序遍历 。


         */
        public bool IsSubStructure(TreeNode A, TreeNode B)
        {
            if (A == null || B == null)
                return false;
            return Recursive(A, B) || IsSubStructure(A.left, B) || IsSubStructure(A.right, B);
        }
        public bool Recursive(TreeNode A, TreeNode B)
        {
            if (B == null)
                return true;
            if (A == null)
                return false;
            if (A.val != B.val)
                return false;
            return Recursive(A.left, B.left) && Recursive(A.right, B.right);
        }
    }
}
