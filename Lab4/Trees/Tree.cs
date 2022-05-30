using System;
using System.Collections;

namespace Lab4.Trees
{
    internal sealed class Tree<T> where T : Expression
    {
        internal Node<T> Root { get; set; }

        private readonly Hashtable _variables = new();

        public void Solve(out double result)
        {
            result = SymmetricalTraversal(Root);
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

        private double SymmetricalTraversal(Node<T> node)
        {
            string value = node.Expression.Value;
            double result = 0;
            if (node.IsSimpleExpression())
            {
                foreach (string key in _variables.Keys)
                {
                    if (node.Expression.Value.Equals(key))
                    {
                        return double.Parse(_variables[key]?.ToString() ?? string.Empty);
                    }
                }

                return double.Parse(value);
            }

            switch (value)
            {
                case "+":
                    result = SymmetricalTraversal(node.Children[0]) + SymmetricalTraversal(node.Children[1]);
                    break;
                case "-":
                    result = SymmetricalTraversal(node.Children[0]) - SymmetricalTraversal(node.Children[1]);
                    break;
                case "*":
                    result = SymmetricalTraversal(node.Children[0]) * SymmetricalTraversal(node.Children[1]);
                    break;
                case "/":
                    result = SymmetricalTraversal(node.Children[0]) / SymmetricalTraversal(node.Children[1]);
                    break;
                case "=":
                    if (_variables.ContainsKey(node.Children[0].Expression.Value))
                    {
                        _variables[node.Children[0].Expression.Value] = SymmetricalTraversal(node.Children[1]);
                    }
                    else
                    {
                        _variables.Add(node.Children[0].Expression.Value, SymmetricalTraversal(node.Children[1]));
                    }

                    break;
            }

            return result;
        }
    }
}
