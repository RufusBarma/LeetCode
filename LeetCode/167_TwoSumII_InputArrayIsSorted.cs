using Xunit;

namespace TwoSumII_InputArrayIsSorted_167;

public class Solution
{
    public int[] TwoSum(int[] numbers, int target)
    {
        for (var iIndex = 0; iIndex < numbers.Length; iIndex++)
        {
            if (iIndex != 0 && numbers[iIndex] == numbers[iIndex-1])
                continue;
            var jIndex = iIndex + 1;
            while (jIndex < numbers.Length)
            {
                if (numbers[iIndex] + numbers[jIndex] == target)
                    return new []{iIndex+1, jIndex+1};
                jIndex++;
                while (jIndex < numbers.Length && numbers[jIndex] == numbers[jIndex - 1])
                    jIndex++;
            }
        }
        return Array.Empty<int>();
    }

    [Fact]
    public void Test()
    {
        var tests = new List<(int[] expect, int[] nums, int target)>
        {
            (new[]{1,3}, new[] {2,3,4}, 6),
        };
        foreach (var test in tests)
            Assert.Equal(test.expect, TwoSum(test.nums, test.target));
    }
}