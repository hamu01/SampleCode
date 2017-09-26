<Query Kind="Program" />

void Main()
{
//	LengthOfLastWord(" ").Dump();
//	LengthOfLastWord("HelloWorldYou").Dump();
//	LengthOfLastWord("a ").Dump();
	LengthOfLastWord("a   a  ").Dump();
}

public int LengthOfLastWord1(string s) {
	int length = 0;
	int prevLength = 0;
	for (int i = 0; i < s.Length; i++)
	{
		char c = s[i];
		if(c == ' ') {
			if(length > 0) {
				prevLength = length;
			}
			length = 0;
		}
		else {
			length++;
		}
	}
	if(length <= 0) {
		return prevLength;
	}
	else {
		return length;
	}
}

public int LengthOfLastWord(string s) {
	var words = s.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
	if(words.Length > 0) {
		return words[words.Length -1 ].Length;
	}
	return 0;
}