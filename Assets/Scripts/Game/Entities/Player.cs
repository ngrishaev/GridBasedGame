using System;
using System.Numerics;

namespace Game.Entities
{
    public interface IMovable
    {
        Vector2 Position { get; }
        void MoveTo(Vector2 newPosition);
        event Action Moved;
    }
    
    public interface IDamageable
    {
        int Health { get; }
        public void TakeDamage(int damage);
        event Action Damaged;
        event Action Death;
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