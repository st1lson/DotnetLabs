using System.Collections.Generic;

namespace Lab3
{
    internal class Game
    {
        private readonly Manager _manager;

        private readonly GameSpace _gameSpace;

        private List<Chip> _chips;

        public Game(Manager manager)
        {
            _manager = manager;
            _gameSpace = new GameSpace();
            _chips = new List<Chip>();
        }
    }
}
