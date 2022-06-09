using System;

namespace Lab3
{
    internal class GameSpace
    {
        public static void Turn(Player player)
        {
            Console.WriteLine($"Player turn: {player.Name}");
            Console.WriteLine($"Player's chips: {string.Join(", ", player.Chips)}");
            Console.WriteLine("Turn...");
            player.Chips.Remove(player.Chips[^1]);
            if (player.Chips.Count == 0)
            {
                Console.WriteLine($"\n{player.Name} lose");
                Environment.Exit(0);
            }

            Console.WriteLine($"Player's chips: {string.Join(", ", player.Chips)}\n");
        }
    }
}
