namespace ValidParentheses_20;

public class Solution
{
    public bool IsValid(string s)
    {
        var closeBrackets = new HashSet<char>{')', '}', ']'};
        var pairs = new Dictionary<char, char>(){
            {'(', ')'},
            {'{', '}'},
            {'[', ']'},
            {')', '('},
            {'}', '{'},
            {']', '['},
        };
        var openBrackets = new Stack<char>();
        foreach(var bracket in s){
            if (closeBrackets.Contains(bracket)){
                if (openBrackets.TryPop(out var lastBracket))
                {
                    if (pairs[bracket] == lastBracket)
                        continue;
                    return false;
                }else{
                    return false;
                }
            }else{
                openBrackets.Push(bracket);
            }
        }
        return openBrackets.Count == 0;
    }
}