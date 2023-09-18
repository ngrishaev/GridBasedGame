using UnityEngine;

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

    public class PushTargetFromPosition : MoveAction
    {
        private readonly Vector2 _position;
        private readonly IMovable _pushableObject;
        private readonly IMovable _pushInitiator;

        public PushTargetFromPosition(Vector2 position, IMovable pushableObject, IMovable pushInitiator)
        {
            _position = position;
            _pushableObject = pushableObject;
            _pushInitiator = pushInitiator;
        }
        
        public override void Execute()
        {
            var initiatorPosition = _pushInitiator.Position;
            var pushingDirection = _position - initiatorPosition;
            
            _pushableObject.MoveTo(_position + pushingDirection);
            _pushInitiator.MoveTo(_position);
        }
    }
}