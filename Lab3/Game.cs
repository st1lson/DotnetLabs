using System.Collections.Generic;

namespace Lab3
{
    internal class Game
    {
        private readonly Manager _manager;

        private List<Chip> _chips;

        public Game(Manager manager)
        {
            _manager = manager;
            _chips = new();
        }
    }
}
