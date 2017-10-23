namespace SortResearch
{
    public class MergeSort : SortBase
    {
        private int[] aud;

        public override void Sort(int[] a)
        {
            aud = new int[a.Length];
            Sort(a, 0, a.Length - 1);
        }

        private void Sort(int[] a, int low, int high)
        {
            if (low >= high)
            {
                return;
            }
            int middle = (low + high) / 2;
            Sort(a, low, middle);
            Sort(a, middle + 1, high);
            if (a[middle] > a[middle + 1])
            {
                if (high - low > 5)
                {
                    Merge(a, low, middle, high);
                }
                else
                {
                    InsertionSort(a, low, high);
                }
            }
        }

        private void InsertionSort(int[] a, int low, int high)
        {
            for (int i = low + 1; i < high + 1; i++)
            {
                for (int j = i; j > low; j--)
                {
                    if (a[j] < a[j - 1])
                    {
                        int temp = a[j];
                        a[j] = a[j - 1];
                        a[j - 1] = temp;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private void Merge(int[] a, int low, int middle, int high)
        {
            int i = low;
            int j = middle + 1;
            for (int k = low; k <= high; k++)
            {
                aud[k] = a[k];
            }
            for (int k = low; k <= high; k++)
            {
                if (i > middle)
                {
                    a[k] = aud[j++];
                }
                else if (j > high)
                {
                    a[k] = aud[i++];
                }
                else if (aud[i] < aud[j])
                {
                    a[k] = aud[i++];
                }
                else
                {
                    a[k] = aud[j++];
                }
            }
        }
    }
}