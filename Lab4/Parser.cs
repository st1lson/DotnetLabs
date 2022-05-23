using Lab4.Tree;
using System.Collections.Generic;

namespace Lab4
{
    internal class Parser
    {
        private readonly Tree<Expression> _tree;

        public Parser()
        {
            _tree = new();
        }

        public Tree<Expression> Parse(string expression)
        {
            expression = expression.Replace(" ", string.Empty);

            if (_tree.Root is not null)
            {
                _tree.Clear();
            }

            Stack<char> operStack = new();
            Stack<Node<Expression>> exprStack = new();
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == ')')
                {
                    while (operStack.Peek() != '(')
                    {
                        char operat = operStack.Pop();
                        Node<Expression> rightChild = exprStack.Pop();
                        Node<Expression> leftChild = exprStack.Pop();
                        exprStack.Push(new Node<Expression>(new ComplexExpression(operat.ToString()), leftChild, rightChild));
                    }

                    operStack.Pop();
                }
                else if (char.IsLetter(expression[i]) || char.IsDigit(expression[i]) || (expression[i] == '-' && (i == 0 || expression[i - 1] == '(')))
                {
                    string elem = expression[i].ToString();
                    i++;
                    while (i < expression.Length && (char.IsLetter(expression[i]) || char.IsDigit(expression[i]) || expression[i] == '.'))
                    {
                        elem += expression[i];
                        i++;
                    }

                    i--;
                    exprStack.Push(new Node<Expression>(new SimpleExpression(elem)));
                }
                else if (expression[i] == '(')
                {
                    operStack.Push(expression[i]);
                }
                else if ("+-*/".Contains(expression[i]))
                {
                    while (operStack.Count != 0 && GetPriority(operStack.Peek()) >= GetPriority(expression[i]))
                    {
                        if (operStack.Peek() == '=' && expression[i] == '=')
                        {
                            break;
                        }

                        char operat = operStack.Pop();
                        Node<Expression> rightChild = exprStack.Pop();
                        Node<Expression> leftChild = exprStack.Pop();
                        exprStack.Push(new Node<Expression>(new ComplexExpression(operat.ToString()), leftChild, rightChild));
                    }
                    operStack.Push(expression[i]);
                }
            }

            while (operStack.Count != 0)
            {
                char operat = operStack.Pop();
                Node<Expression> rightChild = exprStack.Pop();
                Node<Expression> leftChild = exprStack.Pop();
                exprStack.Push(new Node<Expression>(new ComplexExpression(operat.ToString()), leftChild, rightChild));
            }

            _tree.Root = exprStack.Pop();
            return _tree;
        }

        private static int GetPriority(char oper)
        {
            switch (oper)
            {
                case '(':
                    return -2;
                case ')':
                    return 1;
                case char when "+-".Contains(oper):
                    return 2;
                case char when "*/".Contains(oper):
                    return 3;
                case '=':
                    return 0;
                default:
                    return -1;
            }
        }
    }
}
