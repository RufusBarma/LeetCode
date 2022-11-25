using Merge_k_SortedLists_23;

namespace LeetCode.Extensions;

public class ListNode { 
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
}

public static class NodeListExtensions
{    
    public static int[] ListToArray(this ListNode? node)
    {
        var output = new List<int>();
        while (node != null)
        {
            output.Add(node.val);
            node = node.next;
        }
        return output.ToArray();
    }
    
    public static ListNode[] ToArrayListNode(this List<int[]> listArrays)
    {
        var output = new List<ListNode>();
        foreach (var array in listArrays)
            output.Add(array.ToListNode()!);
        return output.ToArray();
    }
    
    public static ListNode? ToListNode(this int[] array)
    {
        ListNode? result = null;
        ListNode? previous = null;
        foreach (var nodeVal in array)
        {
            var node = new ListNode(nodeVal);
            if (previous == null)
            {
                result = node;
                previous = node;
            }
            else
            {
                previous.next = node;
                previous = previous.next;
            }
        }
        return result;
    }
}