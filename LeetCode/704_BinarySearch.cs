using Xunit;

namespace BinarySearch_704;

public class Solution
{
    public int Search(int[] nums, int target)
    {
        var left = 0;
        var right = nums.Length - 1;
        while (left <= right)
        {
            var middle = (right + left) / 2;
            var middleNum = nums[middle];
            if (middleNum == target)
                return middle;
            if (middleNum < target)
                left = middle +1;
            else if (middleNum > target)
                right = middle -1;
        }
        return -1;
    }
    
    [Fact]
    public void Test()
    {
        var tests = new List<(int expect, (int[] nums, int target) args)>
        {
            (4, (new[] {-1,0,3,5,9,12}, 9)),
            (-1, (new[] {-1,0,3,5,9,12}, 2)),
            (0, (new[] {5}, 5)),
        };
        foreach (var test in tests)
            Assert.Equal(test.expect, Search(test.args.nums, test.args.target));
    }
}