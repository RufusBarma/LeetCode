using Xunit;

namespace PartitionLabels_763;

public class Solution
{
    public IList<int> PartitionLabels(string s)
    {
        var lastPositionOfLetter = new Dictionary<char, int>();
        for (var index = 0; index < s.Length; index++)
        {
            lastPositionOfLetter.TryAdd(s[index], index);
            lastPositionOfLetter[s[index]] = index;
        }

        var result = new List<int>();
        var length = 0;
        var end = 0;

        for (var index = 0; index < s.Length; index++)
        {
            length++;
            end = Math.Max(end, lastPositionOfLetter[s[index]]);
            if (end == index)
            {
                result.Add(length);
                length = 0;
                end++;
            }
        }
        return result;
    }

    [Fact]
    public void Test()
    {
        var tests = new List<(int[] expect, string s)>
        {
            (new[] { 9, 7, 8 }, "ababcbacadefegdehijhklij"),
            (new[] { 9, 1 }, "eaaaabaaec"),
            (Array.Empty<int>(), ""),
        };
        foreach (var test in tests)
            Assert.Equal(test.expect, PartitionLabels(test.s));
    }
}