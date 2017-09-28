<Query Kind="Program" />

void Main()
{
	PlusOne(new int[] {}).Dump();
	PlusOne(new int[] {1}).Dump();
	PlusOne(new int[] {1,0,0,1}).Dump();
	PlusOne(new int[] {9}).Dump();
	PlusOne(new int[] {9,9}).Dump();
}

public int[] PlusOne(int[] digits) {
	if(digits.Length == 0) {
		return new int[]{1};
	}
	int carry = 0;
	int add = 1;
	int[] newDigits = new int[digits.Length];
	for (int i = 0; i < digits.Length; i++)
	{
		int d = digits[digits.Length - i - 1];
		int r = d + add + carry;
		carry = r / 10;
		newDigits[newDigits.Length - i - 1] = r % 10;
		add = 0;
	}
	if(carry > 0) {
		int[] tempDigits = new int[newDigits.Length + 1];
		tempDigits[0] = carry;
		for (int i = 1; i < tempDigits.Length; i++)
		{
			tempDigits[i] = newDigits[i-1];
		}
		newDigits = tempDigits;
	}
	return newDigits;
}