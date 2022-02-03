using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Aloha.EntityStats;

namespace Aloha
{
    /// <summary>
    /// Class for the default lancer
    /// </summary>
    public class Lancer : Enemy<LancerStats>
    {
        public Animator Anim;

        /// <summary>
        /// Default Awake function
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            SoundEffectManager.Instance.Play(
                SoundEffectManager.Instance.Sounds.lancer_idle, this.gameObject, loop: true
            );
        }

        /// <summary>
        /// Override take damages function
        /// <example> Example(s):
        /// <code>
        ///     lancer.TakeDamage(20);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="damage"></param>
        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            SoundEffectManager.Instance.Play(SoundEffectManager.Instance.Sounds.lancer_hurt, this.gameObject);
        }

        /// <summary>
        /// Function to bump the lancer
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="speed"></param>
        public override IEnumerator GetBump(Vector3 direction, float speed = 2)
        {
            Anim.SetBool("isAttacking", false);
            yield return base.GetBump(direction, speed);
        }
    }
}
