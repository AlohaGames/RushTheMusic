using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha;

namespace Aloha.AI
{
    /// <summary>
    /// A Node that make the Lancer (gameObject) Attack the Hero
    /// </summary>
    public class LancerAttack : GONode
    {
        public bool IsLeft = false;
        public float actionTime = 1f;
        public float speed = 4.0f;
        public float distToMove = 0.5f;

        private Lancer lancer;

        /// <summary>
        /// LancerAttack Node Constructor
        /// </summary>
        /// <param name="graph">Graph containing the node</param>
        public LancerAttack(Graph graph) : base(graph)
        {
            lancer = gameObject.GetComponent<Lancer>();
        }

        /// <summary>
        /// Empty Constructor
        /// </summary>
        /// <returns></returns>
        public LancerAttack() : base()
        {
            lancer = gameObject.GetComponent<Lancer>();
        }

        /// <summary>
        /// Make the lancer Attack
        /// </summary>
        /// <returns></returns>
        public override IEnumerator Action()
        {
            IsRunning = true;

            yield return lancer.GetBump(new Vector3(0, 0, 1f), 3f);
            yield return new WaitForSeconds(0.2f);

            float temps = 0;
            Vector3 posInit = gameObject.transform.position;
            Vector3 posFinal = posInit;
            posFinal.x = 0; posFinal.z = -1;


            while (temps < 1f)
            {
                temps += speed * Time.deltaTime;
                gameObject.transform.position = Vector3.Lerp(posInit, posFinal, temps);
                yield return null;
            }

            gameObject.transform.position = posFinal;

            Hero hero = GameManager.Instance.GetHero();
            lancer.Attack(hero);

            lancer.Disappear();

            yield return null;

            if (!AutomaticLinks.IsEmpty())
            {
                TryAllLink();
            }
            IsRunning = false;
        }
    }
}
