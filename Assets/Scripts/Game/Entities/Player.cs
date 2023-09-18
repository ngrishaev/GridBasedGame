using System;
using UnityEngine;

namespace Game.Entities
{
    public interface IMovable
    {
        Vector2 Position { get; }
        void MoveTo(Vector2 newPosition);
        event Action Moved;
    }

    public class Player : Entity, IMovable
    {
        public event Action Moved;
        public int Health { get; private set; }

        public Player(int x, int y) : base(x, y)
        {
            Health = 3;
        }
        
        public void MoveTo(Vector2 newPosition)
        {
            Position = newPosition;
            Moved?.Invoke();
        }
    }
}