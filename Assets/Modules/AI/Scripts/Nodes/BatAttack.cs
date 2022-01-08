using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha;

namespace Aloha.AI
{
    /// <summary>
    /// A Node that make the Bat (gameObject) Attack the Hero
    /// </summary>
    public class BatAttack : GONode
    {
        private Bat bat;
        public float ActionTime = 1f;
        public float Speed = 4.0f;
        public float DistToMove = 0.5f;

        /// <summary>
        /// BatAttack Node Constructor
        /// </summary>
        /// <param name="graph">Graph containing the node</param>
        public BatAttack(Graph graph) : base(graph)
        {
            bat = gameObject.GetComponent<Bat>();
        }

        /// <summary>
        /// Empty Constructor
        /// </summary>
        /// <returns></returns>
        public BatAttack() : base()
        {
            bat = gameObject.GetComponent<Bat>();
        }

        /// <summary>
        /// Make the bat Attack
        /// </summary>
        /// <returns></returns>
        public override IEnumerator Action()
        {
            IsRunning = true;

            bat.Anim.SetBool("isAttacking", true);

            Vector3 firstPos = gameObject.transform.position;
            yield return bat.GetBump(new Vector3(0, 0, 0.5f), 2f);
            yield return new WaitForSeconds(0.2f);

            float time = 0;
            Vector3 posInit = gameObject.transform.position;
            Vector3 posFinal = new Vector3(0, 1, 0);
            while (time < 2f)
            {
                time += Speed * Time.deltaTime;
                gameObject.transform.position = Vector3.Lerp(posInit, posFinal, time / 2);
                yield return null;
            }
            gameObject.transform.position = posFinal;

            bat.Attack(bat.Hero);
            bat.Anim.SetBool("isAttacking", false);

            time = 0;
            while (time < 2f)
            {
                time += Speed * Time.deltaTime;
                gameObject.transform.position = Vector3.Lerp(posFinal, firstPos, time / 2);
                yield return null;
            }
            gameObject.transform.position = firstPos;

            yield return null;

            if (!AutomaticLinks.IsEmpty())
            {
                TryAllLink();
            }
            IsRunning = false;
        }
    }
}
