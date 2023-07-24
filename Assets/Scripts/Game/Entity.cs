using UnityEngine;

namespace Game
{
    public abstract class Entity
    {
        public Vector2 position;

        protected Entity(int x, int y)
        {
            position = new Vector2(x, y);
        }
    }
}