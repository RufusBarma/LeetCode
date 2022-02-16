using Xunit;

namespace SingleNumber_136;

public class Solution
{
    public int SingleNumber(int[] nums)
    {
        return nums.Aggregate(0, (current, num) => current ^ num);
    }

    [Fact]
    public void Test()
    {
        var solutions = new List<Func<int[], int>>
        {
            SingleNumber,
        };
        var tests = new List<(int, int[])>()
        {
            (1, new[] {1}),
            (1, new[] {2, 2, 1}),
            (4, new[] {4,1,2,1,2}),
        };
        foreach (var test in tests)
        foreach (var solution in solutions)
        {
            Assert.Equal(test.Item1, solution(test.Item2));
        }
    }
}