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
        [HideInInspector]
        public UnityEvent AttackAvailableEvent = new UnityEvent();

        [SerializeField]
        public CanonBall canonballPrefab;


        private float initialY;

        /// <summary>
        /// Is called on the frame when a script is enabled just before any of the Update methods are called the first time.
        /// </summary>
        void Start()
        {
            initialY = transform.position.y;
            StartCoroutine(WaitForAttackAvailable());
        }

        /// <summary>
        /// Is called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        void Update()
        {
            if (transform.position.z < 0)
            {
                Destroy(this.gameObject);
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
        public void Fire()
        {
            // Config canonball's spawning position
            Vector3 canonballPos = transform.position;
            canonballPos.z -= 0.5f;

            // Spawn canonball
            CanonBall canonball = Instantiate(canonballPrefab, canonballPos, Quaternion.identity);
            canonball.AssociatedEnemy = this;

            // Launch canonball to the hero
            canonball.Launch(hero.transform.position);

            StartCoroutine(WaitForAttackAvailable());
        }

        private IEnumerator WaitForAttackAvailable()
        {
            yield return new WaitForSeconds(Utils.RandomFloat(2, 4));
            AttackAvailableEvent.Invoke();
        }

    }
}
