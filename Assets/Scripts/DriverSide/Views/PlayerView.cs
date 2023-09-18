using Game;
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
            _transform.position = new Vector3(_player.Position.x, _player.Position.y) + Vector3.one / 2;
        }
    }
}