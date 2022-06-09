using System;
using System.Collections;

namespace Lab4.Trees
{
    internal sealed class Tree<T> where T : Expression
    {
        internal T Root { get; set; }

        private readonly Hashtable _variables = new();

        public void Solve(out double result)
        {
            result = Root.Solve(_variables);
        }

        public void Clear()
        {
            Root = null;
        }

        public void PrintVariables()
        {
            foreach (var key in _variables.Keys)
            {
                Console.WriteLine($"{key} = {_variables[key]}");
            }
        }
    }
}
