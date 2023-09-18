using System;
using UnityEngine;

namespace Game
{
    public class Box : Entity, IMovable
    {
        public event Action Moved;
        
        public Box(int x, int y) : base(x, y)
        {
        }

        public void MoveTo(Vector2 newPosition)
        {
            Position = newPosition;
            Moved?.Invoke();
        }
    }
}