using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha;

namespace Aloha.AI
{
    /// <summary>
    /// A Node that make the dark wizard (gameObject) Attack the Hero with an ice laser
    /// </summary>
    public class ExperionIceAttack : GONode
    {
        private Experion experion;

        /// <summary>
        /// DarkWizardIceAttack Node Constructor
        /// </summary>
        /// <param name="graph">Graph containing the node</param>
        public ExperionIceAttack(Graph graph) : base(graph)
        {
            experion = gameObject.GetComponent<Experion>();
        }

        /// <summary>
        /// Empty Constructor
        /// </summary>
        /// <returns></returns>
        public ExperionIceAttack() : base()
        {
            experion = gameObject.GetComponent<Experion>();
        }

        /// <summary>
        /// Make the dark wizard ice laser Attack
        /// </summary>
        /// <returns></returns>
        public override IEnumerator Action()
        {
            IsRunning = true;

            // Create an ice laser
            experion.IceLaser();

            while(experion.IsAttacking)
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
