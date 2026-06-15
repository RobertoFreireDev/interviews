class Program
{
    static void Main(string[] args)
    {
        RunTests();
    }

    static void RunTests()
    {
        Test("abbaca", "ca");
        Test("azxxzy", "ay");
        Test("aabbcc", "");
        Test("abc", "abc");
        Test("aaaa", "");
        Test("abba", "");
        Test("aabccbadd", "a");
        Test("", "");
        Test("a", "a");
        Test("aaabccddd", "abd");
    }

    static void Test(string input, string expected)
    {
        var result = RemoveAdjacentDuplicates(input);

        if (result == expected)
        {
            Console.WriteLine($"✅: \"{input}\" -> \"{result}\"");
        }
        else
        {
            Console.WriteLine($"❌: \"{input}\" | Expected: \"{expected}\", Got: \"{result}\"");
        }
    }

    static string RemoveAdjacentDuplicates(string s)
    {
        int len = s.Length;
        if (s.Length <= 1)
        {
            return s;
        }

        var result = new Stack<char>();
        result.Push(s[0]);

        for (int i=1; i < len; i++)
        {
            if (result.Count > 0 && result.Peek() == s[i])
            {
                result.Pop();
                continue;
            }

            result.Push(s[i]);
        }

        var text = string.Empty;
        var reslen = result.Count;

        for (int i=0; i< reslen; i++)
        {
            text = result.Pop() + text;
        }

        return text.ToString();
    }
}