using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha.AI
{
    /// <summary>
    /// Node that move the bat in every direction
    /// </summary>
    public class BatMove : GONode
    {
        public int HorizontalMove = 0; // left : -1, static : 0, right : 1
        public int VerticalMove = 0; // down : -1, static : 0, up : 1
        public float ActionTime = 1.0f;
        public float Speed = 2.0f;
        public float DistToMove = 0.5f;

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public BatMove() : base() { }

        /// <summary>
        /// Move Node constructor
        /// </summary>
        /// <param name="graph">Graph containing the node</param>
        public BatMove(Graph graph) : base(graph) { }

        /// <summary>
        /// Move the gameObject in every random direction
        /// </summary>
        public override IEnumerator Action()
        {
            IsRunning = true;

            // Set a random direction
            int randH = Utils.RandomInt(-1, 2);
            int randV = Utils.RandomInt(-1, 2);
            this.HorizontalMove = randH;
            this.VerticalMove = randV;

            // Change the rotation of the wyrmling according to its direction
            if (this.HorizontalMove == -1)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (this.HorizontalMove == 1)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }

            float time = 0;
            Vector3 posInit = gameObject.transform.position;
            Vector3 posFinal = posInit;
            posFinal.x = (posFinal.x + DistToMove * HorizontalMove).Clamp(-3, 3);
            posFinal.y = (posFinal.y + DistToMove * VerticalMove).Clamp(1, 3);

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
