using System.Collections;
using UnityEngine;
using Aloha.EntityStats;

namespace Aloha
{
    /// <summary>
    /// Class for the bat
    /// </summary>
    public class Bat : Enemy<BatStats>
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
                SoundEffectManager.Instance.Sounds.bat_idle, this.gameObject, loop: true
            );
        }

        /// <summary>
        /// Override take damages function
        /// <example> Example(s):
        /// <code>
        ///     bat.TakeDamage(20);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="damage"></param>
        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            SoundEffectManager.Instance.Play(
                SoundEffectManager.Instance.Sounds.bat_hurt, this.gameObject
            );
        }
    }
}
