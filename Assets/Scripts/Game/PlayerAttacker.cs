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
        private readonly Player _player;

        public PlayerAttacker(Player player)
        {
            _player = player;
        }

        
        // TODO: EmptyWeapon instead of "?"?
        public void ShootLeft() => _player.CurrentWeapon?.Shoot(Direction.Left);
        public void ShootRight() => _player.CurrentWeapon?.Shoot(Direction.Right);
        public void ShootUp() => _player.CurrentWeapon?.Shoot(Direction.Up);
        public void ShootDown() => _player.CurrentWeapon?.Shoot(Direction.Down); 
        
    }
}