using System.Collections;

namespace Lab4.Trees
{
    internal sealed class SimpleExpression : Expression
    {
        public SimpleExpression(string value) : base(value) { }

        public override double Solve(Hashtable variables)
        {
            foreach (string key in variables.Keys)
            {
                if (Value.Equals(key))
                {
                    return double.Parse(variables[key]?.ToString() ?? string.Empty);
                }
            }

            return double.Parse(Value);
        }
    }
}
