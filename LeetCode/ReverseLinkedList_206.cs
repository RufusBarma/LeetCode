using LeetCode.Extensions;

namespace ReverseLinkedList_206;

public class Solution {
    public ListNode? ReverseList(ListNode? head)
    {
        ListNode? previous = null;
        while (head != null)
        {
            var newPrevious = new ListNode(head.val, previous);
            previous = newPrevious;
            head = head.next;
        }
        return previous;
    }
}