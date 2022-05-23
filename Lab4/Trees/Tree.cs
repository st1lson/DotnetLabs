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

        public Node<T> Add(T item, NodePosition position, Node<T> node = null)
        {
            if (Root is null && node is null)
            {
                Root = new Node<T>(item);
                Count++;
                return Root;
            }

            Node<T> createdNode;
            if (position == NodePosition.Left)
            {
                createdNode = node.Childs[0] = new Node<T>(item);
            }
            else
            {
                createdNode = node.Childs[1] = new Node<T>(item);
            }

            Count++;
            return createdNode;
        }

        public void Clear()
        {
            Root = null;
            Count = 0;
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
