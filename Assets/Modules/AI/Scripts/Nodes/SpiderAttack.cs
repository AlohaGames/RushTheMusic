using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha;

namespace Aloha.AI
{
    /// <summary>
    /// A Node that make the Spider (gameObject) Attack the Hero
    /// </summary>
    public class SpiderAttack : GONode
    {
        private Spider spider;
        public float Speed = 4.0f;

        /// <summary>
        /// SpiderAttack Node Constructor
        /// </summary>
        /// <param name="graph">Graph containing the node</param>
        public SpiderAttack(Graph graph) : base(graph)
        {
            spider = gameObject.GetComponent<Spider>();
        }

        /// <summary>
        /// Empty Constructor
        /// </summary>
        /// <returns></returns>
        public SpiderAttack() : base()
        {
            IsRunning = true;
            spider = gameObject.GetComponent<Spider>();
        }

        /// <summary>
        /// Make the lspider Attack
        /// </summary>
        /// <returns></returns>
        public override IEnumerator Action()
        {
            //spider.Anim.SetBool("isAttacking", true);

            Vector3 posFinal = gameObject.transform.position;

            //Front bump for a minecraft attack spider base
            yield return spider.GetBump(new Vector3(0, 0, -1f), 3f);
            spider.Attack(spider.Hero);

            Vector3 posInit = gameObject.transform.position;
            float temps = 0;

            while (temps < 1f)  
            {
                temps += Speed * Time.deltaTime;
                gameObject.transform.position = Vector3.Lerp(posInit, posFinal, temps);
                yield return null;
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
