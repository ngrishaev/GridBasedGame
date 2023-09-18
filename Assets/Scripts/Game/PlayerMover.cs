using System.Collections.Generic;
using Game.Entities;
using UnityEngine;

namespace Game
{
    public class PlayerMover: IPlayerMover
    {
        private readonly IMovable _player;
        private readonly EntityMoveProcessor _entityMoveProcessor;

        public PlayerMover(IMovable player, List<Entity> entities)
        {
            _player = player;
            _entityMoveProcessor = new EntityMoveProcessor(player, entities);
        }

        public void MoveUp() => _entityMoveProcessor.TryMove(_player.Position + Vector2.up);
        public void MoveDown() => _entityMoveProcessor.TryMove(_player.Position + Vector2.down);
        public void MoveLeft() => _entityMoveProcessor.TryMove(_player.Position + Vector2.left);
        public void MoveRight() => _entityMoveProcessor.TryMove(_player.Position + Vector2.right);
    }
}