using System.Collections.Generic;

namespace Lab3
{
    internal class Program
    {
        private static void Main()
        {
            Game game = new(Manager.GetInstance("Oliver"), new List<Player>()
            {
                new("Max", 19),
                new("Ivan", 22),
                new("Vlad", 21)
            });

            game.Play();
        }
    }
}
