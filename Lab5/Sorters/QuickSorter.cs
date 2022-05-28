using System;

namespace Lab5.Sorters
{
    internal sealed class QuickSorter : ISorter
    {
        public void Sort(int[] array)
        {
            Console.WriteLine("Quick sorter");
            Sort(array, 0, array.Length - 1);
        }

        private static void Sort(int[] array, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int pivot = Partition(array, left, right);
            if (pivot > 1)
            {
                Sort(array, left, pivot - 1);
            }

            if (pivot + 1 < right)
            {
                Sort(array, pivot + 1, right);
            }
        }

        private static int Partition(int[] array, int left, int right)
        {
            int pivot = array[left];

            while (true)
            {
                while (array[left] < pivot)
                {
                    left++;
                }

                while (array[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    (array[right], array[left]) = (array[left], array[right]);
                }

                else
                {
                    return right;
                }
            }
        }
    }
}
