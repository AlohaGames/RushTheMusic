using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    public class WarriorControlManager : ControlManager
    {
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
            base.PrepareAttack();
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
            base.ReleaseAttack();
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
            base.PrepareDefense();
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
            base.ReleaseDefense();
        }
    }
}
