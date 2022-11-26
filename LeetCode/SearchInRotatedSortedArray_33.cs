using Xunit;

namespace SearchInRotatedSortedArray_33;

public class Solution {
    public int Search(int[] nums, int target)
    {
        var leftIndex = 0;
        var rightIndex = nums.Length - 1;
        while (leftIndex <= rightIndex)
        {
            var middleIndex = leftIndex + (rightIndex - leftIndex) / 2;
            if (nums[middleIndex] == target)
                return middleIndex;
            if (nums[leftIndex] <= nums[middleIndex])
            {
                if (nums[leftIndex] <= target && target <= nums[middleIndex])
                    rightIndex = middleIndex - 1;
                else
                    leftIndex = middleIndex + 1;
            }
            else
            {
                if (nums[middleIndex] <= target && target <= nums[rightIndex])
                    leftIndex = middleIndex + 1;
                else
                    rightIndex = middleIndex - 1;
            }
        }
        return -1;
    }
    
    [Fact]
    public void Test()
    {
        var tests = new List<(int expect, (int[] nums, int target) args)>
        {
            (4, (new []{4,5,6,7,8,1,2,3}, 8)),
            (1, (new[] {3, 1}, 1)),
            (-1, (new[] {1}, 0)),
            (4, (new[] {4,5,6,7,0,1,2}, 0)),
            (4, (new[] {-1,0,3,5,9,12}, 9)),
            (-1, (new[] {-1,0,3,5,9,12}, 2)),
            (0, (new[] {5}, 5)),
        };
        foreach (var test in tests)
            Assert.Equal(test.expect, Search(test.args.nums, test.args.target));
    }
}