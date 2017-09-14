namespace SortResearch
{
    public class BubbleSort : ISort
    {
        public void Sort(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = a.Length - 1; j > i; j--)
                {
                    if (a[j] < a[j - 1])
                    {
                        int temp = a[j - 1];
                        a[j - 1] = a[j];
                        a[j] = temp;
                    }
                }
            }
        }
    }
}