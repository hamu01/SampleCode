<Query Kind="Program" />

void Main()
{
	Queue<int> queue = new Queue<int>();
	queue.Enqueue(1);
	queue.Enqueue(2);
	queue.Enqueue(3);
	queue.Enqueue(4);
	queue.Enqueue(5);
	queue.Size().Dump();
	queue.Dequeue().Dump();
	queue.Dequeue().Dump();
	queue.Dequeue().Dump();
	queue.Dequeue().Dump();
	queue.Dequeue().Dump();
}

// Define other methods and classes here
public class Queue<T>
{
	private Node<T> _first;
	private Node<T> _last;
	
	//add an item
	public void Enqueue(T item)
	{
		var node = new Node<T>(){Value = item};
		if(_first == null)
		{
			_first = node;
		}
		else
		{
			_last.Next = node;
		}
		_last = node;
	}
	
	//remove the least recently added item
	public T Dequeue()
	{
		if(_first != null)
		{
			var returnValue = _first;
			_first = _first.Next;
			return returnValue.Value;
		}
		else
		{
			return default(T);
		}
	}
	
	//is the queue empty?
	public bool IsEmpty() 
	{
		return _first == null;
	}
	
	//number of items in the queue
	public int Size()
	{
		int i = 0;
		var node = _first;
		while(node != null)
		{
			node = node.Next;
			i++;
		}
		return i;
	}
}

public class Node<T>
{
	public T Value { get; set; }
	
	public Node<T> Next { get; set; }
}