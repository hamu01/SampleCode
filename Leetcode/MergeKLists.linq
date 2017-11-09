<Query Kind="Program" />

void Main()
{
	var list1 = Build(new int[]{1,4,9});
	var list2 = Build(new int[]{2,6,7});
	var list3 = Build(new int[]{3,5,8});
    var mergeList = MergeKLists(new ListNode[]{list1, list2, list3});
	ToQueue(mergeList).Dump();
	list1 = Build(new int[]{});
	list2 = Build(new int[]{});
	mergeList = MergeKLists(new ListNode[]{list1, list2});
	ToQueue(mergeList).Dump();
}

public ListNode MergeKLists(ListNode[] lists)
{
	if(lists.Length == 0)
	{
		return null;
	}
	int j = 2;
	while(j / 2 < lists.Length)
	{
		for (int i = 0; i+j/2 < lists.Length; i+=j)
		{
			lists[i] = Merge(lists[i], lists[i+j/2]);
		}
		j *= 2;
	}
	return lists[0];
}

private ListNode Merge(ListNode list1, ListNode list2)
{
	ListNode n = new ListNode(0);
	ListNode root = n;
	while(list1 != null || list2 != null)
	{
		if(list1 == null)
		{
			n.next = new ListNode(list2.val);
			list2 = list2.next;
		}
		else if(list2 == null)
		{
			n.next = new ListNode(list1.val);
			list1 = list1.next;
		}
		else if(list1.val < list2.val)
		{
			n.next = new ListNode(list1.val);
			list1 = list1.next;
		}
		else
		{
			n.next = new ListNode(list2.val);
			list2 = list2.next;
		}
		n = n.next;
	}
	return root.next;
}

public ListNode MergeKLists1(ListNode[] lists)
{
	ListNode node = new ListNode(0);
	ListNode list = node;

	while (true)
	{
		int min = GetMinIndex(lists);
		if(min == -1)
		{
			break;
		}
		node.next = new ListNode(lists[min].val);
		node = node.next;
		lists[min] = lists[min].next;
	}
	return list.next;
}

private int GetMinIndex(ListNode[] lists)
{
	int min = -1;
	for (int i = 0; i < lists.Length; i++)
	{
		if(min == -1)
		{
			if(lists[i] != null)
			{
				min = i;
			}
		}
		else if (lists[i] != null)
		{
			if (lists[i].val < lists[min].val)
			{
				min = i;
			}
		}
	}
	return min;
}
		
public ListNode Build(int[] nodeVals)
{
	if(nodeVals.Length == 0)
	{
		return null;
	}
	ListNode n = new ListNode(nodeVals[0]);
	ListNode list = n;
	for (int i = 1; i < nodeVals.Length; i++)
	{
		n.next = new ListNode(nodeVals[i]);
		n = n.next;
	}
	return list;
}

public Queue<int> ToQueue(ListNode list)
{
	Queue<int> queue = new Queue<int>();
	var n = list;
	while(n != null) 
	{
		queue.Enqueue(n.val);
		n = n.next;
	}
	return queue;
}

public class ListNode {
	public int val;
	public ListNode next;
	public ListNode(int x) { val = x; }
}