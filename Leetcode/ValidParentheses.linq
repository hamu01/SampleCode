<Query Kind="Program" />

void Main()
{
	IsValid("").Dump();
	IsValid("[asad]").Dump();
	IsValid("[asdasd(sdas)dasd]").Dump();
	IsValid("[adasd(sd)dsd[dsd]").Dump();
	IsValid(")[").Dump();
}

// Define other methods and classes here
public bool IsValid(string s) {
	char[] chars = new char[] {'(', ')', '{', '}', '[' , ']'};
	Dictionary<char, char> dic = new Dictionary<char, char>(){
		{'(', ')'},
		{'{', '}'},
		{'[', ']'}
	};
	Stack<char> stack = new Stack<char>();
	foreach (var c in s)
	{
		if(chars.Contains(c)) {
			if(stack.Count > 0) {
				char top = stack.Peek();
				if(dic.ContainsKey(top) && dic[top] == c) {
					stack.Pop();
				}
				else {
					stack.Push(c);
				}
			}
			else {
				stack.Push(c);
			}
		}
	}
	return stack.Count == 0;
}