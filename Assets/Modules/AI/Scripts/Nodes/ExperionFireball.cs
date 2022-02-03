using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha;

namespace Aloha.AI
{
    /// <summary>
    /// A Node that make experion (gameObject) Attack the Hero
    /// </summary>
    public class ExperionFireball : GONode
    {
        private Experion experion;
        public bool IsIce = false;
        public float ActionTime = 1f;
        public float Speed = 4.0f;
        public float DistToMove = 0.5f;

        /// <summary>
        /// ExperionFireball Node Constructor
        /// </summary>
        /// <param name="graph">Graph containing the node</param>
        public ExperionFireball(Graph graph) : base(graph)
        {
            experion = gameObject.GetComponent<Experion>();
        }

        /// <summary>
        /// Empty Constructor
        /// </summary>
        /// <returns></returns>
        public ExperionFireball() : base()
        {
            experion = gameObject.GetComponent<Experion>();
        }

        /// <summary>
        /// Make the experion Attack
        /// </summary>
        /// <returns></returns>
        public override IEnumerator Action()
        {
            IsRunning = true;

            if (IsIce)
            {
                // Create an iceball
                experion.InstantiateIceball();
            } else
            {
                // Create a fireball
                experion.InstantiateFireball();
            }

            // Wait to charge the fireball
            yield return new WaitForSeconds(1f);

            // Launch the fireball on the hero
            experion.LaunchFireball(6);

            yield return null;

            if (!AutomaticLinks.IsEmpty())
            {
                TryAllLink();
            }
            IsRunning = false;
        }
    }
}
