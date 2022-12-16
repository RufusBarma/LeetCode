using Xunit;

namespace MergeTwoSortedLists_21;

// 21. Merge Two Sorted Lists

public class ListNode
{
    public int val;
    public ListNode? next;
    
    public ListNode(int val=0, ListNode? next=null) 
    {
         this.val = val;
         this.next = next;
    }

    public ListNode(List<int> values) 
    {
        this.val = values.FirstOrDefault();
        if (values.Count > 1)
            this.next = new ListNode(values.Skip(1).ToList());
    }

    public override string ToString()
    {
        var nextVal = next == null ? "" : next.ToString();
        return val + nextVal;
    }
}

public class Solution
{
    public ListNode? MergeTwoLists(ListNode? list1, ListNode? list2)
    {
        if (list1 == null)
            return list2;
        if (list2 == null)
            return list1;

        var takeList1 = list1.val <= list2.val;
        var result = takeList1? list1: list2;
        var first = result;
        var second = !takeList1? list1: list2;

        while (first != null && second != null)
        {
            if (first.next == null){
                first.next = second;
                break;
            }
            if (first.val <= second.val && first.next.val >= second.val){
                var firstTail = first.next;
                var secondTail = second.next;
                first.next = second;
                first.next.next = firstTail;
                second = secondTail;
            }
            first = first.next;
        }
        return result;
    }

    [Fact]
    public void Test()
    {
        var tests = new List<(List<int> expect, List<int> list1, List<int> list2)>
        {
             (new List<int>{1,1,2,3,4,4,5}, new List<int>{1,2,4,5}, new List<int>{1,3,4}),
             (new List<int>{1,1,2,3,4,4,5}, new List<int>{1,2,4}, new List<int>{1,3,4,5}),
        };
        foreach (var test in tests)
        {
            Assert.Equal(
                new ListNode(test.expect).ToString(),
                MergeTwoLists(new ListNode(test.list1), new ListNode(test.list2))?.ToString());
        }
    }
}