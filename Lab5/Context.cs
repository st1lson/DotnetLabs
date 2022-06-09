using Lab5.Searchers;
using Lab5.Sorters;

namespace Lab5
{
    internal sealed class Context
    {
        private ISorter _sorter;
        private ISearcher _searcher;

        public Context(ISorter sorter, ISearcher searcher)
        {
            _sorter = sorter;
            _searcher = searcher;
        }

        public void ChangeSorter(ISorter sorter) => _sorter = sorter;

        public void ChangeSearcher(ISearcher searcher) => _searcher = searcher;

        public void Sort(int[] array) => _sorter.Sort(array);

        public int FindMin(int[] array) => _searcher.FindMin(array);

        public int FindMax(int[] array) => _searcher.FindMax(array);
    }
}
