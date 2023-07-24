using Game;
using UnityEngine;

namespace DriverSide
{
    public class Input : MonoBehaviour
    {
        private Player _player;

        public void Construct(Player player)
        {
            _player = player;
        }
        
        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.W))
            {
                _player.MoveUp();
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.S))
            {
                _player.MoveDown();
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.A))
            {
                _player.MoveLeft();
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.D))
            {
                _player.MoveRight();
            }
        }
    }
}