namespace BestTimeToBuyAndSellStockII_121;

// 122. Best Time to Buy and Sell Stock II
public class Solution
{
    public int MaxProfit(int[] prices)
    {
        var lastDay = prices.Length - 1;
        var maxProfit = 0;
        var buyingDate = 0;
        var sellingDate = 0;
        for (var today = 1; today < prices.Length; today++)
        {
            var itsProfit = prices[sellingDate] > prices[today];
            var letsSell = itsProfit || today == lastDay; 
            if (!itsProfit)            
                sellingDate++;
            
            if (letsSell)
            {
                maxProfit += prices[sellingDate] - prices[buyingDate];
                buyingDate = today;
                sellingDate = today;
            }
        }
        return maxProfit;
    }
}