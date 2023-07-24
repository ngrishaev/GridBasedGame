using System.Collections.Generic;

namespace Game
{
    public class Game
    {
        public readonly List<Entity> GameEntities;
        public readonly Player Player;

        public Game()
        {
            Player = new Player(0, 0);
            
            GameEntities = new List<Entity> { Player };
        }
    }
}