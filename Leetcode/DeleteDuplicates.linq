<Query Kind="Program" />

void Main()
{
	List<int> nodes;
//	nodes = new List<int>(){1, 1, 2, 2, 3, 3};
//	nodes = new List<int>(){1, 2, 3};
	nodes = new List<int>(){1};
//	nodes = new List<int>(){};
	ListNode head = Build(nodes);
	Print(head);
	head = DeleteDuplicates(head);
	Print(head);
}

public ListNode DeleteDuplicates(ListNode head) {
	ListNode node = head;
	while(node != null) {
		ListNode n = node;
		while(n.next != null) {
			if(node.val == n.next.val) {
				n = n.next;
			}
			else {
				break;
			}
		}
		node.next = n.next;
		node = node.next;
	}
	return head;
}

public ListNode Build(List<int> nodes) {
	if(nodes.Count <= 0) {
		return null;
	}
	ListNode head = new ListNode(nodes[0]);
	ListNode node = head;
	for (int i = 1; i < nodes.Count; i++)
	{
		node.next = new ListNode(nodes[i]);
		node = node.next;
	}
	return head;
}

public void Print(ListNode node) {
	while(node != null) {
		if(node.next != null) {
			Console.Write ("{0} -> ", node.val);
		}
		else {
			Console.Write ("{0}", node.val);
		}
		node = node.next;
	}
	Console.WriteLine ();
}

public class ListNode {
	public int val;
	public ListNode next;
	public ListNode(int x) { val = x; }
}
