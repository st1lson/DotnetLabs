using Lab4.Trees;

namespace Lab4
{
    internal class Program
    {
        private static void Main()
        {
            Parser parser = new();
            Tree<Expression> tree = parser.Parse("a = 3213 + 123 / 2 * 3");
            tree.Solve(out var _);
            tree.PrintVariables();
        }
    }
}

