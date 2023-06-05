using Assets.Source.Interfaces;
using Assets.Source.ScriptableObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Assets.Source.Controllers
{
    public class HealthController : MonoBehaviour, IChildComponent
    {
        public ReactiveProperty<int> Health { get; private set; }
        private void Start()
        {
           
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                ReduceHealth(5);
            }

            if (Health.Value <= 0)
            {
                /// DIE!!!
                this.gameObject.SetActive(false);
            }
        }

        public void InitializeComponent(object configuration) 
        {
            var config = configuration as PlayerConfiguration;
            Health = new ReactiveProperty<int>(config.StartingHealth);
        }


        public void ReduceHealth(int amount)
        {
            Health.Value -= amount;
        }
    }
}
