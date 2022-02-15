namespace ContainsDuplicate_217;

public class Solution {
    /// <summary>
    /// <see href="https://leetcode.com/problems/contains-duplicate/">Contains duplicate on LeetCode</see>
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public bool ContainsDuplicate(int[] nums)
    {
        var seen = new HashSet<int>();
        foreach (var num in nums)
        {
            if (seen.Contains(num))
                return true;
            seen.Add(num);
        }

        return false;
    }
}