namespace TwoSum_1;

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        var numsWithIndex = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            var another = target - nums[i];
            if (numsWithIndex.TryGetValue(another, out var anotherIndex))
                return new []{anotherIndex, i};
            numsWithIndex.TryAdd(nums[i], i);
        }
        return Array.Empty<int>();
    }
}