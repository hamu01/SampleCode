<Query Kind="Program" />

void Main()
{
	TreeNode n = BuildTreeNode(new int?[]{0,1,2,3,4,5,6});
	TraverseTree t = new TraverseTree(n);
	string.Join(",", t.Pre()).Dump();
	string.Join(",", t.Post()).Dump();
	string.Join(",", t.In()).Dump();
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
			nodes[i].Left = nodes[2 * i];
		}
		if (2 * i + 1 < nodes.Length && nodes[i] != null)
		{
			nodes[i].Right = nodes[2 * i + 1];
		}
	}
	if(nodes.Length > 1) {
		return nodes[1];
	}
	else {
		return nodes[0];
	}
}

public class TraverseTree
{
	private Queue<int> _pre = new Queue<int>();
	private Queue<int> _post = new Queue<int>();
	private Queue<int> _in = new Queue<int>();
	
	public Traverser(TreeNode n)
	{
		Traverse(n);
	}
	
	private void Traverse(TreeNode n)
	{
		_pre.Enqueue(n.Val);
		if(n.Left != null) 
		{
			Traverse(n.Left);
		}
		_in.Enqueue(n.Val);
		if(n.Right != null) 
		{
			Traverse(n.Right);
		}
		_post.Enqueue(n.Val);
	}
	
	public IEnumerable<int> Pre()
	{
		return _pre;
	}
	
	public IEnumerable<int> Post()
	{
		return _post;
	}
	
	public IEnumerable<int> In()
	{
		return _in;
	}
}
public class TreeNode {
	public int Val;
	public TreeNode Left;
	public TreeNode Right;
	public TreeNode(int x) { Val = x; }
}