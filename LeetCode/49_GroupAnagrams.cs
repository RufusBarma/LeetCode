using Xunit;

namespace GroupAnagrams_49;

public class Solution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var hashStrs = new Dictionary<string, IList<string>>();
        foreach (var word in strs)
        {
            var chars = new string(word.OrderBy(c => c).ToArray());
            hashStrs.TryAdd(chars, new List<string>());
            hashStrs[chars].Add(word);
        }
        return hashStrs.Select(anagram => anagram.Value).ToList();
    }

    [Fact]
    public void Test()
    {
        var tests = new List<(IList<IList<string>> expect, string[] strs)>
        {
            (new[]
            {
                new[]{ "bat" },
                new[]{"nat","tan"},
                new[]{"ate","eat","tea"}
            }, new[] { "eat","tea","tan","ate","nat","bat" }),
            (new[]{new[]{ "a" }}, new[] { "a" }),
            (new[] { new[] { "" } }, new[] { "" })
        };
        foreach (var test in tests)
        {
            var result = GroupAnagrams(test.strs);
            Assert.Equal(test.expect, result);
        }
    }
}