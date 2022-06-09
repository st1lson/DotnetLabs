using System;
using System.Collections.Generic;

namespace Lab3
{
    internal class Game
    {
        private Manager _manager;

        private readonly List<Player> _players;

        public Game(Manager manager, List<Player> players)
        {
            _manager = manager;
            _players = players;
        }

        public void Play()
        {
            while (true)
            {
                Console.WriteLine($"Game manager: {_manager.Name}");
                foreach (Player player in _players)
                {
                    GameSpace.Turn(player);
                }

                _manager = Manager.GetInstance(Guid.NewGuid().ToString());
            }
        }
    }
}
