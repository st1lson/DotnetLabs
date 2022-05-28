using Lab5.Searchers;
using Lab5.Sorters;
using System;

namespace Lab5
{
    internal class Program
    {
        private static void Main()
        {
            Context context = new(sorter: new QuickSorter(), searcher: new BasedSearcher());
            int[] array = { 1, -123, 2, -10000, 1239, 1240 };
            context.Sort(array);
            Console.WriteLine(string.Join(", ", array));

            Console.WriteLine($"Max value is {context.FindMax(array)}");
            Console.WriteLine($"Min value is {context.FindMin(array)}");
        }
    }
}
