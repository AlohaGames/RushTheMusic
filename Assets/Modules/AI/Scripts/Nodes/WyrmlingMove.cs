using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha.AI
{
    /// <summary>
    /// Node that move the wyrmling to the left or the right in a curve movement
    /// </summary>
    public class WyrmlingMove : GONode
    {
        public bool IsLeft = false;
        public float ActionTime = 1.0f;
        public float Speed = 2.0f;
        public float DistToMove = 0.5f;
        public float initialY;

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public WyrmlingMove() : base()
        {
            initialY = gameObject.transform.position.y;
        }

        /// <summary>
        /// Move Node constructor
        /// </summary>
        /// <param name="graph">Graph containing the node</param>
        public WyrmlingMove(Graph graph) : base(graph)
        {
            initialY = gameObject.transform.position.y;
        }

        /// <summary>
        /// Move the wyrmling Left or Right
        /// </summary>
        public override IEnumerator Action()
        {
            IsRunning = true;

            // Init variables
            float time = 0;
            Vector3 posInit = gameObject.transform.position;
            Vector3 posFinal = posInit;
            posFinal.x = IsLeft ? posFinal.x + DistToMove : posFinal.x - DistToMove;

            // Change the rotation of the wyrmling according to its direction
            if (IsLeft)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }

            // Move the wyrmling
            while (time < ActionTime)
            {
                time += Speed * Time.deltaTime;
                posFinal.y = initialY + Mathf.Sin(Mathf.PI * gameObject.transform.position.x) * 0.1f;
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
