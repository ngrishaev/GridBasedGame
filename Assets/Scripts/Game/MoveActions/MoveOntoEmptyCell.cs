using System.Collections.Generic;
using System.Numerics;
using Game.Entities;

namespace Game.MoveActions
{
    public class MoveOntoEmptyCell : MoveAction
    {
        private readonly IMovable _movable;
        private readonly Vector2 _newPosition;

        public MoveOntoEmptyCell(IMovable movable, Vector2 newPosition)
        {
            _movable = movable;
            _newPosition = newPosition;
        }
        
        public override void Execute() => _movable.MoveTo(_newPosition);
    }

    public class TryPushTargetFromPosition : MoveAction
    {
        private readonly Vector2 _position;
        private readonly IMovable _pushableObject;
        private readonly IMovable _pushInitiator;
        private readonly List<Entity> _entities;

        public TryPushTargetFromPosition(
            Vector2 position,
            IMovable pushableObject,
            IMovable pushInitiator,
            List<Entity> entities)
        {
            _position = position;
            _pushableObject = pushableObject;
            _pushInitiator = pushInitiator;
            _entities = entities;
        }
        
        public override void Execute()
        {
            var initiatorPosition = _pushInitiator.Position;
            var pushingDirection = _position - initiatorPosition;

            var mp = new EntityMoveProcessor(_pushableObject, _entities);

            if(mp.TryMove(_position + pushingDirection))
                _pushInitiator.MoveTo(_position);
        }
    }
}