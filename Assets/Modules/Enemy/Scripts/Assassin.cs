using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Aloha.EntityStats;

namespace Aloha
{
    /// <summary>
    /// Class that manage utils functions
    /// </summary>
    public class Assassin : Enemy<AssassinStats> 
    {
        private Hero hero;
        private Animator anim;

        /// <summary>
        /// Is called on the frame when a script is enabled just before any of the Update methods are called the first time.
        /// </summary>
        void Start()
        {
            hero = GameManager.Instance.GetHero();
            anim = GetComponent<Animator>();
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
        protected override IEnumerator AI()
        {
            yield return StartCoroutine(Concentration(15f));
            yield return StartCoroutine(StealthJump(2f));
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="speed"></param>
        protected IEnumerator StealthJump(float speed)
        {

            float temps = 0;
            Vector3 posInit = gameObject.transform.position;
            Vector3 posFinal = posInit * speed;

            while (temps < 1f)
            {
                temps += speed * Time.deltaTime;
                posFinal.y = posInit.y + 15;
                posFinal.z = posInit.z - 7;
                gameObject.transform.position = Vector3.Lerp(posInit, posFinal, temps);
                yield return null;
            }
            gameObject.transform.position = posFinal;
            Hero hero = GameManager.Instance.GetHero();
            Attack(hero);
            Disappear();
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="speed"></param>
        protected IEnumerator Concentration(float speed)
        {
            anim.SetBool("isAttacking", true);

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
        }
    }
}
