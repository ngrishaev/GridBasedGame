using Game;
using UnityEngine;

namespace DriverSide.Views
{
    public class ObstacleView : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        
        private Obstacle _obstacle;

        public void Construct(Obstacle obstacle)
        {
            _obstacle = obstacle;
        }

        public void Draw()
        {
            _transform.position = new Vector3(_obstacle.position.x, _obstacle.position.y) + Vector3.one / 2;
        }
    }
}