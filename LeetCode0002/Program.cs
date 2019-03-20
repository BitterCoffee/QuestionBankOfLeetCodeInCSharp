using System;
using System.Collections.Generic;

namespace LeetCode0002
{
    /*
     * 2. 两数相加
     * 
     *给出两个 非空 的链表用来表示两个非负的整数。其中，它们各自的位数是按照 逆序 的方式存储的，并且它们的每个节点只能存储 一位 数字。
     *
     *如果，我们将这两个数相加起来，则会返回一个新的链表来表示它们的和。
     *
     *您可以假设除了数字 0 之外，这两个数都不会以 0 开头。
     *
     *示例：
     *
     *输入：(2 -> 4 -> 3) + (5 -> 6 -> 4)
     *输出：7 -> 0 -> 8
     *原因：342 + 465 = 807
     */

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var arr1 = GetValueOfListNode(l1);
            var arr2 = GetValueOfListNode(l2);
            var maxLength = arr1.Length - arr2.Length > 0 ? arr1.Length : arr2.Length;

            var dic1 = new Dictionary<int, int>();
            for (int i = 0; i < arr1.Length; i++)
            { dic1.Add(i, arr1[i]); }

            var dic2 = new Dictionary<int, int>();
            for (int i = 0; i < arr2.Length; i++)
            { dic2.Add(i, arr2[i]); }

            var resultDic = new Dictionary<int, int>();
            for (int i = 0; i < maxLength; i++)
            {
                var val1 = 0;
                if (dic1.ContainsKey(i))
                { val1 = dic1[i]; }

                var val2 = 0;
                if (dic2.ContainsKey(i))
                { val2 = dic2[i]; }

                var sum = val1 + val2;
                if (resultDic.ContainsKey(i))
                { resultDic[i] = sum; }
                else
                { resultDic.Add(i, sum); }
            }

            for (int i = 0; i < resultDic.Count; i++)
            {
                if (resultDic.ContainsKey(i))
                {
                    var val = resultDic[i];
                    if (val > 9)
                    {
                        var remainder = val % 10;
                        var up = (val - remainder) / 10;

                        resultDic[i] = remainder;
                        if (up > 0)
                        {
                            var j = i + 1;
                            if (resultDic.ContainsKey(j))
                            { resultDic[j] = resultDic[j] + up; }
                            else
                            { resultDic.Add(j, up); }
                        }
                    }
                }
            }

            ListNode resultListNode = new ListNode(0);//保留链表头引用
            BuildListNodeByString(resultDic, resultListNode, 0);
            return resultListNode;
        }

        private int[] GetValueOfListNode(ListNode l)
        {
            if (l == null)
            { return null; }

            List<int> resultVal = new List<int>();

            var resultTmp = string.Empty;
            TraversalListNode(l, resultVal);

            return resultVal.ToArray();
        }

        private void TraversalListNode(ListNode curListNode, List<int> resultVal)
        {
            if (resultVal == null)
            { resultVal = new List<int>(); }

            resultVal.Add(curListNode.val);

            if (curListNode.next != null)
            { TraversalListNode(curListNode.next, resultVal); }
        }

        private void BuildListNodeByString(Dictionary<int, int> resultDic, ListNode curListNode, int readIndex)
        {
            if (resultDic.Count <= readIndex)
            { return; }

            if (readIndex == 0)
            {
                curListNode.val = resultDic[readIndex];

                readIndex++;
                BuildListNodeByString(resultDic, curListNode, readIndex);
            }
            else if (readIndex > 0)
            {
                curListNode.next = new ListNode(resultDic[readIndex]);

                readIndex++;
                BuildListNodeByString(resultDic, curListNode.next, readIndex);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var node1 = new ListNode(2);
            node1.next = new ListNode(4);
            node1.next.next = new ListNode(3);

            var node2 = new ListNode(5);
            node2.next = new ListNode(6);
            node2.next.next = new ListNode(4);

            var s = new Solution();
            var result = s.AddTwoNumbers(node1, node2);

            var result_string = string.Empty;
            result_string = result.val.ToString();

            var item = result.next;
            while (item != null)
            {
                result_string += "->" + item.val.ToString();
                item = item.next;
            };

            Console.WriteLine(string.Format("result:{0}", result_string));
            Console.ReadKey();
        }
    }
}
