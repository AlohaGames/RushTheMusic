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

        void Start()
        {
            rightHandAnimator = rightHand.GetComponent<Animator>();
            leftHandAnimator = leftHand.GetComponent<Animator>();
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
            rightHandAnimator.SetTrigger("Attack");
        }

        /// <summary>
        /// Release Warrior's attack
        /// <example> Example(s):
        /// <code>
        ///     ReleaseAttack()
        /// </code>
        /// </example>
        /// </summary>
        protected override void ReleaseAttack()
        {
        }

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
        }
    }
}
