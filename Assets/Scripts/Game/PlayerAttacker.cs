using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Game.Entities;

namespace Game
{
    public class PlayerAttacker : IPlayerAttacker
    {
        private readonly Player _player;
        private readonly List<Entity> _entities;

        public PlayerAttacker(Player player, List<Entity> entities)
        {
            _player = player;
            _entities = entities;
        }
        
        public void ShootLeft()
        {
            throw new System.NotImplementedException();
        }

        public void ShootRight()
        {
            var shootPosition = _player.Position;
            var shootRange = 3; 
            var target = _entities
                .Where(e => IsWithinShootRange(e.Position, shootPosition, shootRange))
                .OfType<IDamageable>()
                .FirstOrDefault();
            
            target?.TakeDamage(1);
        }

        public void ShootUp()
        {
            throw new System.NotImplementedException();
        }

        public void ShootDown()
        {
            throw new System.NotImplementedException();
        }
        
        // TODO: Abstract X axis
        private bool IsWithinShootRange(Vector2 position, Vector2 shootPosition, int shootRange) => 
            position.X > shootPosition.X && position.X < shootPosition.X + shootRange;
    }
}