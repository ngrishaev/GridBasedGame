using System.Collections.Generic;
using Game.MoveActions;
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

        public void MoveUp() => TryMove(_player.Position + Vector2.up);
        public void MoveDown() => TryMove(_player.Position + Vector2.down);
        public void MoveLeft() => TryMove(_player.Position + Vector2.left);
        public void MoveRight() => TryMove(_player.Position + Vector2.right);

        private void TryMove(Vector2 newPosition)
        {
            GetMoveAction(_player, newPosition).Execute();
        }


        private MoveAction GetMoveAction(Player player, Vector2 position)
        {
            var entityIndex = _entities.FindIndex(e => e.Position == position);
            if (entityIndex == -1)
                return new MoveOntoEmptyCell(player, position);
            
            var entity = _entities[entityIndex];
            
            return entity switch
            {
                Obstacle => new EmptyAction(),
                Box box => new PushTargetFromPosition(position, box, player),
                null => new MoveOntoEmptyCell(player, position),
                _ => new MoveOntoEmptyCell(player, position)
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