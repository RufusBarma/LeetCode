using Xunit;

namespace FindAllAnagramsInAString_438;

public class Solution
{
    public IList<int> FindAnagrams(string s, string p)
    {
        var result = new List<int>();
        if (s.Length < p.Length || s == null || p == null || p.Length == 0)
            return result;
        var countP = new int[26];
        var countWindow = new int[26];
        for (var pIndex = 0; pIndex < p.Length; pIndex++)
        {
            countP[p[pIndex] - 'a']++;
            countWindow[s[pIndex] - 'a']++;
        }
        if (CompareCount(countP, countWindow))
            result.Add(0);

        for (var index = p.Length; index < s.Length; index++)
        {
            countWindow[s[index] - 'a']++;
            countWindow[s[index - p.Length] - 'a']--;
            if (CompareCount(countP, countWindow))
                result.Add(index-p.Length+1);
        }

        return result;
    }

    private bool CompareCount(int[] countP, int[] countWindow)
    {
        for (var index = 0; index < countP.Length; index++)
        {
            if (countP[index] != countWindow[index])
                return false;
        }
        return true;
    }

    [Fact]
    public void Test()
    {
        var tests = new List<(int[] expect, string s, string t)>
        {
            (new []{0, 6}, "cbaebabacd", "abc"),
        };
        foreach (var test in tests)
        {
            var result = FindAnagrams(test.s, test.t);
            Assert.Equal(test.expect, result);
        }
    }
}