using Lab4.Trees;

namespace Lab4
{
    internal class Program
    {
        private static void Main()
        {
            Parser parser = new();
            Tree<Expression> tree = parser.Parse("a = 4 + 123 * 6");
            tree.Solve(out var _);
            tree.PrintVariables();
        }
    }
}

