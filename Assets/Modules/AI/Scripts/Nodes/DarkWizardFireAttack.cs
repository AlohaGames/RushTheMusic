using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha;

namespace Aloha.AI
{
    /// <summary>
    /// A Node that make the dark wizard (gameObject) Attack the Hero with an ice laser
    /// </summary>
    public class DarkWizardFireAttack : GONode
    {
        private DarkWizard darkWizard;

        /// <summary>
        /// LancerAttack Node Constructor
        /// </summary>
        /// <param name="graph">Graph containing the node</param>
        public DarkWizardFireAttack(Graph graph) : base(graph)
        {
            darkWizard = gameObject.GetComponent<DarkWizard>();
        }

        /// <summary>
        /// Empty Constructor
        /// </summary>
        /// <returns></returns>
        public DarkWizardFireAttack() : base()
        {
            darkWizard = gameObject.GetComponent<DarkWizard>();
        }

        /// <summary>
        /// Make the wyrmling Attack
        /// </summary>
        /// <returns></returns>
        public override IEnumerator Action()
        {
            IsRunning = true;

            // Create an ice laser
            darkWizard.FireLaser();

            while(darkWizard.isAttacking)
            {
                yield return null;
            }

            yield return null;

            if (!AutomaticLinks.IsEmpty())
            {
                TryAllLink();
            }
            IsRunning = false;
        }
    }
}
