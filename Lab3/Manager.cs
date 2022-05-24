namespace Lab3
{
    internal sealed class Manager
    {
        public string Name { get; }

        private static Manager _instance;

        private Manager(string name)
        {
            Name = name;
        }

        public static Manager GetInstance(string name)
        {
            if (_instance == null)
            {
                _instance = new Manager(name);
            }

            return _instance;
        }
    }
}
