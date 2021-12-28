using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Aloha.EntityStats;

namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    public class Canon : Enemy<CanonStats>
    {
        public Hero hero;
        [SerializeField]
        private CanonBall canonballPrefab;

        private float initialY;

        /// <summary>
        /// Is called on the frame when a script is enabled just before any of the Update methods are called the first time.
        /// </summary>
        void Start()
        {
            initialY = transform.position.y;
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>
        /// TODO
        /// </returns>
        protected override IEnumerator AI()
        {
            while (true)
            {
                yield return new WaitForSeconds(2f);
                yield return StartCoroutine(AttackAnimation());
            }
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>
        /// TODO
        /// </returns>
        protected IEnumerator AttackAnimation()
        {
            // Config canonball's spawning position
            Vector3 canonballPos = transform.position;
            canonballPos.z -= 0.5f;

            // Spawn canonball
            CanonBall canonball = Instantiate(canonballPrefab, canonballPos, Quaternion.identity);
            canonball.AssociatedEnemy = this;
            yield return new WaitForSeconds(1f);

            // Launch canonball to the hero
            // TODO  CHANGE THIS
            // Hero hero = GameManager.Instance.GetHero();
            Vector3 dir = hero.transform.position - canonball.transform.position;
            dir.Normalize();
            canonball.GetComponent<Rigidbody>().AddForce(dir * 3, ForceMode.Impulse);

            yield return null;
        }

    }
}
