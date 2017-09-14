namespace Basic
{
    public class Search
    {
        public int BinarySearch(int[] input, int target)
        {
            if (input.Length <= 0)
            {
                return 0;
            }
            int start = 0;
            int end = input.Length;
            while (start <= end)
            {
                int mid = start + (end - start) / 2;
                if (input[mid] == target)
                {
                    return mid;
                }
                else if (input[mid] > target)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }
            return 0;
        }
    }
}