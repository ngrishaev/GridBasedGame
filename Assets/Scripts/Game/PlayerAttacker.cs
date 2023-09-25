using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Game.Entities;

namespace Game
{
    public class PlayerAttacker : IPlayerAttacker
    {
        private const int Damage = 1;
        private readonly Player _player;
        private readonly List<Entity> _entities;
        private const int _shootRange = 3;

        public PlayerAttacker(Player player, List<Entity> entities)
        {
            _player = player;
            _entities = entities;
        }

        public void ShootLeft() => Shoot(Direction.Left);
        public void ShootRight() => Shoot(Direction.Right);
        public void ShootUp() => Shoot(Direction.Up);
        public void ShootDown() => Shoot(Direction.Down);
        
        private void Shoot(Direction direction)
        {
            var target = _entities
                .Where(e => IsWithinShootRange(e.Position, _player.Position, _shootRange, direction))
                .OfType<IDamageable>()
                .FirstOrDefault();

            target?.TakeDamage(Damage);
        }
        
        private bool IsWithinShootRange(Vector2 position, Vector2 shootPosition, int shootRange, Direction direction) =>
            direction switch {
                Direction.Right => position.X > shootPosition.X && position.X <= shootPosition.X + shootRange,
                Direction.Up => position.Y > shootPosition.Y && position.Y <= shootPosition.Y + shootRange,
                Direction.Down => position.Y < shootPosition.Y && position.Y >= shootPosition.Y - shootRange,
                Direction.Left => position.X < shootPosition.X && position.X >= shootPosition.X - shootRange,
                _ => throw new NotImplementedException()
            };


        private enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }
    }
}