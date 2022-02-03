using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha.AI
{
    /// <summary>
    /// Node that move experion to the left or the right in a curve movement
    /// </summary>
    public class ExperionMove : GONode
    {
        private int maxX = 3;
        private Experion experion;
        public bool IsLeft = false;
        public bool Teleport = false;
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
            experion = gameObject.GetComponent<Experion>();
        }

        /// <summary>
        /// Move Node constructor
        /// </summary>
        /// <param name="graph">Graph containing the node</param>
        public ExperionMove(Graph graph) : base(graph)
        {
            initialY = gameObject.transform.position.y;
            experion = gameObject.GetComponent<Experion>();
        }

        /// <summary>
        /// Move the wyrmling Left or Right
        /// </summary>
        public override IEnumerator Action()
        {
            IsRunning = true;

            if (!Teleport)
            {
                // Init variables
                float time = 0;
                Vector3 posInit = gameObject.transform.position;
                Vector3 posFinal = posInit;
                posFinal.x = IsLeft ? (posFinal.x + DistToMove).Clamp(-2.5f, 2.5f) : (posFinal.x - DistToMove).Clamp(-2.5f, 2.5f);

                // Change the rotation of experion according to its direction
                if (IsLeft)
                {
                    gameObject.GetComponentsInChildren<SpriteRenderer>()[0].flipX = true;
                }
                else
                {
                    gameObject.GetComponentsInChildren<SpriteRenderer>()[0].flipX = false;
                }

                // Move the experion
                while (time < ActionTime)
                {
                    time += Speed * Time.deltaTime;

                    Vector3 tmpPos = Vector3.Lerp(posInit, posFinal, time / ActionTime);
                    tmpPos.y = initialY + Mathf.Sin(Mathf.PI * gameObject.transform.position.x) * 0.1f;
                    gameObject.transform.position = tmpPos;

                    yield return null;
                }
                gameObject.transform.position = posFinal;
            }
            else // Teleportation
            {
                experion.Anim.ResetTrigger("TeleportBack");
                experion.Anim.SetTrigger("Teleport");
                yield return new WaitForSeconds(0.5f);

                Vector3 newPosition = experion.transform.position;
                while (newPosition.x == experion.transform.position.x)
                {
                    newPosition.x = Utils.RandomInt(-maxX, maxX);
                }

                gameObject.transform.Translate(-(newPosition - experion.transform.position));

                experion.Anim.ResetTrigger("Teleport");
                experion.Anim.SetTrigger("TeleportBack");
                yield return new WaitForSeconds(0.5f);

                experion.Anim.ResetTrigger("TeleportBack");
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
