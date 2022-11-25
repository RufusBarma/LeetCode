using Xunit;

namespace GuessNumberHigherOrLower_374;

/** 
 * Forward declaration of guess API.
 * @param  num   your guess
 * @return 	     -1 if num is higher than the picked number
 *			      1 if num is lower than the picked number
 *               otherwise return 0
 * int guess(int num);
 */

public class Solution
{
    public int expect;
    int guess(int num)
    {
        return expect.CompareTo(num);
    }
    
    public int GuessNumber(int n)
    {
        var left = 1;
        var right = n;
        while (true)
        {
            var middle = (right - left) / 2 + left;
            var guessResult = guess(middle);
            switch (guessResult)
            {
                case 0:
                    return middle;
                case < 0:
                    right = middle - 1;
                    break;
                default:
                    left = middle + 1;
                    break;
            }
        }
    }
    
    [Fact]
    public void Test()
    {
        var tests = new List<(int expect, int n)>
        {
            (6, 10),
            (1, 1),
            (2, 2),
            (1702766719, 2126753390)
        };
        foreach (var test in tests)
        {
            expect = test.expect;
            Assert.Equal(test.expect, GuessNumber(test.n));
        }
    }
}