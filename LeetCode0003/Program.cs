using System;
using System.Collections.Generic;

namespace LeetCode0003
{
    /*
     * 3. 无重复字符的最长子串
     * 
     *给定一个字符串，请你找出其中不含有重复字符的 最长子串 的长度。
     *
     *示例 1:
     *
     *输入: "abcabcbb"
     *输出: 3 
     *解释: 因为无重复字符的最长子串是 "abc"，所以其长度为 3。
     *示例 2:
     *
     *输入: "bbbbb"
     *输出: 1
     *解释: 因为无重复字符的最长子串是 "b"，所以其长度为 1。
     *示例 3:
     *
     *输入: "pwwkew"
     *输出: 3
     *解释: 因为无重复字符的最长子串是 "wke"，所以其长度为 3。
     *请注意，你的答案必须是 子串 的长度，"pwke" 是一个子序列，不是子串。
     */

    public class Solution_Bak1
    {
        public int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s))
            { return 0; }

            if (s.Length == 1)
            { return 1; }

            var max_result_length = 0;
            var result = new Dictionary<string, int>();

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i; j < s.Length; j++)
                {
                    Console.WriteLine((int)s[j]);
                    var temp = s[j].ToString();
                    if (result.ContainsKey(temp))
                    {
                        var str = "";
                        foreach (KeyValuePair<string, int> item in result)
                        { str += string.Format("{0}:{1},", item.Key, item.Value); }
                        Console.WriteLine(str);
                        result.Clear();
                        break;
                    }
                    else
                    {
                        result.Add(temp, i);
                        if (max_result_length < result.Count)
                        { max_result_length = result.Count; }
                    }
                }

                if (max_result_length == s.Length)
                { break; }
            }
            return max_result_length;
        }
    }

    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s))
            { return 0; }

            if (s.Length == 1)
            { return 1; }

            var maxLen = 0;
            var thisLen = 0;
            var previous = 0;//起始位置下标
            var indexs = new int[128];//字符最后出现的位置
            for (int i = 0; i < 128; i++)
            { indexs[i] = -1; }

            for (int i = 0; i < s.Length; i++)
            {
                var ch = (int)s[i];
                var index = indexs[ch];
                if (index >= previous)
                {
                    thisLen = i - previous;
                    if (thisLen > maxLen)
                    { maxLen = thisLen; }

                    previous = index + 1;
                    Console.WriteLine(previous);
                }
                indexs[ch] = i;
            }
            thisLen = s.Length - previous;
            if (thisLen > maxLen)
            { maxLen = thisLen; }

            return maxLen;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var test = "cabcdefab";
            var s = new Solution();
            var result = s.LengthOfLongestSubstring(test);
            Console.WriteLine(string.Format("max={0}", result));
            Console.ReadKey();
        }
    }
}
