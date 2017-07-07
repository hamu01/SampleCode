<Query Kind="Program" />

void Main()
{
	Solution solution = new Solution();
	ListNode node1 = new ListNode(5);
	node1.next = new ListNode(4);
	node1.next.next = new ListNode(3);

	ListNode node2 = new ListNode(2);
	node2.next = new ListNode(6);
	node2.next.next = new ListNode(4);

	var result = solution.AddTwoNumbers(node1, node2);
	result.Dump();
	
	ListNode node3 = new ListNode(9);

	ListNode node4 = new ListNode(1);
	node4.next = new ListNode(9);
	node4.next.next = new ListNode(9);
	node4.next.next.next = new ListNode(9);
	node4.next.next.next.next = new ListNode(9);
	node4.next.next.next.next.next = new ListNode(9);
	node4.next.next.next.next.next.next = new ListNode(9);
	node4.next.next.next.next.next.next.next = new ListNode(9);
	node4.next.next.next.next.next.next.next.next = new ListNode(9);
	node4.next.next.next.next.next.next.next.next.next = new ListNode(9);

	result = solution.AddTwoNumbers(node3, node4);
	result.Dump();
}

// Define other methods and classes here
public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int x) { val = x; }
}

public class Solution
{
	public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
	{
		int carry = 0;
		ListNode start = new ListNode(-1);
		ListNode current = start;
		
		while(l1 != null || l2 != null)
		{
			int l1Value = l1 != null ? l1.val : 0;
			int l2Value = l2 != null ? l2.val : 0;
			int sum = l1Value + l2Value + carry;
			current.next = new ListNode(sum % 10);
			current = current.next;
			carry = sum / 10;
			if(l1 != null){
				l1 = l1.next;
			}
			if(l2 != null){
				l2 = l2.next;
			}
		}
		
		if(carry == 1){
			current.next = new ListNode(1);
		}
		return start.next;
	}
}