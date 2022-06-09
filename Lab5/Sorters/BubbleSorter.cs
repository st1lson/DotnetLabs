using System;

namespace Lab5.Sorters
{
    internal sealed class BubbleSorter : ISorter
    {
        public void Sort(int[] array)
        {
            Console.WriteLine("Bubble sorter");

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        (array[j + 1], array[j]) = (array[j], array[j + 1]);
                    }
                }
            }
        }
    }
}
