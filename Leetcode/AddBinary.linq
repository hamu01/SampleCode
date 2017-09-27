<Query Kind="Program" />

void Main()
{
	AddBinary("10010", "1100101010").Dump();
	AddBinary("10010", "01010").Dump();
	AddBinary("10110", "01010").Dump();
}

public string AddBinary(string a, string b) {
	int minLen = Math.Min(a.Length, b.Length);
	int maxLen = Math.Max(a.Length, b.Length);
	char[] result = new char[maxLen+1];
	int carry = 0;
	for (int i = 0; i < minLen; i++)
	{
		var j =  int.Parse(a[a.Length - i - 1].ToString());
		var k = int.Parse(b[b.Length - i - 1].ToString());
		var r = Add(j, k, carry);
		carry = r.Carry;
		result[result.Length - i - 1] = char.Parse(r.Cur.ToString());
	}
	string c = a.Length > b.Length ? a : b;
	for (int i = minLen; i < maxLen; i++)
	{
		var j = byte.Parse(c[c.Length -i - 1].ToString());
		var r = Add(j, carry);
		carry = r.Carry;
		result[result.Length - i - 1] = char.Parse(r.Cur.ToString());
	}
	result[0] = char.Parse(carry.ToString());
	if(result[0] == '0') {
		char[] newResult = new char[result.Length - 1];
		for (int i = 1; i < result.Length; i++)
		{
			newResult[i-1] = result[i];
		}
		return new string(newResult);
	}
	else {
		return new string(result);
	}
}

private Result Add(int j, int k, int c) {
	var r = Add(j, k);
	var r1 = Add(r.Cur, c);
	return new Result(r1.Cur, Math.Max(r.Carry,r1.Carry));
}

private Result Add(int j, int k) {
	int carry = j & k;
	int cur = j ^ k;
	return new Result(cur, carry);
}

public struct Result {
	public int Cur;
	public int Carry;
	
	public Result(int cur, int carry)
	{
		Cur = cur;
		Carry = carry;
	}
}