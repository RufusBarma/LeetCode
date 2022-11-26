using Xunit;

namespace FourSum_18;

public class Solution
{
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        Array.Sort(nums);
        return kSum(nums, target, 0, 4);
    }

    private List<IList<int>> kSum(int[] nums, long target, int start, int k)
    {
        var res = new List<IList<int>>();

        if (start == nums.Length)
            return res;

        var averageValue = target / k;
        
        if (nums[start] > averageValue || averageValue > nums[nums.Length - 1])
            return res;

        if (k == 2)
            return TwoSum(nums, target, start);

        for (var i = start; i < nums.Length; ++i)
            if (i == start || nums[i - 1] != nums[i])
            {
                foreach (var subSet in kSum(nums, target - nums[i], i + 1, k - 1))
                {
                    res.Add(new List<int>(subSet.Append(nums[i])));
                }
            }

        return res;
    }

    private List<IList<int>> TwoSum(int[] nums, long target, int start)
    {
        var res = new List<IList<int>>();
        var left = start;
        var right = nums.Length - 1;

        while (left < right)
        {
            var currSum = nums[left] + nums[right];
            if (currSum < target || (left > start && nums[left] == nums[left - 1]))
                ++left;
            else if (currSum > target || (right < nums.Length - 1 && nums[right] == nums[right + 1]))
                --right;
            else
                res.Add(new List<int>{nums[left++], nums[right--]});
        }

        return res;
    }

    [Fact]
    public void Test()
    {
        var tests = new List<(int[][] expect, int[] nums, int target)>
        {
            (Array.Empty<int[]>(), new[] { -1000000000,-1000000000,1000000000,-1000000000,-1000000000 }, 294967296),
            (new[]{new[]{2, 4, -1, -3 }}, new[] { -3, -1, 0, 2, 4, 5 }, 2),
            (new[] { new[] { 2, 2, 2, 2 } }, new[] { 2, 2, 2, 2, 2 }, 8)
        };
        foreach (var test in tests)
            Assert.Equal(test.expect, FourSum(test.nums, test.target));
    }
}