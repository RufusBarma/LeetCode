using Xunit;

namespace IsomorphicStrings_205;

// 205. Isomorphic Strings

// "egg", "add" = true
// "foo", "bar" = false
// "paper", "title" = true
// "badc", "baba" = false

public class Solution
{
    public bool IsIsomorphic(string s, string t)
    {
        var dictionary = new Dictionary<char, char>();
        var usedChars = new HashSet<char>();

        for (var index = 0; index < s.Length; index++)
        {
            var containChar = dictionary.ContainsKey(s[index]);
            if (!containChar)
            {
                if (usedChars.Contains(t[index]))
                    return false;
                dictionary.Add(s[index], t[index]);
                usedChars.Add(t[index]);
            }
            else if (dictionary[s[index]] != t[index])
            {
                return false;
            }
        }
        return true;
    }
    
    [Fact]
    public void Test()
    {
        var tests = new List<(bool expect, string s, string t)>
        {
            (true, "paper", "title"),
            (false, "badc", "baba"),
        };
        foreach (var test in tests)
            Assert.Equal(test.expect, IsIsomorphic(test.s, test.t));
    }
}