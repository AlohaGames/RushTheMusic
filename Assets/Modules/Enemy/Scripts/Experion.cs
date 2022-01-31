using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Aloha.EntityStats;
using Aloha.Events;

namespace Aloha
{
    /// <summary>
    /// Class for the default lancer
    /// </summary>
    public class Experion : Enemy<ExperionStats>
    {
        public Animator Anim;

        public IntIntEvent OnHealthUpdate = new IntIntEvent();

        /// <summary>
        /// Is called on the frame when a script is enabled just before any of the Update methods are called the first time.
        /// </summary>
        void Start()
        {
            OnHealthUpdate.Invoke(this.CurrentHealth, this.GetStats().MaxHealth);
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            OnHealthUpdate.Invoke(this.CurrentHealth, this.GetStats().MaxHealth);
        }

        /// <summary>
        /// Function to bump the lancer
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="speed"></param>
        public override IEnumerator GetBump(Vector3 direction, float speed = 2)
        {
            //Anim.SetBool("isAttacking", false);
            yield return base.GetBump(direction, speed);
        }
    }
}
