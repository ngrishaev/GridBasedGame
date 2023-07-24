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

        public void Redraw()
        {
            _transform.position = new Vector3(_player.position.x, _player.position.y) + Vector3.one / 2;
        }
    }
}