using System.Collections;
using System.Collections.Generic;

namespace Lab4.Trees
{
    public abstract class Expression
    {
        public string Value { get; internal set; }

        public List<Expression> Children { get; }

        protected Expression(string value, Expression leftChild, Expression rightChild)
        {
            Value = value;
            Children = new List<Expression> { leftChild, rightChild };
        }

        protected Expression(string value)
        {
            Value = value;
            Children = new List<Expression> { null, null };
        }

        public abstract double Solve(Hashtable variables);

        public bool IsSimpleExpression()
        {
            return this is SimpleExpression;
        }
    }
}
