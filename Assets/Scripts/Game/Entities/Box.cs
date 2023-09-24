using System;
using System.Collections.Generic;
using System.Numerics;

namespace Game.Entities
{
    public class Box : Entity, IMovable, IDamageable
    {
        private readonly List<Entity> _entities;
        public event Action Moved;
        public int Health { get; private set; } = 2;
        public event Action Damaged;
        public event Action Death;

        public Box(int x, int y, List<Entity> entities) : base(x, y)
        {
            _entities = entities;
        }

        public void MoveTo(Vector2 newPosition)
        {
            Position = newPosition;
            Moved?.Invoke();
        }

        
        public void TakeDamage(int damage)
        {
            Health -= damage;
            Damaged?.Invoke();
            if (Health > 0)
                return;
            
            // Это может быть сделано в Game, но мне кажется лучше в одном месте процессить каждую смерть
            // Плюс, если вдруг сущность умирает по разному то в Game будет мешанина из разных смертей
            Death?.Invoke();
            _entities.Remove(this);
        }
    }
}