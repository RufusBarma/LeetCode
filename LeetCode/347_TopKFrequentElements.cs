namespace TopKFrequentElements_347;

public class Solution
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        if (nums.Length <= k)
        {
            Array.Sort(nums);
            return nums.AsEnumerable().Distinct().ToArray();
        }
        var numsCounts = new Dictionary<int, int>();
        foreach (var num in nums)
        {
            numsCounts.TryAdd(num, 0);
            numsCounts[num]++;
        }
        return numsCounts
            .OrderByDescending(wordCount => wordCount.Value)
            .Take(k)
            .Select(wordCount => wordCount.Key)
            .ToArray();
    }
}