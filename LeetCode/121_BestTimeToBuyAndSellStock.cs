namespace BestTimeToBuyAndSellStock_121;

// 121. Best Time to Buy and Sell Stock
public class Solution
{
    public int MaxProfit(int[] prices)
    {
        var maxProfit = 0;
        var globalMin = prices[0];
        foreach (var price in prices)
        {
            if (price < globalMin)
                globalMin = price;
            maxProfit = Math.Max(maxProfit, price - globalMin);
        }
        return maxProfit;
    }
}