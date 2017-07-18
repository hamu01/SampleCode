<Query Kind="Program" />

void Main()
{
	LongestCommonPrefix(new string[]{"c","c"}).Dump();
}

// Define other methods and classes here
public string LongestCommonPrefix(string[] strs) {
	if(strs.Length == 0) {
		return string.Empty;
	}
	int minLength = strs[0].Length;
	for (int k = 1; k < strs.Length; k++)
	{
		if(minLength > strs[k].Length) {
			minLength = strs[k].Length;
		}
	}
	minLength.Dump();
	int i;
	for (i = 0; i < minLength; i++)
	{
		var initChar = strs[0][i];
		bool common = true;
		for (int j = 1; j < strs.Length; j++)
		{
			if(strs[j][i] != initChar) {
				common = false;
				break;
			}
		}
		if(!common) {
			break;
		}
	}
	if(i > 0) {
		return strs[0].Substring(0, i);
	}
	else {
		return string.Empty;
	}
}