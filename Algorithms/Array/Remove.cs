using System;
using System.Collections.Generic;

namespace Array
{
    public class RemoveSample
    {
        public void Run()
        {
            Remove remove = new Remove();
            // RunRemoveAt(remove);
            // RunRemoveDuplicatesWithOrder(remove);
            // RunRemoveAllDuplicatesWithOrder(remove);
            // RunRemoveDuplicatesWithOutOrder(remove);
            RunRemoveAllDuplicatesWithOutOrder(remove);
        }

        private void RunRemoveAt(Remove remove)
        {
            int[] values = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Common.Print(values, "remove before: ");
            var newValues = remove.RemoveAt(values, 3);
            Common.Print(newValues, "remove  after: ");

            values = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Common.Print(values, "remove before: ");
            newValues = remove.RemoveAt(values, 0);
            Common.Print(newValues, "remove  after: ");

            values = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Common.Print(values, "remove before: ");
            newValues = remove.RemoveAt(values, values.Length - 1);
            Common.Print(newValues, "remove  after: ");

            values = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Common.Print(values, "remove before: ");
            newValues = remove.RemoveAt(values, -1);
            Common.Print(newValues, "remove  after: ");

            values = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Common.Print(values, "remove before: ");
            newValues = remove.RemoveAt(values, values.Length);
            Common.Print(newValues, "remove  after: ");
        }

        private void RunRemoveDuplicatesWithOrder(Remove remove)
        {
            Console.WriteLine("Remove Duplicates With Order: ");
            int[] values = new int[] { 1, 1, 2, 2, 3, 3, 3, 4, 5, 6, 6 };
            Common.Print(values, "Before: ");
            int[] newValues = remove.RemoveDuplicatesWithOrder(values);
            Common.Print(newValues, " After: ");

            values = new int[] { 1, 1, 1, 1, 1, 1 };
            Common.Print(values, "Before: ");
            newValues = remove.RemoveDuplicatesWithOrder(values);
            Common.Print(newValues, " After: ");

            values = new int[] { 1, 2, 3, 4, 5, 6 };
            Common.Print(values, "Before: ");
            newValues = remove.RemoveDuplicatesWithOrder(values);
            Common.Print(newValues, " After: ");

            values = new int[] { 1, 2 };
            Common.Print(values, "Before: ");
            newValues = remove.RemoveDuplicatesWithOrder(values);
            Common.Print(newValues, " After: ");

            values = new int[] { 1 };
            Common.Print(values, "Before: ");
            newValues = remove.RemoveDuplicatesWithOrder(values);
            Common.Print(newValues, " After: ");

            values = new int[] { };
            Common.Print(values, "Before: ");
            newValues = remove.RemoveDuplicatesWithOrder(values);
            Common.Print(newValues, " After: ");
        }


        private void RunRemoveAllDuplicatesWithOrder(Remove remove)
        {
            Console.WriteLine("Remove All Duplicates With Order: ");
            int[] values = new int[] { 1, 1, 2, 2, 3, 3, 3, 4, 5, 6, 6 };
            Common.Print(values, "Before: ");
            int[] newValues = remove.RemoveAllDuplicatesWithOrder(values);
            Common.Print(newValues, " After: ");

            values = new int[] { 1, 1, 1, 1, 1, 1 };
            Common.Print(values, "Before: ");
            newValues = remove.RemoveAllDuplicatesWithOrder(values);
            Common.Print(newValues, " After: ");

            values = new int[] { 1, 2, 3, 4, 5, 6 };
            Common.Print(values, "Before: ");
            newValues = remove.RemoveAllDuplicatesWithOrder(values);
            Common.Print(newValues, " After: ");

            values = new int[] { 1, 2 };
            Common.Print(values, "Before: ");
            newValues = remove.RemoveAllDuplicatesWithOrder(values);
            Common.Print(newValues, " After: ");

            values = new int[] { 1 };
            Common.Print(values, "Before: ");
            newValues = remove.RemoveAllDuplicatesWithOrder(values);
            Common.Print(newValues, " After: ");

            values = new int[] { };
            Common.Print(values, "Before: ");
            newValues = remove.RemoveAllDuplicatesWithOrder(values);
            Common.Print(newValues, " After: ");
        }


        private void RunRemoveDuplicatesWithOutOrder(Remove remove)
        {
            Console.WriteLine("Remove Duplicates WithOut Order");
            int[] values = new int[] { 11, 7, 4, 12, 3, 11, 3, 4, 5, 3, 5 };
            Common.Print(values, "Before: ");
            int[] newValues = remove.RemoveDuplicatesWithOutOrder(values);
            Common.Print(newValues, " After: ");

            values = new int[] { 1, 1, 1, 1, 1, 1 };
            Common.Print(values, "Before: ");
            newValues = remove.RemoveDuplicatesWithOutOrder(values);
            Common.Print(newValues, " After: ");

            values = new int[] { 11, 2, 3, 7, 5, 1 };
            Common.Print(values, "Before: ");
            newValues = remove.RemoveDuplicatesWithOutOrder(values);
            Common.Print(newValues, " After: ");

            values = new int[] { 1, 2 };
            Common.Print(values, "Before: ");
            newValues = remove.RemoveDuplicatesWithOutOrder(values);
            Common.Print(newValues, " After: ");

            values = new int[] { 1 };
            Common.Print(values, "Before: ");
            newValues = remove.RemoveDuplicatesWithOutOrder(values);
            Common.Print(newValues, " After: ");

            values = new int[] { };
            Common.Print(values, "Before: ");
            newValues = remove.RemoveDuplicatesWithOutOrder(values);
            Common.Print(newValues, " After: ");
        }

