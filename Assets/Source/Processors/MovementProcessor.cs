using Assets.Source.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Processors
{
    public class MovementProcessor : IMovementProcessor
    {
        private Transform _gameObject;
        private float _speed = 1;
        public MovementProcessor(Transform transform)
        {
            _gameObject = transform;
        }

        public Vector2 CalculateVelocity(Vector2 velocity)
        {
            return velocity * _speed;
        }
    }
}
