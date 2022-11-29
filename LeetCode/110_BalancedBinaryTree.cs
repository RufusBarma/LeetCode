namespace BalancedBinaryTree_110;

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
    public bool IsBalanced(TreeNode root) 
    {
        return CheckLength(root).balanced;
    }
    
    private (bool balanced, int height) CheckLength(TreeNode? root)
    {
        if (root == null)
            return (true, 0);

        var left = CheckLength(root.left);
        var right = CheckLength(root.right);
        
        var diff = Math.Abs(left.height - right.height);
        var height = 1 + Math.Max(left.height, right.height);
        
        return (diff <= 1 && left.balanced && right.balanced, height);
    }
}