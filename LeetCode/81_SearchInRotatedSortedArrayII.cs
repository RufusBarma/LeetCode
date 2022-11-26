using Xunit;

namespace SearchInRotatedSortedArrayII_81;

public class Solution
{
    public bool Search(int[] nums, int target)
    {
        if (nums.Length == 0)
            return false;
        var left = 0;
        var right = nums.Length - 1;
        while (left <= right)
        {
            var middle = left + (right - left) / 2;
            if (target == nums[middle])
                return true;
            if (nums[left] == nums[middle])
            {
                left++;
                continue;
            }
            var leftIsLessMiddle = nums[left] <= nums[middle];
            var targetIsLessMiddle = target <= nums[middle];
            if (leftIsLessMiddle ^ targetIsLessMiddle)
            {
                if (leftIsLessMiddle)
                    left = middle + 1;
                else
                    right = middle - 1;
            }else
            {
                if (nums[middle] < target)
                    left = middle + 1;
                else
                    right = middle - 1;
            }
        }
        return false;
    }

    [Fact]
    public void Test()
    {
        var tests = new List<(bool expect, int[] nums, int target)>
        {
            (true, new[]
            {
                1, 0, 1, 1, 1
            }, 0),
            (true, new[]
            {
                2, 1
            }, 2),
            (true, new[]
            {
                2, 1
            }, 1),
            (true, new[]
            {
                5, 1, 2, 3, 4
            }, 1),
            (true, new[]
            {
                3, 1, 2
            }, 1),
            (false, new[]
            {
                5
            }, 1),
            (true, new[]
            {
                5
            }, 5),
            (true, new[]
            {
                11, 13, 15, 17
            }, 11),
            (true, new[]
            {
                11, 13, 15, 17
            }, 17),
            (false, new[]
            {
                0, 1, 2, 4, 6, 7
            }, 5)
        };
        foreach (var test in tests)
            Assert.Equal(test.expect, Search(test.nums, test.target));
    }
}