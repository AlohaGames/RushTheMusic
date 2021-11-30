using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha;

namespace Aloha.AI
{
    /// <summary>
    /// A Node that make the Lancer (gameObject) Attack the Hero
    /// </summary>
    public class AssassinAttack : GONode
    {
        private Assassin assassin;
        public float ActionTime = 1f;
        public float Speed = 4.0f;
        public float DistToMove = 0.5f;

        /// <summary>
        /// AssassinAttack Node Constructor
        /// </summary>
        /// <param name="graph">Graph containing the node</param>
        public AssassinAttack(Graph graph) : base(graph)
        {
            this.assassin = gameObject.GetComponent<Assassin>();
        }

        /// <summary>
        /// Empty Constructor
        /// </summary>
        /// <returns></returns>
        public AssassinAttack() : base()
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

            float time = 0;
            Vector3 posInit = gameObject.transform.position;
            Vector3 posFinal = posInit * Speed;

            while (time < 1f)
            {
                time += Speed * Time.deltaTime;
                posFinal.y = posInit.y + 15;
                posFinal.z = posInit.z - 7;
                gameObject.transform.position = Vector3.Lerp(posInit, posFinal, time);
                yield return null;
            }
            gameObject.transform.position = posFinal;
            Hero hero = GameManager.Instance.GetHero();
            assassin.Attack(hero);
            assassin.Disappear();

            yield return null;

            if (!AutomaticLinks.IsEmpty())
            {
                TryAllLink();
            }
            IsRunning = false;
        }
    }
}
