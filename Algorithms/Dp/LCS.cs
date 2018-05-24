using System;

namespace Dp
{
    public class LCSSample
    {
        public void Run()
        {
            string s = "cnblogs";
            string t = "belong";
            LCS lcs = new LCS();
            int len = lcs.FindWithRecur(s, t);
            Console.WriteLine($"FindWithRecur: LCS of {s} and {t} is {len}");
            len = lcs.Find(s, t);
            Console.WriteLine($"Find: LCS of {s} and {t} is {len}");
        }
    }

    public class LCS
    {
        public int FindWithRecur(string s, string t)
        {
            return FindWithRecur(s, s.Length - 1, t, t.Length - 1);
        }

        private int FindWithRecur(string s, int si, string t, int ti)
        {
            if (si < 0 | ti < 0) return 0;
            if (s[si] == t[ti])
            {
                return FindWithRecur(s, si - 1, t, ti - 1) + 1;
            }
            else
            {
                return Math.Max(FindWithRecur(s, si - 1, t, ti), FindWithRecur(s, si, t, ti - 1));
            }
        }

        public int Find(string s, string t)
        {
            int[,] dp = new int[s.Length + 1, t.Length + 1];
            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 1; j <= t.Length; j++)
                {
                    if (s[i - 1] == t[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }
            return dp[s.Length, t.Length];
        }
    }
}