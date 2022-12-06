namespace IsSubsequence_392;

// 205. Isomorphic Strings

// "a", "a" = true
// "a", "b" = false
// "a", "bab" = true
// "a", "ba" = true
// "a", "ab" = true
// "", "ab" = true
// "ab", "bab" = true

public class Solution
{
    public bool IsSubsequence(string s, string t)
    {
        if (s.Length == 0)
            return true;
        
        var currentIndex = 0;
        foreach (var tChar in t)
        {
            if (tChar == s[currentIndex])
            {
                currentIndex++;
                if (currentIndex >= s.Length)
                    return true;
            }
        }
        return false;
    }
}