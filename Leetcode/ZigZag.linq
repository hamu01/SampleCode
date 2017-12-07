<Query Kind="Program" />

void Main()
{
	Convert("PAYPALISHIRING", 1).Dump();
	Convert("PAYPALISHIRING", 2).Dump();
	Convert("PAYPALISHIRING", 3).Dump();
	Convert("PAYPALISHIRING", 5).Dump();
}

public string Convert(string s, int numRows) {
	if(numRows <= 1)
	{
		return s;
	}
	Queue<char>[] rows = new Queue<char>[numRows];
	for (int i = 0; i < numRows; i++)
	{
		rows[i] = new Queue<char>();
	}
	int j = 0;
	int k = 1;
	for (int i = 0; i < s.Length; i++)
	{
		var c = s[i];
		rows[j].Enqueue(c);
		j = j + k;
		if(j == numRows)
		{
			k = -1;
			j = numRows - 2;
		}
		else if(j < 0)
		{
			k = 1;
			j = 1;
		}
	}
	string newS = "";
	foreach (var row in rows)
	{
		foreach(var c in row)
		{
			newS += c;
		}
	}
	return newS;
}