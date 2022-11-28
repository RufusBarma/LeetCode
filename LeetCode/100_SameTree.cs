using Xunit;

namespace SameTree_100;

public class TreeNode
{
    public TreeNode? left;
    public TreeNode? right;
    public int val;
    public TreeNode(int val = 0, TreeNode? left = null, TreeNode? right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution
{
    public bool IsSameTree(TreeNode? p, TreeNode? q)
    {
        return p != null && q != null ?
            p.val == q.val && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right):
            p == null && q == null;
    }

    [Fact]
    public void Test()
    {
        var tests = new List<(bool expected, TreeNode? p, TreeNode? q)>
        {
            (true, new TreeNode(0, new TreeNode(1), new TreeNode(2)), new TreeNode(0, new TreeNode(1), new TreeNode(2))),
            (false, new TreeNode(0, new TreeNode(1), new TreeNode(2)), new TreeNode(0, new TreeNode(1), null)),
            (true, null, null),
        };
        foreach (var test in tests)
            Assert.Equal(test.expected, IsSameTree(test.p, test.q));
    }
}