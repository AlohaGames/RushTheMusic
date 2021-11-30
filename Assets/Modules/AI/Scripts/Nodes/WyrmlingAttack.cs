using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha;

namespace Aloha.AI
{
    /// <summary>
    /// A Node that make the Lancer (gameObject) Attack the Hero
    /// </summary>
    public class WyrmlingAttack : GONode
    {
        private Wyrmling wyrmling;
        public bool IsLeft = false;
        public float ActionTime = 1f;
        public float Speed = 4.0f;
        public float DistToMove = 0.5f;

        /// <summary>
        /// LancerAttack Node Constructor
        /// </summary>
        /// <param name="graph">Graph containing the node</param>
        public WyrmlingAttack(Graph graph) : base(graph)
        {
            wyrmling = gameObject.GetComponent<Wyrmling>();
        }

        /// <summary>
        /// Empty Constructor
        /// </summary>
        /// <returns></returns>
        public WyrmlingAttack() : base()
        {
            wyrmling = gameObject.GetComponent<Wyrmling>();
        }

        /// <summary>
        /// Make the wyrmling Attack
        /// </summary>
        /// <returns></returns>
        public override IEnumerator Action()
        {
            IsRunning = true;

            // Create a fireball
            wyrmling.InstantiateFireball();

            // Wait to charge the fireball
            yield return new WaitForSeconds(1f);

            // Launch the fireball on the hero
            wyrmling.LaunchFireball(3);

            yield return null;

            if (!AutomaticLinks.IsEmpty())
            {
                TryAllLink();
            }
            IsRunning = false;
        }
    }
}
