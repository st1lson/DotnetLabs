using System.Collections;

namespace Lab4.Trees
{
    internal sealed class ComplexExpression : Expression
    {
        public ComplexExpression(string value) : base(value) { }

        public ComplexExpression(string value, Expression leftChild, Expression rightChild) : base(value, leftChild, rightChild) { }

        public override double Solve(Hashtable variables)
        {
            double result = 0;

            switch (Value)
            {
                case "+":
                    result = Children[0].Solve(variables) + Children[1].Solve(variables);
                    break;
                case "-":
                    result = Children[0].Solve(variables) - Children[1].Solve(variables);
                    break;
                case "*":
                    result = Children[0].Solve(variables) * Children[1].Solve(variables);
                    break;
                case "/":
                    result = Children[0].Solve(variables) / Children[1].Solve(variables);
                    break;
                case "=":
                    if (variables.ContainsKey(Children[0].Value))
                    {
                        variables[Children[0].Value] = Children[1].Solve(variables);
                    }
                    else
                    {
                        variables.Add(Children[0].Value, Children[1].Solve(variables));
                    }

                    break;
            }

            return result;
        }
    }
}
