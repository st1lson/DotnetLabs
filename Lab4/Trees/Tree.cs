using System;
using System.Collections;
using System.Linq;

namespace Lab4.Tree
{
    internal sealed class Tree<T> where T : Expression
    {
        public int Count { get; private set; }

        internal Node<T> Root { get; set; }

        private readonly Hashtable _variables = new();

        public void Solve(out double result)
        {
            result = SymmetricalTraversal(Root);
        }

        public void Clear()
        {
            Root = null;
            Count = 0;
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
            if (value.All(char.IsLetterOrDigit))
            {
                foreach (string key in _variables.Keys)
                {
                    if (node.Expression.Value.Equals(key))
                    {
                        return double.Parse(_variables[key].ToString());
                    }
                }

                return double.Parse(value);
            }

            switch (value)
            {
                case "+":
                    result = SymmetricalTraversal(node.Childs[0]) + SymmetricalTraversal(node.Childs[1]);
                    break;
                case "-":
                    result = SymmetricalTraversal(node.Childs[0]) - SymmetricalTraversal(node.Childs[1]);
                    break;
                case "*":
                    result = SymmetricalTraversal(node.Childs[0]) * SymmetricalTraversal(node.Childs[1]);
                    break;
                case "/":
                    result = SymmetricalTraversal(node.Childs[0]) / SymmetricalTraversal(node.Childs[1]);
                    break;
                case "=":
                    if (_variables.ContainsKey(node.Childs[0].Expression.Value))
                    {
                        _variables[node.Childs[0].Expression.Value] = SymmetricalTraversal(node.Childs[1]);
                    }
                    else
                    {
                        _variables.Add(node.Childs[0].Expression.Value, SymmetricalTraversal(node.Childs[1]));
                    }

                    break;
            }

            return result;
        }
    }
}
