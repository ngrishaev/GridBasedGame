using System.Collections.Generic;
using System.Numerics;
using Game.Entities;
using Game.MoveActions;

namespace Game
{
    public class EntityMoveProcessor
    {
        private readonly IMovable _moveInitiator;
        private readonly List<Entity> _entities;

        public EntityMoveProcessor(IMovable moveInitiator, List<Entity> entities)
        {
            _moveInitiator = moveInitiator;
            _entities = entities;
        }
        public bool TryMove(Vector2 newPosition)
        {
            var oldPosition = _moveInitiator.Position;
            GetMoveAction(_moveInitiator, newPosition).Execute();
            return oldPosition != _moveInitiator.Position;
        }
        
        private MoveAction GetMoveAction(IMovable moveInitiator, Vector2 position)
        {
            var entityIndex = _entities.FindIndex(e => e.Position == position);
            if (entityIndex == -1)
                return new MoveOntoEmptyCell(moveInitiator, position);
            
            var entity = _entities[entityIndex];
            
            return entity switch
            {
                Obstacle => new EmptyAction(),
                Box box => new TryPushTargetFromPosition(position, box, moveInitiator, _entities),
                null => new MoveOntoEmptyCell(moveInitiator, position),
                _ => new MoveOntoEmptyCell(moveInitiator, position)
            };
        }
    }
}