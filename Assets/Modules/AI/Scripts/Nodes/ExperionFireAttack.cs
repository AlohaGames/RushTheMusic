using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha;

namespace Aloha.AI
{
    /// <summary>
    /// A Node that make experion (gameObject) Attack the Hero with an fire laser
    /// </summary>
    public class ExperionFireAttack : GONode
    {
        private Experion experion;

        /// <summary>
        /// ExperionFireAttack Node Constructor
        /// </summary>
        /// <param name="graph">Graph containing the node</param>
        public ExperionFireAttack(Graph graph) : base(graph)
        {
            experion = gameObject.GetComponent<Experion>();
        }

        /// <summary>
        /// Empty Constructor
        /// </summary>
        /// <returns></returns>
        public ExperionFireAttack() : base()
        {
            experion = gameObject.GetComponent<Experion>();
        }

        /// <summary>
        /// Make the experion fire laser Attack
        /// </summary>
        /// <returns></returns>
        public override IEnumerator Action()
        {
            IsRunning = true;

            // Create a fire laser
            experion.FireLaser();

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
