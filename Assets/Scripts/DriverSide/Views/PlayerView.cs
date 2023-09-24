using Game.Entities;
using UnityEngine;

namespace DriverSide.Views
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        
        private Player _player;

        public void Construct(Player player)
        {
            _player = player;
        }

        public void Draw()
        {
            _transform.position = new Vector3(_player.Position.X, _player.Position.Y) + Vector3.one / 2;
        }
    }
}