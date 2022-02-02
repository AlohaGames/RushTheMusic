using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Aloha.EntityStats;

namespace Aloha
{
    /// <summary>
    /// Class that manage utils functions
    /// </summary>
    public class Assassin : Enemy<AssassinStats>
    {
        public Animator Anim;

        /// <summary>
        /// Is called on the frame when a script is enabled just before any of the Update methods are called the first time.
        /// </summary>
        void Start()
        {
            Anim = GetComponent<Animator>();
        }
        /// <summary>
        /// Default Awake function
        /// </summary>
        void Awake()
        {
            SoundEffectManager.Instance.Play(
                SoundEffectManager.Instance.Sounds.assassin_idle, this.gameObject, loop: true
            );
        }

        /// <summary>
        /// Override take damages function
        /// <example> Example(s):
        /// <code>
        ///     assassin.TakeDamage(20);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="damage"></param>
        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            SoundEffectManager.Instance.Play(SoundEffectManager.Instance.Sounds.assassin_hurt, this.gameObject);
        }

        /// <summary>
        /// Function to bump the assassin
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
