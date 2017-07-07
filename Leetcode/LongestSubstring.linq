<Query Kind="Program" />

void Main()
{
	LengthOfLongestSubstring("abcabcbb").Dump();
	LengthOfLongestSubstring("bbbbb").Dump();
	LengthOfLongestSubstring("pwwkew").Dump();
	LengthOfLongestSubstring("c").Dump();
	LengthOfLongestSubstring("dvdf").Dump();
	LengthOfLongestSubstring("abba").Dump();
}

// Define other methods and classes here
public int LengthOfLongestSubstring(string s) {
	if (s.Length==0) {
		return 0;
	}
	Dictionary<char, int> map = new Dictionary<char, int>();
	int max=0;
	for (int i=0, j=0; i<s.Length; ++i){
		if (map.ContainsKey(s[i])){
			j = Math.Max(j, map[s[i]]+1);
		}
		map[s[i]] = i;
		max = Math.Max(max,i-j+1);
	}
	return max;
}