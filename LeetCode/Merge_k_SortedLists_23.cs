using LeetCode.Extensions;
using Xunit;

namespace Merge_k_SortedLists_23;

public class Solution
{
    public ListNode MergeKLists(ListNode?[] lists)
    {
        ListNode? result = null;
        ListNode? pointer = null;
        
        while (true)
        {
            var minNodeIndex = -1;
            for (var i = 0; i < lists.Length; i++)
            {
                if (lists[i] == null)
                    continue;
                if (minNodeIndex < 0 || lists[minNodeIndex].val >= lists[i].val)
                {
                    minNodeIndex = i;
                }
            }
            if (minNodeIndex < 0)
                return result;
            if (result == null)
            {
                result = new ListNode(lists[minNodeIndex]!.val);
                pointer = result;
            }
            else
            {
                if (pointer == result)
                    result.next = new ListNode(lists[minNodeIndex]!.val);
                else
                    pointer.next = new ListNode(lists[minNodeIndex]!.val);
                pointer = pointer.next;
            }
            lists[minNodeIndex] = lists[minNodeIndex]?.next;
        }
    }
    
    [Fact]
    public void Test()
    {
        var tests = new List<(List<int[]>, int[])>
        {
            (new List<int[]>{Array.Empty<int>()}, Array.Empty<int>()),
            (new List<int[]>(), Array.Empty<int>()),
            (new List<int[]> { new []{1,4,5}, new []{1,3,4}, new []{2,6} }, new[] {1,1,2,3,4,4,5,6})
        };
        foreach (var test in tests)
            Assert.Equal(test.Item2, MergeKLists(test.Item1.ToArrayListNode()).ListToArray());
    }
}