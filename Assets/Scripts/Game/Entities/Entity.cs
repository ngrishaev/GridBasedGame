using UnityEngine;

namespace Game.Entities
{
    public abstract class Entity
    {
        public Vector2 Position { get; protected set;  }

        protected Entity(int x, int y)
        {
            Position = new Vector2(x, y);
        }
    }
}