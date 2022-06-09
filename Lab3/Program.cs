namespace Lab3
{
    internal class Program
    {
        private static void Main()
        {
            Game game = new(Manager.GetInstance("Oliver"));
        }
    }
}
