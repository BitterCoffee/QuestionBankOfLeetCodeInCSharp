using System;
using System.Collections.Generic;

namespace LeetCode0001
{
    /*
     * 1. 两数之和
     * 
     *给定一个整数数组 nums 和一个目标值 target，请你在该数组中找出和为目标值的那 两个 整数，并返回他们的数组下标。
     * 
     *你可以假设每种输入只会对应一个答案。但是，你不能重复利用这个数组中同样的元素。
     *
     *示例:
     *
     *给定 nums = [2, 7, 11, 15], target = 9
     *
     *因为 nums[0] + nums[1] = 2 + 7 = 9
     *所以返回 [0, 1]
     */
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (dic.ContainsKey(complement))
                {
                    var j = -1;
                    dic.TryGetValue(complement, out j);

                    if (j < 0)
                    { throw new Exception("未找到结果"); }

                    return new int[] { j, i };
                }

                if (!dic.ContainsKey(nums[i]))
                { dic.Add(nums[i], i); }
            }
            throw new Exception("未找到结果");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[] { 2, 7, 11, 15 };
            var target = 9;
            var s = new Solution();
            var result = s.TwoSum(nums, target);

            var nums_string = "";
            foreach (var item in nums)
            { nums_string += "," + item.ToString(); }

            if (!string.IsNullOrEmpty(nums_string)
                && nums_string.Length > 0)
            { nums_string = nums_string.Substring(1); }

            var result_string = "";
            foreach (var item in result)
            { result_string += "," + item.ToString(); }

            if (!string.IsNullOrEmpty(result_string)
                && result_string.Length > 0)
            { result_string = result_string.Substring(1); }

            Console.WriteLine(string.Format("nums=[{0}],target={1}", nums_string, target));
            Console.WriteLine(string.Format("result=[{0}]", result_string));
            Console.ReadKey();
        }
    }
}
