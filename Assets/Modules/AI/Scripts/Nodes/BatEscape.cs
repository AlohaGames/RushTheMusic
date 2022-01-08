using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha.AI
{
    /// <summary>
    /// Node the bat uses to escape from game
    /// </summary>
    public class BatEscape : GONode
    {
        private Bat bat;
        public float ActionTime = 1.0f;
        public float Speed = 2.0f;
        public float DistToMove = 0.5f;

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public BatEscape() : base() 
        {
            bat = gameObject.GetComponent<Bat>();
        }

        /// <summary>
        /// Escape Node constructor
        /// </summary>
        /// <param name="graph">Graph containing the node</param>
        public BatEscape(Graph graph) : base(graph) 
        {
            bat = gameObject.GetComponent<Bat>();
        }

        /// <summary>
        /// Move the gameObject in every random direction
        /// </summary>
        public override IEnumerator Action()
        {
            IsRunning = true;

            float time = 0;
            Vector3 posInit = gameObject.transform.position;
            Vector3 posFinal = posInit;
            posFinal.y = posFinal.y + 10;

            while (time < ActionTime)
            {
                time += Speed * Time.deltaTime;
                gameObject.transform.position = Vector3.Lerp(posInit, posFinal, time / ActionTime);
                yield return null;
            }

            gameObject.transform.position = posFinal;

            bat.Die();

            yield return null;
            if (!AutomaticLinks.IsEmpty())
            {
                TryAllLink();
            }
            IsRunning = false;
        }
    }
}
