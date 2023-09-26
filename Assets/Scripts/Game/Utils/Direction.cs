using System;
using System.Numerics;

namespace Game
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
    
    public static class DirectionExtensions
    {
        public static Vector2 ToVector(this Direction direction) =>
            direction switch
            {
                Direction.Up => Vector2.UnitY,
                Direction.Down => -Vector2.UnitY,
                Direction.Left => -Vector2.UnitX,
                Direction.Right => Vector2.UnitX,
                _ => throw new NotImplementedException()
            };
    }
}