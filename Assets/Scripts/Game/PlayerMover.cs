using System.Collections.Generic;
using System.Numerics;
using Game.Entities;

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

        public void MoveUp() => _entityMoveProcessor.TryMove(_player.Position + Vector2.UnitY);
        public void MoveDown() => _entityMoveProcessor.TryMove(_player.Position - Vector2.UnitY);
        public void MoveLeft() => _entityMoveProcessor.TryMove(_player.Position - Vector2.UnitX);
        public void MoveRight() => _entityMoveProcessor.TryMove(_player.Position + Vector2.UnitX);
    }
}