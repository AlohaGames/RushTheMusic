using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Aloha
{
    public class WizardControlManager : ControlManager
    {
        [SerializeField]
        private UnityEvent prepareAttack;
        [SerializeField]
        private UnityEvent releaseAttack;
        [SerializeField]
        private UnityEvent prepareDefense;
        [SerializeField]
        private UnityEvent releaseDefense;

        /// <summary>
        /// Is called when the script instance is being loaded.
        /// </summary>
        private void Awake()
        {
            if (prepareAttack == null)
                prepareAttack = new UnityEvent();
            if (releaseAttack == null)
                releaseAttack = new UnityEvent();
            if (prepareDefense == null)
                prepareDefense = new UnityEvent();
            if (releaseDefense == null)
                releaseDefense = new UnityEvent();
        }

        /// <summary>
        /// Prepare Wizard's fireball
        /// <example> Example(s):
        /// <code>
        ///     PrepareAttack()
        /// </code>
        /// </example>
        /// </summary>
        protected override void PrepareAttack()
        {
            if (prepareAttack != null)
            {
                prepareAttack.Invoke();
            }
        }

        /// <summary>
        /// Send Wizard's fireball
        /// <example> Example(s):
        /// <code>
        ///     ReleaseAttack()
        /// </code>
        /// </example>
        /// </summary>
        protected override void ReleaseAttack()
        {
            if (releaseAttack != null)
            {
                releaseAttack.Invoke();
            }
        }

        /// <summary>
        /// Prepare Wizard's vortex
        /// <example> Example(s):
        /// <code>
        ///     PrepareDefense()
        /// </code>
        /// </example>
        /// </summary>
        protected override void PrepareDefense()
        {
            if (prepareDefense != null)
            {
                prepareDefense.Invoke();
            }
        }

        /// <summary>
        /// Spawn Wizard's vortex
        /// <example> Example(s):
        /// <code>
        ///     PrepareDefense()
        /// </code>
        /// </example>
        /// </summary>
        protected override void ReleaseDefense()
        {
            if (releaseDefense != null)
            {
                releaseDefense.Invoke();
            }
        }
    }
}