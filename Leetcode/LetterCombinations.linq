<Query Kind="Program" />

void Main()
{
	var combine = LetterCombinations("23");
	string.Join(",", combine).Dump();
	combine = LetterCombinations("");
	string.Join(",", combine).Dump();
	combine = LetterCombinations("1");
	string.Join(",", combine).Dump();
	combine = LetterCombinations("12578");
	string.Join(",", combine).Dump();
}

public IList<string> LetterCombinations(string digits) {
	Dictionary<int, string[]> map = new Dictionary<int, string[]>();
	map.Add('2', new string[]{"a","b","c"});
	map.Add('3', new string[]{"d","e","f"});
	map.Add('4', new string[]{"g","h","i"});
	map.Add('5', new string[]{"j","k","l"});
	map.Add('6', new string[]{"m","n","o"});
	map.Add('7', new string[]{"p","q","r", "s"});
	map.Add('8', new string[]{"t","u", "v"});
	map.Add('9', new string[]{"w","x","y","z"});
	
	List<string> combine = new List<string>();
	foreach (var c in digits)
	{
		if(map.ContainsKey(c))
		{
			var list = map[c];
			if(combine.Count == 0)
			{
				combine = list.ToList();
			}
			else
			{
				combine = Combine(combine, list);
			}
		}
	}
	return combine;
}

private List<string> Combine(IEnumerable<string> list1, IEnumerable<string> list2)
{
  	List<string> combine = new List<string>();
	foreach (var s1 in list1)
	{
		foreach (var s2 in list2)
		{
			combine.Add(s1+s2);
		}
	}
	return combine;
}