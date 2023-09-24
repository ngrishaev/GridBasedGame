using Game;
using UnityEngine;

namespace DriverSide
{
    public class Input : MonoBehaviour
    {
        private IPlayerMover _mover;
        private IPlayerAttacker _attacker;

        public void Construct(
            IPlayerMover mover,
            IPlayerAttacker attacker
            )
        {
            _mover = mover;
            _attacker = attacker;
        }
        
        private void Update()
        {
            ReadMoving();
            ReadAttack();
        }

        private void ReadAttack()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.LeftArrow))
                _attacker.ShootLeft();
            else if (UnityEngine.Input.GetKeyDown(KeyCode.RightArrow))
                _attacker.ShootRight();
            else if (UnityEngine.Input.GetKeyDown(KeyCode.UpArrow))
                _attacker.ShootUp();
            else if (UnityEngine.Input.GetKeyDown(KeyCode.DownArrow))
                _attacker.ShootDown();
        }

        private void ReadMoving()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.W))
                _mover.MoveUp();
            else if (UnityEngine.Input.GetKeyDown(KeyCode.S))
                _mover.MoveDown();
            else if (UnityEngine.Input.GetKeyDown(KeyCode.A))
                _mover.MoveLeft();
            else if (UnityEngine.Input.GetKeyDown(KeyCode.D))
                _mover.MoveRight();
        }
    }
}