using Lab4.Tree;

namespace Lab4
{
    class Program
    {
        static void Main()
        {
            Parser parser = new();
            Tree<Expression> tree = parser.Parse("a = 4 + 123 * 6");
            tree.Solve(out var _);
            tree.PrintVariables();
        }
    }
}

