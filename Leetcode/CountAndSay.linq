<Query Kind="Program" />

void Main()
{
	for (int i = 1; i <= 10; i++)
	{
		CountAndSay(i).Dump();
	}
}

public string CountAndSay(int n) {
	string r = "1";
	if(n < 1) {
		throw new ArgumentOutOfRangeException();
	}
	for (int i = 2; i <= n; i++)
	{
		StringBuilder builder = new StringBuilder();
		var chars = r.ToCharArray();
		int count = 1;
		char cur = chars[0];
		for (int j = 1; j < chars.Length; j++)
		{
			char c = chars[j];
			if(c == cur) {
				count++;
			}
			else{
				builder.Append(count);
				builder.Append(cur);
				cur = c;
				count = 1;
			}
		}
		builder.Append(count);
		builder.Append(cur);
		r = builder.ToString();
	}
	return r;
}