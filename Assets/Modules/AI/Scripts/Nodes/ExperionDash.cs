using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha;

namespace Aloha.AI
{
    /// <summary>
    /// A Node that make the experion (gameObject) Attack the Hero
    /// </summary>
    public class ExperionDash : GONode
    {
        private Experion experion;
        public float ActionTime = 1f;
        public float Speed = 8.0f;
        public float DistToMove = 0.5f;

        /// <summary>
        /// ExperionDash Node Constructor
        /// </summary>
        /// <param name="graph">Graph containing the node</param>
        public ExperionDash(Graph graph) : base(graph)
        {
            experion = gameObject.GetComponent<Experion>();
        }

        /// <summary>
        /// Empty Constructor
        /// </summary>
        /// <returns></returns>
        public ExperionDash() : base()
        {
            experion = gameObject.GetComponent<Experion>();
        }

        /// <summary>
        /// Make the lancer Attack
        /// </summary>
        /// <returns></returns>
        public override IEnumerator Action()
        {
            IsRunning = true;

            experion.Anim.SetBool("isDashing", true);

            Vector3 firstPos = gameObject.transform.position;
            yield return experion.GetBump(new Vector3(0, 0, 0.5f), 2f);
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

            SoundEffectManager.Instance.Play(
                SoundEffectManager.Instance.Sounds.experion_dash, this.gameObject
            );

            experion.Attack(experion.Hero);
            experion.Anim.SetBool("isDashing", false);

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
