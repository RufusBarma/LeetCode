using Xunit;

namespace FindMinimumInRotatedSortedArray_153;

public class Solution
{
    public int FindMin(int[] nums)
    {
        var left = 0;
        var right = nums.Length - 1;
        while (left < right)
        {
            var middle = left + (right - left) / 2;
            if (nums[left] <= nums[right])
                break;
            if (nums[middle] <= nums[right])
            {
                right = middle;
                left++;
            }
            else
                left = middle == left? right: middle;
        }
        return nums[left];
    }
    
    [Fact]
    public void Test()
    {
        var tests = new List<(int expect, int[] nums)>
        {
            (1, new[] {5,1,2,3,4}),
            (1, new[] {3, 1, 2}),
            (1, new[] {2, 1}),
            (0, new[] {4,5,6,7,0,1,2}),
            (0, new[] {0,1,2,4,5,6,7}),
            (5, new[] {5}),
            (11, new[] {11,13,15,17}),
        };
        foreach (var test in tests)
            Assert.Equal(test.expect, FindMin(test.nums));
    }
}