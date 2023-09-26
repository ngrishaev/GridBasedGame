using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Game.Entities;
using Game.Weapons;

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

        
        // TODO: EmptyWeapon instead of "?"?
        public void ShootLeft() => _player.CurrentWeapon?.Shoot(Direction.Left);
        public void ShootRight() => _player.CurrentWeapon?.Shoot(Direction.Right);
        public void ShootUp() => _player.CurrentWeapon?.Shoot(Direction.Up);
        public void ShootDown() => _player.CurrentWeapon?.Shoot(Direction.Down); 
        
    }
}