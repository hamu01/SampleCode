<Query Kind="Program" />

void Main()
{
//	TreeNode p = BuildTreeNode(new int[]{0,1,2,3,4,5,6,7,8});
//	TreeNode q = BuildTreeNode(new int[]{0,1,2,3,4,5,6,7,8});
	
//	TreeNode p = BuildTreeNode(new int?[]{10,5,15});
//	TreeNode q = BuildTreeNode(new int?[]{10,5,null, null, 15});
	
	TreeNode p = BuildTreeNode(new int?[]{});
	TreeNode q = BuildTreeNode(new int?[]{});
	
	IsSameTree(p,q).Dump();
}

public bool IsSameTree(TreeNode p, TreeNode q)
{
	int?[] pArray = GetArray(p);
	int?[] qArray = GetArray(q);
	if (pArray.Length == qArray.Length)
	{
		for (int i = 0; i < qArray.Length; i++)
		{
			if (pArray[i] != qArray[i])
			{
				return false;
			}
		}
		return true;
	}
	else
	{
		return false;
	}
}

private int?[] GetArray(TreeNode n)
{
	if(n == null){
		return new int?[0];
	}
	int count = GetCount(n);
	int?[] array = new int?[count];
	AddToArray(array, n, 1);
	return array;
}


private int GetCount(TreeNode n)
{
	int level = GetLevel(n, 1);
	int count = (int)Math.Pow(2, level);
	return count;
}

private int GetLevel(TreeNode n, int level)
{
	int lLevel = level;
	if (n.left != null)
	{
	   lLevel = GetLevel(n.left, ++lLevel);
	}
	int rLevel = level;
	if (n.right != null)
	{
	   rLevel = GetLevel(n.right, ++rLevel);
	}
	return Math.Max(lLevel, rLevel);
}

private void AddToArray(int?[] vals, TreeNode n, int i)
{
	if (n != null)
	{
		vals[i] = n.val;
		if(2 * i < vals.Length)
		{
			AddToArray(vals, n.left, 2 * i);
		}
		if(2 * i + 1< vals.Length)
		{
			AddToArray(vals, n.right, 2 * i + 1);
		}
	}
	else
	{
		vals[i] = null;
	}
}

public bool IsSameTree1(TreeNode p, TreeNode q) {
	return Equal(p, q);
}

private bool Equal(TreeNode p, TreeNode q) {
	if(p != null && q != null) {
		if(p.val == q.val) {
			bool lq = Equal(p.left, q.left);
			bool rq = Equal(p.right, q.right);
			if(lq && rq) {
				return true;
			}
			else {
				return false;
			}
		}
		else {
			return false;
		}
	}
	else if(p == null && q == null) {
		return true;
	}
	else {
		return false;
	}
}

public class TreeNode {
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

private TreeNode BuildTreeNode(int?[] tree)
{
	TreeNode[] nodes = new TreeNode[tree.Length + 1];
	for (int i = 0; i < tree.Length; i++)
	{
		if(tree[i].HasValue) {
			TreeNode node = new TreeNode(tree[i].Value);
			nodes[i+1] = node;
		}
	}
	for (int i = 1; i < nodes.Length; i++)
	{
		if (2 * i < nodes.Length && nodes[i] != null)
		{
			nodes[i].left = nodes[2 * i];
		}
		if (2 * i + 1 < nodes.Length && nodes[i] != null)
		{
			nodes[i].right = nodes[2 * i + 1];
		}
	}
	if(nodes.Length > 1) {
		return nodes[1];
	}
	else {
		return nodes[0];
	}
}