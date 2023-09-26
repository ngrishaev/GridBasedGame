using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Game.Entities;

namespace Game.Weapons
{
    public class Pistol : IWeapon
    {
        private const int Damage = 1;
        private const int ShootRange = 2;
        
        private readonly Player _player;
        private readonly List<Entity> _entities;

        private Vector2 Position => _player.Position;
        
        public Pistol(Player player, List<Entity> _entities)
        {
            _player = player;
            this._entities = _entities;
        }

        public bool CanAim(Vector2 target)
        {
            if(Position.Equals(target))
                return false;
            
            // TODO: Vec2Int?
            var isSameX = Position.X.Equals(target.X);
            var xDistance = Math.Abs(Position.X - target.X);
            
            var isSameY = Position.Y.Equals(target.Y);
            var yDistance = Math.Abs(Position.Y - target.Y);
            
            return (isSameX && yDistance <= ShootRange) || (isSameY && xDistance <= ShootRange);
        }

        public void Shoot(Direction direction)
        {
            var target = _entities
                .Where(target => CanAimInDirection(target.Position, direction))
                .OrderBy(target => Vector2.DistanceSquared(Position, target.Position))
                .OfType<IDamageable>()
                .FirstOrDefault();

            target?.TakeDamage(Damage);
        }

        private bool CanAimInDirection(Vector2 target, Direction direction) =>
            direction switch
            {
                Direction.Right => target.X > Position.X && target.X <= Position.X + ShootRange,
                Direction.Up => target.Y > Position.Y && target.Y <= Position.Y + ShootRange,
                Direction.Down => target.Y < Position.Y && target.Y >= Position.Y - ShootRange,
                Direction.Left => target.X < Position.X && target.X >= Position.X - ShootRange,
                _ => throw new NotImplementedException()
            };
    }


}