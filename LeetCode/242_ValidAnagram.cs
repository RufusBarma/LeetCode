using Xunit;

namespace ValidAnagram_242;

public class Solution {
    public bool IsAnagram(string s, string t)
    {
        return s.OrderBy(c => c).SequenceEqual(t.OrderBy(c => c));
    }

    [Fact]
    public void Test()
    {
        var tests = new List<(bool expect, string s, string t)>
        {
            (false, "aa", "bb"),
            (true, "eat", "tea"),
            (false, "e", "ea"),
        };
        foreach (var test in tests)
        {
            var result = IsAnagram(test.s, test.t);
            Assert.Equal(test.expect, result);
        }
    }
}