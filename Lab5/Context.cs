using Lab5.Searchers;
using Lab5.Sorters;

namespace Lab5
{
    internal sealed class Context
    {
        private readonly ISorter _sorter;
        private readonly ISearcher _searcher;

        public Context(ISorter sorter, ISearcher searcher)
        {
            _sorter = sorter;
            _searcher = searcher;
        }

        public void Sort(int[] array) => _sorter.Sort(array);

        public int FindMin(int[] array) => _searcher.FindMin(array);

        public int FindMax(int[] array) => _searcher.FindMax(array);
    }
}
