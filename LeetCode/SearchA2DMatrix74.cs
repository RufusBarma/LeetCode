using Xunit;

namespace SearchA2DMatrix74;

public class Solution 
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        var firstColumn = matrix.Select(row => row[0]).ToArray();
        var rightColumnIndex = BinarySearch(firstColumn, target, true);
        var rightColumn = matrix[rightColumnIndex];
        return BinarySearch(rightColumn, target) > -1;
    }

    public int BinarySearch(int[] nums, int target, bool returnClosest = false)
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
        return returnClosest? right < 0? 0: right: -1;
    }

    public int BinarySearchClosest(int[] nums, int target)
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
            {
                left = middle + 1;
            }
            else if (middleNum > target)
                right = middle - 1;
        }
        return right < 0? 0: right;
    }
    
    [Fact]
    public void Test()
    {
        var tests = new List<(bool expect, (int[][] matrix, int target) args)>
        {
            (false, (new []
            {
                new []{1},
            }, 0)),
            (true, (new []
            {
                new []{1},
                new []{3},
            }, 3)),
            (true, (new []
            {
                new []{1, 3},
                new []{4, 5},
            }, 3)),
            (true, (new[]
            {
                new []{1,3,5,7},
                new []{10,11,16,20},
                new []{23,30,34,60}
            }, 3)),
            (false, (new[]
            {
                new []{1,3,5,7},
                new []{10,11,16,20},
                new []{23,30,34,60}
            }, 13)),
            (true, (new []
            {
                new []{1,3,5,7},
                new []{10,11,16,20},
                new []{23,30,34,50}
            }, 11))
        };
        foreach (var test in tests)
            Assert.Equal(test.expect, SearchMatrix(test.args.matrix, test.args.target));
    }
}