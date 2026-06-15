namespace Algorithms_Data_Structures.Algorithms.Substring
{
    // Given two strings s and t of lengths m and n respectively,
    // return the minimum window substring of s such that every
    // character in t(including duplicates) is included in the window.
    // If there is no such substring, return the empty string "".
    /*
        Example 1:
        Input: s = "ADOBECODEBANC", t = "ABC"
        Output: "BANC"
        Explanation: The minimum window substring "BANC" includes 'A', 'B', and 'C' from string t.
        Example 2:

        Input: s = "a", t = "a"
        Output: "a"
        Explanation: The entire string s is the minimum window.
        Example 3:

        Input: s = "a", t = "aa"
        Output: ""
        Explanation: Both 'a's from t must be included in the window.
        Since the largest window of s only has one 'a', return empty string.

        Constraints:

        m == s.length
        n == t.length
        1 <= m, n <= 10.000
        s and t consist of uppercase and lowercase English letters.
    */
    public static class MinimumWindowSubstring
    {
        public static string MinWindow(string s, string t)
        {
            int[] map = new int[128];
            foreach (char c in t) map[c]++;
            int counter = t.Length, begin = 0, end = 0, d = int.MaxValue, head = 0;
            while (end < s.Length)
            {
                if (--map[s[end++]] >= 0) counter--;
                while (counter == 0)
                {
                    if (end - begin < d) d = end - (head = begin);
                    if (++map[s[begin++]] > 0) counter++;
                }
            }
            return d == int.MaxValue ? "" : s.Substring(head, d);
        }
    }
}