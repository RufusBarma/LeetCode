using Xunit;

namespace FindPivotInde_724;

// 724. Find Pivot Index

//[1,7,3,6,5,6] = 3
//[1,2,3] = -1
//[2, 1, -1] = 0
//[1]  = 0
//[3, 2, 1] = -1
//[3,3,3,3,3] = 2

public class Solution
{
    public int PivotIndex(int[] nums)
    {
        var leftSums = new int[nums.Length];
        var rightSums = new int[nums.Length];
        var maxIndex = nums.Length - 1;
        
        {
            int GetLeft(int index) => nums[index];
            int GetRight(int index) => nums[maxIndex - index];
            var leftSum = 0;
            var rightSum = 0;
            for (var index = 0; index <= maxIndex; index++)
            {
                leftSum += GetLeft(index);
                rightSum += GetRight(index);
                leftSums[index] = leftSum;
                rightSums[maxIndex - index] = rightSum;
            }
        }
        {
            int GetSum(int index, IReadOnlyList<int> sums)
            {
                if (index < 0 || index > maxIndex)
                    return 0;
                return sums[index];
            }

            for (var index = 0; index <= maxIndex; index++)
            {
                if (GetSum(index-1, leftSums) == GetSum(index+1, rightSums))
                    return index;
            }
        }
        
        return -1;
    }
    
    public int PivotIndexLessMemory(int[] nums)
    {
        var sum = nums.Sum();
        var leftSum = 0;

        for (var index = 0; index < nums.Length; index++)
        {
            var num = nums[index];
            var rightSum = sum - (leftSum + num);
            if (leftSum == rightSum)
                return index;
            leftSum += num;
        }

        return -1;
    }
    
    [Fact]
     public void Test()
     {
         var tests = new List<(int expect, int[] nums)>
         {
             (3, new[] { 1,7,3,6,5,6 }),
         };
         foreach (var test in tests)
             Assert.Equal(test.expect, PivotIndex(test.nums));
     }
}