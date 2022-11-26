using Xunit;

namespace SingleNumber_136;

public class Solution
{
	public int solution(string S, int[] C)
	{
		var pairs = new List<Pair>();
		var currentChar = S[0];
		var count = 0;
		var sum = 0;
		var max = 0;
		for (var i = 0; i < S.Length; i++)
		{
			if (currentChar != S[i])
			{
				if (count != 0)
					pairs.Add(new Pair(sum, max));
				count = 0;
				sum = 0;
				max = 0;
				currentChar = S[i];
			}
			else
			{
				count++;
			}
			sum += C[i];
			max = C[i] > max ? C[i] : max;
		}
		if (count > 0)
			pairs.Add(new Pair(sum, max));

		return pairs.Sum(pair => pair.Sum - pair.Max);
	}

	[Fact]
	public void TestSol()
	{
		var s = "aaaa";
		var c = new[] {3, 4, 5, 6};
		Assert.Equal(12, solution(s, c));
	}

	public int solution3(int[] A)
	{
		var N = A.Length;
		var result = 0;
		for (var i = 0; i < N; i++)
			for (var j = 0; j < N; j++)
				if (A[i] == A[j])
					result = Math.Max(result, Math.Abs(i - j));
		return result;
	}

	public int solution2(int[] A)
	{
		var counter = new Dictionary<int, int>();

		for (var i = 0; i < A.Length; i++)
			if (!counter.TryAdd(A[i], 1))
				counter[A[i]]++;
		var g = counter.OrderByDescending(pair => pair.Key).FirstOrDefault(pair => pair.Key == pair.Value).Key;
		foreach (var pair in counter.OrderByDescending(pair => pair.Key))
			if (pair.Key == pair.Value)
				return pair.Key;

		return -1;
	}
	public int SingleNumber(int[] nums)
	{
		// var g = Enumerable.Repeat(0, A.Length).ToList();
		return nums.Aggregate(0, (current, num) => current ^ num);
	}

	public int Solution4(int[] nums)
	{
		var result = 0;
		foreach (var num in nums)
			result ^= num;
		return result;
	}

	[Fact]
	public void Test()
	{
		var solutions = new List<Func<int[], int>>
		{
			SingleNumber
		};
		var tests = new List<(int, int[])>
		{
			(1, new[] {1}),
			(1, new[] {2, 2, 1}),
			(4, new[] {4, 1, 2, 1, 2})
		};
		foreach (var test in tests)
		foreach (var solution in solutions)
			Assert.Equal(test.Item1, solution(test.Item2));
	}
	public struct Pair
	{
		public int Sum;
		public int Max;

		public Pair(int sum, int max)
		{
			Sum = sum;
			Max = max;
		}
	}
}