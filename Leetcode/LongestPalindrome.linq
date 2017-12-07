<Query Kind="Program" />

void Main()
{
	LongestPalindrome("").Dump();
	LongestPalindrome("babad").Dump();
	LongestPalindrome("dbbc").Dump();
	LongestPalindrome("rdbtbdr").Dump();
	LongestPalindrome("bb").Dump();
}

public string LongestPalindrome(string s) {
	string longest = "";
	for (int i = 0; i < s.Length; i++)
	{
		string palin = LongestPalindrome(s,i);
		string palin1 = LongestPalindrome2(s,i);
		if(palin.Length > longest.Length)
		{
			longest = palin;
		}
		if(palin1.Length > longest.Length)
		{
			longest = palin1;
		}
	}
	return longest;
}

private string LongestPalindrome(string s, int i) {
	if(i == 0)
	{
		return s[0].ToString();
	}
	int j = 1;
	while(true)
	{
		if(i - j < 0)
		{
			break;
		}
		if(i + j > s.Length - 1)
		{
			break;
		}
		if(s[i+j] == s[i-j])
		{
			j++;
		}
		else
		{
			break;
		}
	}
	j--;
	
	return s.Substring(i-j,2*j+1);
}

private string LongestPalindrome2(string s, int i) {
	int j = 0;
	while(true)
	{
		if(i - j < 0)
		{
			break;
		}
		if(i + j + 1 > s.Length - 1)
		{
			break;
		}
		if(s[i-j] == s[i+j+1])
		{
			j++;
		}
		else
		{
			break;
		}
	}
	j--;
	if(j >= 0)
	{
		return s.Substring(i - j, 2 * j + 2);
	}
	else
	{
		return string.Empty;
	}
}