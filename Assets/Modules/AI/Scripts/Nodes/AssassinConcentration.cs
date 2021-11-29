using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha;

namespace Aloha.AI
{
    /// <summary>
    /// A Node that make the Lancer (gameObject) Attack the Hero
    /// </summary>
    public class AssassinConcentration: GONode
    {
        public float actionTime = 1f;
        public float speed = 4.0f;
        public float distToMove = 0.5f;

        private Assassin assassin;

        /// <summary>
        /// AssassinAttack Node Constructor
        /// </summary>
        /// <param name="graph">Graph containing the node</param>
        public AssassinConcentration(Graph graph) : base(graph)
        {
            assassin = gameObject.GetComponent<Assassin>();
        }

        /// <summary>
        /// Empty Constructor
        /// </summary>
        /// <returns></returns>
        public AssassinConcentration() : base()
        {
            assassin = gameObject.GetComponent<Assassin>();
        }

        /// <summary>
        /// Make the lancer Attack
        /// </summary>
        /// <returns></returns>
        public override IEnumerator Action()
        {
            IsRunning = true;
            assassin.anim.SetBool("isAttacking", true);

            yield return new WaitForSeconds(0.8f);
            float temps = 0;
            Vector3 posInit = gameObject.transform.position;
            Vector3 posFinal = posInit;
            posFinal.z = posFinal.z - 2.2f;

            ///TODO: maybe remove Debug
            Debug.Log(posInit);
            Debug.Log(posFinal);

            while (temps < 1f)
            {
                temps += speed * Time.deltaTime;
                gameObject.transform.position = Vector3.Lerp(posInit, posFinal, temps);
                yield return null;
            }
            gameObject.transform.position = posFinal;
            yield return new WaitForSeconds(0.15f);

            if (!AutomaticLinks.IsEmpty())
            {
                TryAllLink();
            }
            IsRunning = false;
        }
    }
}