        private void RunRemoveAllDuplicatesWithOutOrder(Remove remove)
        {
            Console.WriteLine("Remove All Duplicates WithOut Order");
            int[] values = new int[] { 11, 7, 4, 12, 3, 11, 3, 4, 5, 3, 5 };
            Common.Print(values, "Before: ");
            int[] newValues = remove.RemoveAllDuplicatesWithOutOrder(values);
            Common.Print(newValues, " After: ");

            values = new int[] { 1, 1, 1, 1, 1, 1 };
            Common.Print(values, "Before: ");
            newValues = remove.RemoveAllDuplicatesWithOutOrder(values);
            Common.Print(newValues, " After: ");

            values = new int[] { 11, 2, 3, 7, 5, 1 };
            Common.Print(values, "Before: ");
            newValues = remove.RemoveAllDuplicatesWithOutOrder(values);
            Common.Print(newValues, " After: ");

            values = new int[] { 1, 2 };
            Common.Print(values, "Before: ");
            newValues = remove.RemoveAllDuplicatesWithOutOrder(values);
            Common.Print(newValues, " After: ");

            values = new int[] { 1 };
            Common.Print(values, "Before: ");
            newValues = remove.RemoveAllDuplicatesWithOutOrder(values);
            Common.Print(newValues, " After: ");

            values = new int[] { };
            Common.Print(values, "Before: ");
            newValues = remove.RemoveAllDuplicatesWithOutOrder(values);
            Common.Print(newValues, " After: ");
        }
    }

    public class Remove
    {
        public int[] RemoveAt(int[] values, int i)
        {
            if (i < 0 && i > values.Length - 1) return values;
            int[] newValues = new int[values.Length - 1];
            for (int j = 0; j < i; j++)
            {
                newValues[j] = values[j];
            }
            for (int j = i; j < values.Length - 1; j++)
            {
                newValues[j] = values[j + 1];
            }
            return newValues;
        }

        public int[] RemoveDuplicatesWithOrder(int[] values)
        {
            int i = 0, len = values.Length;
            while (i < len - 1)
            {
                if (values[i] == values[i + 1])
                {
                    for (int j = i + 1; j + 1 < len; j++)
                    {
                        values[j] = values[j + 1];
                    }
                    len--;
                }
                else
                {
                    i++;
                }
            }
            int[] newValues = new int[len];
            for (int j = 0; j < len; j++)
            {
                newValues[j] = values[j];
            }
            return newValues;
        }

        public int[] RemoveAllDuplicatesWithOrder(int[] values)
        {
            int i = 0, len = values.Length;
            bool duplicate = false;
            while (i < len - 1)
            {
                if (values[i] == values[i + 1])
                {
                    duplicate = true;
                    for (int j = i + 1; j + 1 < len; j++)
                    {
                        values[j] = values[j + 1];
                    }
                    len--;
                }
                else
                {
                    if (duplicate)
                    {
                        for (int j = i; j + 1 < len; j++)
                        {
                            values[j] = values[j + 1];
                        }
                        len--;
                        duplicate = false;
                    }
                    else
                    {
                        i++;
                    }
                }
            }
            if (duplicate)
            {
                for (int j = i; j + 1 < len; j++)
                {
                    values[j] = values[j + 1];
                }
                len--;
                duplicate = false;
            }
            int[] newValues = new int[len];
            for (int j = 0; j < len; j++)
            {
                newValues[j] = values[j];
            }
            return newValues;
        }

        public int[] RemoveDuplicatesWithOutOrder(int[] values)
        {
            HashSet<int> set = new HashSet<int>();
            int i = 0, len = values.Length;
            while (i < len)
            {
                if (set.Contains(values[i]))
                {
                    for (int j = i; j + 1 < len; j++)
                    {
                        values[j] = values[j + 1];
                    }
                    len--;
                }
                else
                {
                    set.Add(values[i]);
                    i++;
                }
            }
            int[] newValues = new int[len];
            for (int j = 0; j < len; j++)
            {
                newValues[j] = values[j];
            }
            return newValues;
        }

        public int[] RemoveAllDuplicatesWithOutOrder(int[] values)
        {
            HashSet<int> set = new HashSet<int>();
            HashSet<int> duplicates = new HashSet<int>();

            int i = 0, len = values.Length;
            while (i < len)
            {
                if (set.Contains(values[i]))
                {
                    duplicates.Add(values[i]);
                    for (int j = i; j + 1 < len; j++)
                    {
                        values[j] = values[j + 1];
                    }
                    len--;
                }
                else
                {
                    set.Add(values[i]);
                    i++;
                }
            }
            foreach (int d in duplicates)
            {
                for (int j = 0; j < len; j++)
                {
                    if (values[j] == d)
                    {
                        for (int k = j; k + 1 < len; k++)
                        {
                            values[k] = values[k + 1];
                        }
                    }
                }
                len--;
            }
            int[] newValues = new int[len];
            for (int j = 0; j < len; j++)
            {
                newValues[j] = values[j];
            }
            return newValues;
        }
    }
}