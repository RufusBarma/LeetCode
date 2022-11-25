using LeetCode.Extensions;
using Xunit;

namespace AddTwoNumbers_2;

public class Solution 
{
    public ListNode? AddTwoNumbers(ListNode? l1, ListNode? l2)
    {
        ListNode? result = null;
        ListNode? previous = null;
        var overflowValue = 0;
        while (l1 != null || l2 != null || overflowValue != 0)
        {
            var l1Val = l1?.val ?? 0;
            var l2Val = l2?.val ?? 0;
            l1 = l1?.next;
            l2 = l2?.next;
            var sum = l1Val + l2Val + overflowValue;
            var resVal = sum % 10;
            overflowValue = sum / 10;
            var resNode = new ListNode(resVal);
            if (result == null)
            {
                result = resNode;
                previous = resNode;
            }
            else
            {
                previous!.next = resNode;
                previous = previous.next;
            }
        }
        return result;
    }
    
    [Fact]
    public void Test()
    {
        var tests = new List<((ListNode? l1, ListNode? l2) input, ListNode? result)>
        {
            ((new []{2,4,3}.ToListNode(), new []{5,6,4}.ToListNode()), new []{7, 0, 8}.ToListNode()),
            ((new []{0}.ToListNode(), new []{0}.ToListNode()), new []{0}.ToListNode()),
            ((new []{0}.ToListNode(), new []{1}.ToListNode()), new []{1}.ToListNode()),
            // ((null, null), null),
        };
        foreach (var test in tests)
        {
            var myResult = AddTwoNumbers(test.input.l1, test.input.l2).ListToArray();
            var expect = test.result.ListToArray();
            Assert.Equal(expect, myResult);
        }
    }
}