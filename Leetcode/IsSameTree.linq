<Query Kind="Program" />

void Main()
{
	TreeNode p = BuildTreeNode(new int[]{0,1,2,3,4,5,6,7,8});
	TreeNode q = BuildTreeNode(new int[]{0,1,2,3,4,5,6,7,8});
	IsSameTree(p,q).Dump();
}

public bool IsSameTree(TreeNode p, TreeNode q) {
	List<int> pList = new List<int>();
	AddToList(pList, p);
	List<int> qList = new List<int>();
	AddToList(qList, q);
	if(pList.Count == qList.Count) {
		for (int i = 0; i < pList.Count; i++)
		{
			if(pList[i] != qList[i]) {
				return false;
			}
		}
		return true;
	}
	else {
		return false;
	}
}

private void AddToList(List<int> vals, TreeNode n) {
	if(n != null) {
		vals.Add(n.val);
		AddToList(vals, n.left);
		AddToList(vals, n.right);
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

private TreeNode BuildTreeNode(int[] tree) {
	TreeNode[] nodes = new TreeNode[tree.Length];
	for (int i = 1; i < tree.Length; i++)
	{
		TreeNode node = new TreeNode(tree[i]);
		nodes[i] = node;
	}
	for (int i = 1; i < tree.Length; i++)
	{
		if(2*i < tree.Length) {
			nodes[i].left = nodes[2*i];
		}
		if(2*i+1 < tree.Length) {
			nodes[i].right = nodes[2*i+1];
		}
	}
	return nodes[1];
}