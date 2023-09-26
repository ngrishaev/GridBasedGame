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
        
        public Pistol(Player player, List<Entity> entities)
        {
            _player = player;
            _entities = entities;
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
                .Where(target => IsInDirection(target.Position, direction) && CanAim(target.Position))
                .OrderBy(target => Vector2.DistanceSquared(Position, target.Position))
                .OfType<IDamageable>()
                .FirstOrDefault();

            target?.TakeDamage(Damage);
        }

        private bool IsInDirection(Vector2 target, Direction direction) =>
            direction switch
            {
                Direction.Right or Direction.Left => target.Y.Equals(Position.Y),
                Direction.Up or Direction.Down => target.X.Equals(Position.X),
                _ => throw new NotImplementedException()
            };
    }


}