using Game;
using UnityEngine;

namespace DriverSide
{
    public class Input : MonoBehaviour
    {
        private IPlayerMover _mover;

        public void Construct(IPlayerMover mover)
        {
            _mover = mover;
        }
        
        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.W))
            {
                _mover.MoveUp();
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.S))
            {
                _mover.MoveDown();
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.A))
            {
                _mover.MoveLeft();
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.D))
            {
                _mover.MoveRight();
            }
        }
    }
}