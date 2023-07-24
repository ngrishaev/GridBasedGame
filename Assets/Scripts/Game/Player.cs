using System;

namespace Game
{
    public class Player : Entity
    {
        public event Action Moved;
        
        public Player(int x, int y) : base(x, y)
        {
        }
        
        public void MoveUp()
        {
            position.y += 1;
            Moved?.Invoke();
        }

        public void MoveDown()
        {
            position.y -= 1;
            Moved?.Invoke();
        }

        public void MoveLeft()
        {
            position.x -= 1;
            Moved?.Invoke();
        }

        public void MoveRight()
        {
            position.x += 1;
            Moved?.Invoke();
        }
    }
}