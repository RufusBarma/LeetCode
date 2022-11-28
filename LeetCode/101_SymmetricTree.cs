using Xunit;

namespace SymmetricTree_101;

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
    public bool IsSymmetric(TreeNode? root)
    {
        var innerQueue = new Queue<TreeNode?>();
        innerQueue.Enqueue(root?.left);
        var outerQueue = new Queue<TreeNode?>();
        outerQueue.Enqueue(root?.right);

        while (innerQueue.Count != 0 && outerQueue.Count != 0)
        {
            var inner = innerQueue.Dequeue();
            var outer = outerQueue.Dequeue();
            if (inner == null && outer == null)
                continue;
            if (inner == null ^ outer == null || inner.val != outer.val)
                return false;
            innerQueue.Enqueue(inner.right);
            innerQueue.Enqueue(inner.left);
            
            outerQueue.Enqueue(outer.left);
            outerQueue.Enqueue(outer.right);
        }
        
        return true;
    }

    [Fact]
    public void Test()
    {
        var tests = new List<(bool expected, TreeNode? p, TreeNode? q)>
        {
            (true, new TreeNode(0, new TreeNode(1), new TreeNode(2)), new TreeNode(0, new TreeNode(2), new TreeNode(1))),
            (false, new TreeNode(0, new TreeNode(1), new TreeNode(2)), new TreeNode(0, new TreeNode(1), new TreeNode(2))),
            (true, null, null),
        };
        foreach (var test in tests)
            Assert.Equal(test.expected, IsSymmetric(new TreeNode(0, test.p, test.q)));
    }
}