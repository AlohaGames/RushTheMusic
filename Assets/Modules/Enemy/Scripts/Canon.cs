using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Aloha.EntityStats;

namespace Aloha
{
    /// <summary>
    /// Class of a canon
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

            // Charge a canonball
            StartCoroutine(WaitForAttackAvailable());
        }

        void Awake()
        {
            SoundEffectManager.Instance.Play(
                SoundEffectManager.Instance.Sounds.canon_idle, this.gameObject, loop: true
            );
        }

        /// <summary>
        /// Is called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        void Update()
        {
            // Kill the canon if it goes behing the player
            if (transform.position.z < 0)
            {
                Destroy(this.gameObject);
            }
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            SoundEffectManager.Instance.Play(
                SoundEffectManager.Instance.Sounds.canon_hurt, this.gameObject
            );
        }

        /// <summary>
        /// Bump the entity in a specific direction and with a speed
        /// In this case, the canon never moves
        /// <example> Example(s):
        /// <code>
        ///     StartCoroutine(canon.GetBump(new Vector3(0, 0, 2), 2));
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
        /// Instance and launch a canonball
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
            ContainerManager.Instance.AddToContainer(ContainerTypes.Projectile, canonball.gameObject);

            // Launch canonball to the hero
            canonball.Launch(Hero.transform.position);

            // Charge a new canonball
            StartCoroutine(WaitForAttackAvailable());
        }

        /// <summary>
        /// Wait a random time between 2 and 4 seconds to charge a canonball
        /// <example> Example(s):
        /// <code>
        ///     StartCoroutine(WaitForAttackAvailable());
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>IEnumerator</returns>
        private IEnumerator WaitForAttackAvailable()
        {
            yield return new WaitForSeconds(Utils.RandomFloat(2, 4));
            AttackAvailableEvent.Invoke();
        }

    }
}
