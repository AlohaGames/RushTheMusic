using System.Collections;
using UnityEngine;
using Aloha.EntityStats;

namespace Aloha
{
    /// <summary>
    /// Class for the default wyrmling
    /// </summary>
    public class Wyrmling : Enemy<WyrmlingStats>
    {
        [SerializeField]
        private WyrmlingFireball fireballPrefab;

        private WyrmlingFireball fireball;

        /// <summary>
        /// Default Awake function
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            SoundEffectManager.Instance.Play(
                SoundEffectManager.Instance.Sounds.wyrmling_idle, this.gameObject, loop: true
            );
        }

        /// <summary>
        /// Get the wyrmling's fireball
        /// <example> Example(s):
        /// <code>
        /// wyrmling.GetWyrmlingFireball();
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>
        /// The wyrmling firebal as WyrmlingFireball object
        /// </returns>
        public WyrmlingFireball GetWyrmlingFireball()
        {
            return this.fireball as WyrmlingFireball;
        }

        /// <summary>
        /// Bump the ennemy
        /// <example> Example(s):
        /// <code>
        /// wyrmling.GetBump(new Vector(1.0f, 1.0f, 1.0f), 3);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="speed"></param>
        public override IEnumerator GetBump(Vector3 direction, float speed = 2)
        {
            if (this.fireball) Destroy(this.fireball.gameObject);
            yield return base.GetBump(direction, speed);
        }

        /// <summary>
        /// Override take damages function
        /// <example> Example(s):
        /// <code>
        ///     wyrmling.TakeDamage(20);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="damage"></param>
        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            SoundEffectManager.Instance.Play(
                SoundEffectManager.Instance.Sounds.wyrmling_hurt, this.gameObject
            );
        }

        /// <summary>
        /// Instantiate a fireball in front of the wyrmling
        /// <example> Example(s):
        /// <code>
        ///     this.InstantiateFireball()
        /// </code>
        /// </example>
        /// </summary>
        public void InstantiateFireball()
        {
            Vector3 fireballPos = transform.position;
            fireballPos.x -= 0.5f;

            // Spawn fireball
            this.fireball = Instantiate(fireballPrefab, fireballPos, Quaternion.identity);
            ContainerManager.Instance.AddToContainer(ContainerTypes.Projectile, fireball.gameObject);
            this.fireball.AssociatedEnemy = this;
        }

        /// <summary>
        /// Launch the associated fireball on the hero
        /// <example> Example(s):
        /// <code>
        ///     this.LaunchFireball(3)
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="fireballSpeed"></param>
        public void LaunchFireball(float fireballSpeed)
        {
            if (this.fireball)
            {
                Vector3 dir = this.Hero.transform.position - this.fireball.transform.position;
                dir.Normalize();
                this.fireball.GetComponent<Rigidbody>().AddForce(dir * fireballSpeed, ForceMode.Impulse);
                this.fireball = null;
            }
        }

    }
}
