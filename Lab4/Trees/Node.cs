using System.Collections.Generic;

namespace Lab4.Trees
{
    internal class Node<T> where T : Expression
    {
        public T Expression { get; }

        public List<Node<T>> Children { get; }

        public Node(T expression)
        {
            Expression = expression;
            Children = new List<Node<T>> { null, null };
        }

        public Node(T expression, Node<T> leftChild, Node<T> rightChild)
        {
            Expression = expression;
            Children = new List<Node<T>> { leftChild, rightChild };
        }

        public bool IsSimpleExpression()
        {
            return Expression is SimpleExpression;
        }
    }
}
