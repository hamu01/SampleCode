<Query Kind="Program" />

void Main()
{
	Reverse(-123).Dump();
	Reverse(1534236469).Dump();
	Reverse(-2147483648).Dump();
}

// Define other methods and classes here
public int Reverse(int x) {
	var chars = x.ToString().ToCharArray();
	int start = x > 0 ? 0 : 1;
	int minus = x > 0 ? 1 : 0;
	var newchars = new char[chars.Length];
	for (int i = chars.Length - 1; i >= start; i--)
	{
		newchars[chars.Length - i - minus] = chars[i];
	}
	if(x < 0) {
		newchars[0] = '-';
	}
	string rxStr = new string(newchars);
	int rx;
	if(int.TryParse(rxStr, out rx)) {
		return rx;
	}
	else {
		return 0;
	}
}