namespace SlidingWindowMaximum_239;

public class Solution
{
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        var result = new List<int>();
        var maxPoints = new LinkedList<int>();
        var windowPoints = new Queue<int>();

        foreach (var num in nums)
        {
            windowPoints.Enqueue(num);
            if (windowPoints.Count > k && maxPoints.First!.Value == windowPoints.Dequeue())                
                maxPoints.RemoveFirst();
                
            while (maxPoints.Count != 0 && maxPoints.Last!.Value < num)                
                maxPoints.RemoveLast();

            maxPoints.AddLast(num);
            result.Add(maxPoints.First!.Value);
        }

        return result.Skip(k-1).ToArray();
    }
}