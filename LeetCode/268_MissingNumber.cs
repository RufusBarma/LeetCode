using Xunit;

namespace MissingNumber_268;

public class Solution
{
	public int MissingNumber(int[] nums)
	{
		var missed = 0;
		foreach (var num in nums.OrderBy(n => n))
		{
			if (num != missed)
				return missed;
			missed++;
		}
		return missed;
	}

	public int MissingNumber2(int[] nums)
	{
		var n = nums.Length;
		return n * (n + 1) / 2 - nums.Sum();
	}

	[Fact]
	public void MissingNumber_267_Test()
	{
		var solutions = new List<Func<int[], int>>
		{
			MissingNumber,
			MissingNumber2
		};
		var tests = new List<(int, int[])>
		{
			(2, new[] {3, 0, 1}),
			(8, new[] {9, 6, 4, 2, 3, 5, 7, 0, 1})
		};
		foreach (var test in tests)
		foreach (var solution in solutions)
			Assert.Equal(test.Item1, solution(test.Item2));
	}
}