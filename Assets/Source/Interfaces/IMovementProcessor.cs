using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Source.Interfaces
{
    public interface IMovementProcessor
    {
        Vector2 CalculateVelocity(Vector2 velocity);
    }
}
