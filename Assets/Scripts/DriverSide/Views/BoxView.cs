using Game;
using Game.Entities;
using UnityEngine;

namespace DriverSide.Views
{
    public class BoxView : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        
        private Box _box;

        public void Construct(Box obstacle)
        {
            _box = obstacle;
        }

        public void Draw()
        {
            _transform.position = new Vector3(_box.Position.x, _box.Position.y) + Vector3.one / 2;
        }
    }
}