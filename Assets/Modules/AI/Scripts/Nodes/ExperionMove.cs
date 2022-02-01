using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha.AI
{
    /// <summary>
    /// Node that move the wyrmling to the left or the right in a curve movement
    /// </summary>
    public class ExperionMove : GONode
    {
        public bool IsLeft = false;
        public float ActionTime = 1.0f;
        public float Speed = 2.0f;
        public float DistToMove = 0.5f;
        public float initialY;

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public ExperionMove() : base()
        {
            initialY = gameObject.transform.position.y;
        }

        /// <summary>
        /// Move Node constructor
        /// </summary>
        /// <param name="graph">Graph containing the node</param>
        public ExperionMove(Graph graph) : base(graph)
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
            posFinal.x = IsLeft ? (posFinal.x + DistToMove).Clamp(-2.5f, 2.5f) : (posFinal.x - DistToMove).Clamp(-2.5f, 2.5f);

            // Change the rotation of the wyrmling according to its direction
            if (IsLeft)
            {
                gameObject.GetComponentsInChildren<SpriteRenderer>()[0].flipX = true;
            }
            else
            {
                gameObject.GetComponentsInChildren<SpriteRenderer>()[0].flipX = false;
            }

            // Move the wyrmling
            while (time < ActionTime)
            {
                time += Speed * Time.deltaTime;

                Vector3 tmpPos = Vector3.Lerp(posInit, posFinal, time / ActionTime);
                tmpPos.y = initialY + Mathf.Sin(Mathf.PI * gameObject.transform.position.x) * 0.1f;
                gameObject.transform.position = tmpPos;

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
