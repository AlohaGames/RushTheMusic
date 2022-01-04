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

        public CanonBall CanonballPrefab;

        public Animator Anim;

        /// <summary>
        /// Is called on the frame when a script is enabled just before any of the Update methods are called the first time.
        /// </summary>
        void Start()
        {
            Anim = GetComponent<Animator>();
            StartCoroutine(WaitForAttackAvailable());
        }

        /// <summary>
        /// Is called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        void Update()
        {
            // Kill the chest if it goes behing the player
            if (transform.position.z < 0)
            {
                Destroy(this.gameObject);
            }
        }

        /// <summary>
        /// Bump the entity in a specific direction and with a speed
        /// <example> Example(s):
        /// <code>
        ///     StartCoroutine(wall.GetBump(new Vector3(0, 0, 2), 2));
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="direction">The direction of enemy bumping</param>
        /// <param name="speed">The speed of enemy bumping</param>
        public override IEnumerator GetBump(Vector3 direction, float speed = 0)
        {
            yield return null;
        }

        /// <summary>
        /// Instance and launch a fireball
        /// <example> Example(s):
        /// <code>
        ///     canon.Fire()
        /// </code>
        /// </example>
        /// </summary>
        public void Fire()
        {
            Anim.SetTrigger("isAttacking");

            // Config canonball's spawning position
            Vector3 canonballPos = transform.position;
            canonballPos.z -= 0.5f;

            // Spawn canonball
            CanonBall canonball = Instantiate(CanonballPrefab, canonballPos, Quaternion.identity);
            canonball.AssociatedEnemy = this;

            // Launch canonball to the hero
            canonball.Launch(Hero.transform.position);

            StartCoroutine(WaitForAttackAvailable());
        }

        private IEnumerator WaitForAttackAvailable()
        {
            yield return new WaitForSeconds(Utils.RandomFloat(2, 4));
            AttackAvailableEvent.Invoke();
        }

    }
}
