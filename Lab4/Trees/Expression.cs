namespace Lab4.Tree
{
    public abstract class Expression
    {
        public string Value { get; internal set; }

        public Expression(string value)
        {
            Value = value;
        }
    }
}
