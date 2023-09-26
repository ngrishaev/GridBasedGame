using System;
using System.Numerics;

namespace Game
{
    public static class Vector2Extensions
    {
        public static bool Equals(this Vector2 vector, Vector2 other, float tolerance = 0.01f) =>
            vector.X.Equals(other.X, tolerance) && vector.Y.Equals(other.Y, tolerance);
    }
}