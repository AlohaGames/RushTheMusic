using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// Manager that allow to control mouse hands for Warrior
    /// </summary>
    public class WarriorControlManager : ControlManager
    {
        private Animator rightHandAnimator;
        private Animator leftHandAnimator;
        private Warrior warrior;

        /// <summary>
        /// Is called on the frame when a script is enabled just before any of the Update methods are called the first time.
        /// </summary>
        void Start()
        {
            rightHandAnimator = rightHand.GetComponent<Animator>();
            leftHandAnimator = leftHand.GetComponent<Animator>();
            warrior = GameManager.Instance.GetHero() as Warrior;
        }

        /// <summary>
        /// Prepare Warrior's attack
        /// <example> Example(s):
        /// <code>
        ///     PrepareAttack()
        /// </code>
        /// </example>
        /// </summary>
        protected override void PrepareAttack()
        {
            warrior.IsAttacking = true;
            rightHandAnimator.SetTrigger("Attack");

            SoundEffectManager.Instance.Play(
                SoundEffectManager.Instance.Sounds.warrior_attack, this.gameObject
            );
        }

        /// <summary>
        /// Release Warrior's attack
        /// <example> Example(s):
        /// <code>
        ///     ReleaseAttack()
        /// </code>
        /// </example>
        /// </summary>
        protected override void ReleaseAttack() { }

        /// <summary>
        /// Prepare Warrior's defense
        /// <example> Example(s):
        /// <code>
        ///     PrepareDefense()
        /// </code>
        /// </example>
        /// </summary>
        protected override void PrepareDefense()
        {
            leftHandAnimator.SetBool("isDefending", true);
            warrior.IsDefending = true;
        }

        /// <summary>
        /// Spawn Warrior's defense
        /// <example> Example(s):
        /// <code>
        ///     PrepareDefense()
        /// </code>
        /// </example>
        /// </summary>
        protected override void ReleaseDefense()
        {
            leftHandAnimator.SetBool("isDefending", false);
            warrior.IsDefending = false;
        }
    }
}
