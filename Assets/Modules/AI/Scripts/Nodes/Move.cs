using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha.AI
{
    /// <summary>
    /// Node that move the gameObject to the left or the right
    /// </summary>
    public class Move : GONode
    {
        public bool IsLeft = false;
        public float ActionTime = 1.0f;
        public float Speed = 2.0f;
        public float DistToMove = 0.5f;

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public Move() : base() { }

        /// <summary>
        /// Move Node constructor
        /// </summary>
        /// <param name="graph">Graph containing the node</param>
        public Move(Graph graph) : base(graph) { }

        /// <summary>
        /// Move the gameObject Left or Right
        /// </summary>
        public override IEnumerator Action()
        {
            IsRunning = true;

            float time = 0;
            Vector3 posInit = gameObject.transform.position;
            Vector3 posFinal = posInit;
            posFinal.x = IsLeft ? posFinal.x + DistToMove : posFinal.x - DistToMove;

            while (time < ActionTime)
            {
                time += Speed * Time.deltaTime;
                gameObject.transform.position = Vector3.Lerp(posInit, posFinal, time / ActionTime);
                yield return null;
            }

            gameObject.transform.position = posFinal;

            yield return null;
            if (!AutomaticLinks.IsEmpty())
            {
                TryAllLink();
            }
            IsRunning = false;
        }
    }
}
