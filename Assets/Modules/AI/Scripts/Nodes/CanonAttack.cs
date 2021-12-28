using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha;

namespace Aloha.AI
{
    /// <summary>
    /// A Node that make the Canon (gameObject) Attack the Hero
    /// </summary>
    public class CanonAttack : GONode
    {
        private Canon canon;
        public float ActionTime = 1f;
        public float Speed = 4.0f;
        public float DistToMove = 0.5f;

        /// <summary>
        /// AssassinAttack Node Constructor
        /// </summary>
        /// <param name="graph">Graph containing the node</param>
        public CanonAttack(Graph graph) : base(graph)
        {
            this.canon = gameObject.GetComponent<Canon>();
        }

        /// <summary>
        /// Empty Constructor
        /// </summary>
        /// <returns></returns>
        public CanonAttack() : base()
        {
            canon = gameObject.GetComponent<Canon>();
        }

        /// <summary>
        /// Make the lancer Attack
        /// </summary>
        /// <returns></returns>
        public override IEnumerator Action()
        {
            IsRunning = true;

            canon.Fire();

            yield return null;

            if (!AutomaticLinks.IsEmpty())
            {
                TryAllLink();
            }
            IsRunning = false;
        }
    }
}
