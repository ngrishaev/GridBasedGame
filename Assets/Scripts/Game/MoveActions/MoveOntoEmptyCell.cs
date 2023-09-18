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
}