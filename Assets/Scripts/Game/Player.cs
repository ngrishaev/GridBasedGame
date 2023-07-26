using System;
using UnityEngine;

namespace Game
{
    public class Player : Entity
    {
        public event Action Moved;
        public int Health { get; private set; }

        public Player(int x, int y) : base(x, y)
        {
            Health = 3;
        }

        public void MoveTo(Vector2 newPosition)
        {
            position = newPosition;
            Moved?.Invoke();
        }
    }
}