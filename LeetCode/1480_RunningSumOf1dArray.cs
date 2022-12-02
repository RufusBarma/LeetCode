namespace RunningSumOf1dArray_1480;

//1480. Running Sum of 1d Array

//[1,2,3,4] = [1, 3, 6, 10]
//[1]  = [1]
//[1000] = [1000]
//[1000, 1] = [1000, 1001]
//[1000, 1000, 1000] = [1000, 2000, 3000]

public class Solution {
    public int[] RunningSum(int[] nums) {
        var result = new int[nums.Length];
        var previousSum = 0;
        for(var index = 0; index < nums.Length; index++){
            result[index] = previousSum + nums[index];
            previousSum = result[index];
        }
        return result;
    }
}