using Xunit;

namespace SlidingWindowMedian_480;

// TODO 480. Sliding Window Median

// public class Solution
// {
//     public double[] MedianSlidingWindow(int[] nums, int k)
//     {
//         var result = new List<double>();
//
//         var window = new SortedList<int, int>();
//
//         var getMiddle = k % 2 != 0;
//         
//         for (var index = 0; index < nums.Length; index++)
//         {
//             window.Add(nums[index], index);
//             if (window.Count <= k)
//                 continue;
//             var median = getMiddle ? window.Values[k / 2] : window.Values[k / 2] / 2.0 + window.Values[k / 2 + 1] / 2.0;
//             result.Add(median);
//             window.RemoveAt(0);
//         }
//         return result.ToArray();
//     }
//
//     [Fact]
//     public void Test()
//     {
//         var tests = new List<(double[] expect, int[] nums, int k)>
//         {
//             (new[] { 1.00000,-1.00000,-1.00000,3.00000,5.00000,6.00000 }, new[] { 1,3,-1,-3,5,3,6,7 }, 3),
//         };
//         foreach (var test in tests)
//             Assert.Equal(test.expect, MedianSlidingWindow(test.nums, test.k));
//     }
// }