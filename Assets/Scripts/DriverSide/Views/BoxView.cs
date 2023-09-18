﻿using Game;
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
            _transform.position = new Vector3(_box.position.x, _box.position.y) + Vector3.one / 2;
        }
    }
}