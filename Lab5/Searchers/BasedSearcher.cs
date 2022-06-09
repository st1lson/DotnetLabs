namespace Lab5.Searchers
{
    internal sealed class BasedSearcher : ISearcher
    {
        public int FindMax(int[] array)
        {
            int max = int.MinValue;
            foreach (var number in array)
            {
                if (number > max)
                {
                    max = number;
                }
            }

            return max;
        }

        public int FindMin(int[] array)
        {
            int min = int.MaxValue;
            foreach (var number in array)
            {
                if (number < min)
                {
                    min = number;
                }
            }

            return min;
        }
    }
}
