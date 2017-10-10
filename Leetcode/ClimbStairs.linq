<Query Kind="Program" />

void Main()
{
	Solution solution = new Solution();
	Stopwatch watch = Stopwatch.StartNew();
	for (int i = 0; i < 49; i++)
	{
		solution.ClimbStairs(i).Dump();
	}
//	solution.ClimbStairs(6).Dump();
	watch.Elapsed.Dump();
}

public class Solution {
	private Dictionary<int, int> _dic = new Dictionary<int,int>();
	
	public int ClimbStairs(int n) {
		if(_dic.ContainsKey(n)) {
			return _dic[n];
		}
		int count;
		if(n == 0) {
			count = 0;
		}
		else if(n == 1) {
			count = 1;
		}
		else if(n == 2){
			count = 2;
		}
		else {
			count = ClimbStairs(n-1) + ClimbStairs(n-2);
		}
		_dic[n] = count;
		return count;
	}
}