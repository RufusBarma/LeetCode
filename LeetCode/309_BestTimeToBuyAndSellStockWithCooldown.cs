using Xunit;

namespace BestTimeToBuyAndSellStockWithTransactionFee_714;

// TODO 309. Best Time to Buy and Sell Stock with Cooldown
// public class Solution
// {
//     public int MaxProfit(int[] prices, int fee)
//     {
//         var lastDay = prices.Length - 1;
//         var maxProfit = 0;
//         var buyingDate = 0;
//         var sellingDate = 0;
//         for (var today = 1; today < prices.Length; today++)
//         {
//             var itsProfit = prices[sellingDate] > prices[today] && prices[buyingDate] - prices[sellingDate] - fee > 0;
//             // var letsSell = itsProfit || today == lastDay;
//             if (!itsProfit)
//                 sellingDate++;
//             
//             if (itsProfit)
//             {
//                 maxProfit += prices[sellingDate] - prices[buyingDate] - fee;
//                 buyingDate = today;
//                 sellingDate = today;
//             }
//         }
//         return maxProfit;
//     }
//
//     [Fact]
//     public void Test()
//     {
//         var tests = new List<(int expect, int[] prices, int fee)>
//         {
//             (6, new[] {1,3,7,5,10,3}, 3),
//         };
//         foreach (var test in tests)
//             Assert.Equal(test.expect, MaxProfit(test.prices, test.fee));
//     }
// }