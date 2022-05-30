using Lab4.Trees;
using System.Collections.Generic;

namespace Lab4
{
    internal class Parser
    {
        private readonly Tree<Expression> _tree;

        public Parser()
        {
            _tree = new Tree<Expression>();
        }

        public Tree<Expression> Parse(string expression)
        {
            expression = expression.Replace(" ", string.Empty);

            if (_tree.Root is not null)
            {
                _tree.Clear();
            }

            Stack<char> operatorsStack = new();
            Stack<Node<Expression>> exprStack = new();
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == ')')
                {
                    while (operatorsStack.Peek() != '(')
                    {
                        if ("=".Contains(operatorsStack.Peek()) && "=".Contains(exprStack.Peek().Expression.Value))
                        {
                            exprStack.Peek().Expression.Value += operatorsStack.Pop();
                        }
                        else
                        {
                            char operatorChar = operatorsStack.Pop();
                            Node<Expression> rightChild = exprStack.Pop();
                            Node<Expression> leftChild = exprStack.Pop();
                            exprStack.Push(new Node<Expression>(new ComplexExpression(operatorChar.ToString()), leftChild, rightChild));
                        }
                    }

                    operatorsStack.Pop();
                }
                else if (char.IsLetter(expression[i]) || char.IsDigit(expression[i]) || (expression[i] == '-' && (i == 0 || expression[i - 1] == '(')))
                {
                    string element = expression[i].ToString();
                    i++;
                    while (i < expression.Length && (char.IsLetter(expression[i]) || char.IsDigit(expression[i]) || expression[i] == '.'))
                    {
                        element += expression[i];
                        i++;
                    }

                    i--;
                    exprStack.Push(new Node<Expression>(new SimpleExpression(element)));
                }
                else if (expression[i] == '(')
                {
                    operatorsStack.Push(expression[i]);
                }
                else if ("+-*/=".Contains(expression[i]))
                {
                    while (operatorsStack.Count != 0 && GetPriority(operatorsStack.Peek()) >= GetPriority(expression[i]))
                    {
                        if (operatorsStack.Peek() == '=' && expression[i] == '=')
                        {
                            break;
                        }

                        char operatorChar = operatorsStack.Pop();
                        Node<Expression> rightChild = exprStack.Pop();
                        Node<Expression> leftChild = exprStack.Pop();
                        exprStack.Push(new Node<Expression>(new ComplexExpression(operatorChar.ToString()), leftChild, rightChild));
                    }
                    operatorsStack.Push(expression[i]);
                }
            }

            while (operatorsStack.Count != 0)
            {
                char operatorChar = operatorsStack.Pop();
                Node<Expression> rightChild = exprStack.Pop();
                Node<Expression> leftChild = exprStack.Pop();
                exprStack.Push(new Node<Expression>(new ComplexExpression(operatorChar.ToString()), leftChild, rightChild));
            }

            _tree.Root = exprStack.Pop();
            return _tree;
        }

        private static int GetPriority(char operatorChar)
        {
            switch (operatorChar)
            {
                case '(':
                    return -2;
                case ')':
                    return 1;
                case { } when "+-".Contains(operatorChar):
                    return 2;
                case { } when "*/".Contains(operatorChar):
                    return 3;
                case '=':
                    return 0;
                default:
                    return -1;
            }
        }
    }
}
