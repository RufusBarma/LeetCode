namespace PathSumII_113;

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
    public IList<IList<int>> PathSum(TreeNode? root, int targetSum)
    {
        var result = new List<IList<int>>();
        var stack = new Stack<(TreeNode Node, int Sum, int Index)>();
        var path = new List<int>();
        if (root != null)
            stack.Push((root, root.val, 0));
        while (stack.Count != 0)
        {
            var currentPosition = stack.Pop();
            var node = currentPosition.Node;
            var sum = currentPosition.Sum;
            var index = currentPosition.Index;

            if (index < path.Count)
                path[index] = node.val;
            else
                path.Add(node.val);

            if (node.right != null)
                stack.Push((node.right, node.right.val + sum, index + 1));
            if (node.left != null)
                stack.Push((node.left, node.left.val + sum, index + 1));

            if (node.right == null && node.left == null && sum == targetSum)
                result.Add(path.Take(index + 1).ToList());
        }
        return result;
    }
}