namespace MergeIntervals_56;

public class Solution
{
    public int[][] Merge(int[][] intervals)
    {
        if (intervals.Length == 0)
            return intervals;
        Array.Sort(intervals, (left, right) => left[0].CompareTo(right[0]));
        var result = new List<int[]>();
        var intervalToAdd = intervals[0];
        foreach(var interval in intervals.Skip(1)){
            if (interval[0] >= intervalToAdd[0] && interval[1] <= intervalToAdd[1])
                continue;
            if (interval[0] > intervalToAdd[1])
            {                
                result.Add(intervalToAdd);
                intervalToAdd = interval;
                continue;
            }
            intervalToAdd[1] = interval[1];
        }
        result.Add(intervalToAdd);
        return result.ToArray();
    }
}