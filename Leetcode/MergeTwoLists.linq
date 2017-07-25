<Query Kind="Program" />

void Main()
{
	ListNode l1 = new ListNode(1);	l1.next = new ListNode(3);	l1.next.next = new ListNode(5);
	ListNode l2 = new ListNode(2);	l2.next = new ListNode(4);	l2.next.next = new ListNode(6);
	var p = MergeTwoLists(l1,l2);
	while(p != null) {
		p.val.Dump();
		p = p.next;
	}
	
	l1 = new ListNode(1);
	l2 = new ListNode(1);
	p = MergeTwoLists(l1,l2);
	while(p != null) {
		p.val.Dump();
		p = p.next;
	}
	
	l1 = null;
	l2 = new ListNode(1);
	p = MergeTwoLists(l1,l2);
	while(p != null) {
		p.val.Dump();
		p = p.next;
	}
	
	l1 = null;
	l2 = null;
	p = MergeTwoLists(l1,l2);
	while(p != null) {
		p.val.Dump();
		p = p.next;
	}
	Console.WriteLine ();
	
	l1 = new ListNode(1);	l1.next = new ListNode(2);	l1.next.next = new ListNode(3);
	l2 = new ListNode(2);	l2.next = new ListNode(2);	l2.next.next = new ListNode(3);
	var p = MergeTwoLists(l1,l2);
	while(p != null) {
		p.val.Dump();
		p = p.next;
	}
	
}

// Define other methods and classes here
public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
	ListNode dummy = new ListNode(0);
	ListNode p = dummy;
	while(l1 != null && l2 != null) {
		int val1 = l1.val;
		int val2 = l2.val;
		if(val1 < val2) {
			p.next = l1;
			l1 = l1.next;
		}
		else {
			p.next = l2;
			l2 = l2.next;
		}
		p = p.next;
	}
	if(l1 != null) {
		p.next = l1;
	}
	else if(l2 != null) {
		p.next = l2;
	}
	return dummy.next;
}

public class ListNode {
	public int val;
	public ListNode next;
	public ListNode(int x) { val = x; }
}