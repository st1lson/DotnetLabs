using Lab4.Tree;
using System;

namespace Lab4
{
    class Program
    {
        static void Main()
        {
            Parser parser = new();
            Tree<Expression> tree = parser.Parse("a = 4 + 1");
            tree.Solve(out var result);
            Console.WriteLine(result);
        }
    }
}

