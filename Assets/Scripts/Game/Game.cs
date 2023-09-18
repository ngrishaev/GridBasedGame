using System.Collections;
using System.Collections.Generic;
using Game.Entities;

namespace Game
{
    public class Game
    {
        public readonly Level Level;

        public Game()
        {
            Level = new Level();
        }
    }
    
    public class Level
    {
        public readonly List<Entity> GameEntities;
        public readonly Player Player;
        public List<Obstacle> Obstacles { get; set; }
        public List<Box> Boxes { get; set; }

        public Level()
        {
            Player = new Player(3, 3);
            Obstacles = new List<Obstacle>
            {
                new Obstacle(0, 0), new Obstacle(1, 0), new Obstacle(2, 0), new Obstacle(3, 0), new Obstacle(4, 0),
                new Obstacle(5, 0), new Obstacle(6, 0), new Obstacle(7, 0), new Obstacle(8, 0), new Obstacle(9, 0),
                new Obstacle(0, 9), new Obstacle(1, 9), new Obstacle(2, 9), new Obstacle(3, 9), new Obstacle(4, 9),
                new Obstacle(5, 9), new Obstacle(6, 9), new Obstacle(7, 9), new Obstacle(8, 9), new Obstacle(9, 9),
                new Obstacle(0, 1), new Obstacle(0, 2), new Obstacle(0, 3), new Obstacle(0, 4), new Obstacle(0, 5),
                new Obstacle(0, 6), new Obstacle(0, 7), new Obstacle(0, 8), new Obstacle(9, 1), new Obstacle(9, 2),
                new Obstacle(9, 3), new Obstacle(9, 4), new Obstacle(9, 5), new Obstacle(9, 6), new Obstacle(9, 7),
                new Obstacle(9, 8),
            };

            Boxes = new List<Box>()
            {
                new Box(4, 3)
            };

            GameEntities = new List<Entity>();
            GameEntities.AddRange(Obstacles);
            GameEntities.AddRange(Boxes);
            GameEntities.Add(Player);
        }
    }
}