using System;

namespace Game
{
    public static class FloatExtensions
    {
        public static bool Equals(this float number, float other, float tolerance = 0.01f) =>
            Math.Abs(number - other) < tolerance;
    }
}