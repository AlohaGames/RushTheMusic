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
        /// Is called on the frame when a script is enabled just before any of the Update methods are called the first time.
        /// </summary>
        void Start()
        {
            Anim = GetComponent<Animator>();
        }

        void Awake()
        {
            SoundEffectManager.Instance.Play(
                SoundEffectManager.Instance.Sounds.lancer_idle, this.gameObject, loop: true
            );
        }

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
