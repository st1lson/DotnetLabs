namespace Lab4.Trees
{
    public abstract class Expression
    {
        public string Value { get; internal set; }

        protected Expression(string value)
        {
            Value = value;
        }
    }
}
