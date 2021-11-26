using System.Collections;
using UnityEngine;
using Aloha.EntityStats;

namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    public class Wyrmling : Enemy<WyrmlingStats>
    {
        [SerializeField]
        private WyrmlingFireball fireballPrefab;

        private WyrmlingFireball fireball;

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// TODO
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
                Hero hero = GameManager.Instance.GetHero();
                Vector3 dir = hero.transform.position - this.fireball.transform.position;
                dir.Normalize();
                this.fireball.GetComponent<Rigidbody>().AddForce(dir * fireballSpeed, ForceMode.Impulse);
            }
        }

    }
}
