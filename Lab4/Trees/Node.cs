using System.Collections.Generic;

namespace Lab4.Tree
{
    internal class Node<T> where T : Expression
    {
        public T Expression { get; }

        public List<Node<T>> Childs { get; }

        public Node(T expression)
        {
            Expression = expression;
            Childs = new() { null, null };
        }

        public Node(T expression, Node<T> leftChild, Node<T> rightChild)
        {
            Expression = expression;
            Childs = new() { leftChild, rightChild };
        }

        public bool IsSimpleExpression()
        {
            return Childs[0].Expression.GetType() == typeof(SimpleExpression) && Childs[1].Expression.GetType() == typeof(SimpleExpression);
        }
    }
}
