using Xunit;

namespace FindAllNumbersDisappearedInAnArray_448;

public class Solution
{
	public IList<int> FindDisappearedNumbers(int[] nums)
	{
		return Enumerable.Range(1, nums.Length).Except(nums).ToList();
	}

	public IList<int> FindDisappearedNumbers2(int[] nums)
	{
		for (var i = 0; i < nums.Length; i++)
		{
			var correctPosition = nums[i] - 1;
			if (nums[i] == nums[correctPosition]) continue;
			(nums[i], nums[correctPosition]) = (nums[correctPosition], nums[i]);
			i--;
		}

		var result = new List<int>();
		for (var i = 0; i < nums.Length; i++)
			if (nums[i] != i + 1)
				result.Add(i + 1);
		return result;
	}

	public IList<int> FindDisappearedNumbers3(int[] nums)
	{
		var checkedList = new bool[nums.Length];
		foreach (var num in nums)
			checkedList[num - 1] = true;

		var result = new List<int>();
		for (var i = 0; i < checkedList.Length; i++)
			if (!checkedList[i])
				result.Add(i + 1);
		return result;
	}

	[Fact]
	public void Test()
	{
		var solutions = new List<Func<int[], IList<int>>>
		{
			FindDisappearedNumbers,
			FindDisappearedNumbers2,
			FindDisappearedNumbers3
		};
		var tests = new List<(int[], int[])>
		{
			(new[] {2}, new[] {1, 1}),
			(new[] {5, 6}, new[] {4, 3, 2, 7, 8, 2, 3, 1})
		};
		foreach (var test in tests)
		foreach (var solution in solutions)
			Assert.Equal(test.Item1, solution(test.Item2));
	}
}