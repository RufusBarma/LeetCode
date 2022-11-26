namespace LinkedListCycle_141;

public class ListNode {
  public int val;
  public ListNode? next;
  public ListNode(int x) {
      val = x;
      next = null;
  }
}

public class Solution {
    public bool HasCycle(ListNode? head)
    {
        while (head?.next != null)
        {
            (head.next, head) = (head, head.next);
            if (head == head.next)
                return true;
        }
        return false;
    }
}