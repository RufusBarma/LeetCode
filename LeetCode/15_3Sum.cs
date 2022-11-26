namespace ThreeSum_15;

public class Solution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        var output = new List<IList<int>>();
        nums = nums.OrderBy(i => i).ToArray();
        for (var iIndex = 0; iIndex < nums.Length; iIndex++)
        {
            if (iIndex != 0 && nums[iIndex] == nums[iIndex-1])
                continue;
            var jIndex = iIndex + 1;
            var kIndex = nums.Length - 1;
            while (jIndex < kIndex)
            {
                var sum = nums[iIndex] + nums[jIndex] + nums[kIndex];
                if (sum == 0)
                {
                    output.Add(new List<int>{nums[iIndex], nums[jIndex], nums[kIndex]});
                    jIndex++;
                    while (jIndex < kIndex && nums[jIndex] == nums[jIndex - 1])
                        jIndex++;
                }
                else if (sum < 0)
                    jIndex++;
                else
                    kIndex--;
            }
        }
        return output;
    }
}