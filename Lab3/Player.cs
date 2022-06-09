using System.Collections.Generic;

namespace Lab3
{
    internal class Player
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public List<Chip> Chips { get; internal set; }

        public Player(string name, int age)
        {
            Name = name;
            Age = age;
            Chips = new List<Chip> { Chip.Black, Chip.White, Chip.Red };
        }
    }
}
