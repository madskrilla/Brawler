using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Source.ScriptableObjects
{
    [CreateAssetMenu(fileName ="playerConfig", menuName ="Configurations/Player")]
    public class PlayerConfiguration : ScriptableObject
    {
        public int StartingHealth;
        public int WalkingSpeed;
    }
}
