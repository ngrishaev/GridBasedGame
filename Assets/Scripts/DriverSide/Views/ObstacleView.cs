﻿using Game.Entities;
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
            _transform.position = new Vector3(_obstacle.Position.X, _obstacle.Position.Y) + Vector3.one / 2;
        }
    }
}