using System.Numerics;

namespace Game.Weapons
{
    public interface IWeapon
    {
        bool CanAim(Vector2 target);
        void Shoot(Direction direction);
    }
}