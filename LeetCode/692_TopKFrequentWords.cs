namespace TopKFrequentWords_692;

public class Solution
{
    public IList<string> TopKFrequent(string[] words, int k) {
        if (words.Length <= k)
        {
            Array.Sort(words);
            return words.AsEnumerable().Distinct().ToArray();
        }
        var wordCounts = new Dictionary<string, int>();
        foreach (var word in words)
        {
            wordCounts.TryAdd(word, 0);
            wordCounts[word]++;
        }
        return wordCounts
            .OrderByDescending(wordCount => wordCount.Value)
            .ThenBy(wordCount => wordCount.Key)
            .Take(k)
            .Select(wordCount => wordCount.Key)
            .ToList();
    }
}