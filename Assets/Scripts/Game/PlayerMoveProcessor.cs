using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerMoveProcessor : IPlayerMover
    {
        private readonly Player _player;
        private readonly List<Entity> _entities;

        public PlayerMoveProcessor(Player player, List<Entity> entities)
        {
            _player = player;
            _entities = entities;
        }

        public void MoveUp() => TryMove(_player.position + Vector2.up);
        public void MoveDown() => TryMove(_player.position + Vector2.down);
        public void MoveLeft() => TryMove(_player.position + Vector2.left);
        public void MoveRight() => TryMove(_player.position + Vector2.right);

        private void TryMove(Vector2 newPosition)
        {
            if (IsPositionAvailable(newPosition)) 
                _player.MoveTo(newPosition);
        }


        private bool IsPositionAvailable(Vector2 position)
        {
            var entityIndex = _entities.FindIndex(e => e.position == position);
            if (entityIndex == -1)
                return true;
            
            var entity = _entities[entityIndex];
            
            return entity switch
            {
                Obstacle => false,
                Box => false,
                null => true,
                _ => true
            };
        }
    }

    public interface IPlayerMover
    {
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
    }
}