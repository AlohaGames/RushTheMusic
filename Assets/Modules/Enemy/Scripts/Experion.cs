using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Aloha.EntityStats;
using Aloha.Events;

namespace Aloha
{
    /// <summary>
    /// Class for the default lancer
    /// </summary>
    public class Experion : Enemy<ExperionStats>
    {
        private ExperionLaser laserBeam;

        [Header("Lasers Prefabs")]
        [SerializeField]
        private ExperionLaser iceLaserPrefab;

        [SerializeField]
        private ExperionLaser fireLaserPrefab;

        public Animator Anim;
        public IntIntEvent OnHealthUpdate = new IntIntEvent();

        [HideInInspector]
        public bool IsAttacking;


        /// <summary>
        /// Is called on the frame when a script is enabled just before any of the Update methods are called the first time.
        /// </summary>
        void Start()
        {
            IsAttacking = false;
            OnHealthUpdate.Invoke(this.CurrentHealth, this.GetStats().MaxHealth);
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            OnHealthUpdate.Invoke(this.CurrentHealth, this.GetStats().MaxHealth);
        }

        /// <summary>
        /// Function to bump the lancer
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="speed"></param>
        public override IEnumerator GetBump(Vector3 direction, float speed = 2)
        {
            //Anim.SetBool("isAttacking", false);
            yield return base.GetBump(direction, speed);
        }

        /// <summary>
        /// Throw an ice laser on the hero
        /// <example> Example(s):
        /// <code>
        ///     experion.IceLaser();
        /// </code>
        /// </example>
        /// </summary>
        public void IceLaser()
        {
            Debug.Log("Experion > IceLaser()");
            IsAttacking = true;
            Anim.SetBool("isIceAttacking", true);
            Vector3 initial = transform.position;
            initial.x += gameObject.GetComponentsInChildren<SpriteRenderer>()[0].flipX ? 1.2f : -1.2f;
            initial.y += 0.15f;
            Vector3 target = new Vector3(0.0f, 1.0f, 0.0f);

            this.laserBeam = Instantiate(iceLaserPrefab, initial, Quaternion.identity);
            ContainerManager.Instance.AddToContainer(ContainerTypes.Projectile, laserBeam.gameObject);
            laserBeam.ThrowLaser(initial, target, 15.0f, 2.0f, 0.8f);
            laserBeam.AssociatedEnemy = this;
        }

        /// <summary>
        /// Throw an fire laser on the hero
        /// <example> Example(s):
        /// <code>
        ///     experion.FireLaser();
        /// </code>
        /// </example>
        /// </summary>
        public void FireLaser()
        {
            Debug.Log("Experion > FireLaser()");
            IsAttacking = true;
            Anim.SetBool("isFireAttacking", true);
            Vector3 initial = transform.position;
            initial.x += gameObject.GetComponentsInChildren<SpriteRenderer>()[0].flipX ? -0.75f : 0.75f;
            initial.y += 1.1f;
            Vector3 target = new Vector3(0.0f, 1.0f, 0.0f);

            this.laserBeam = Instantiate(fireLaserPrefab, initial, Quaternion.identity);
            ContainerManager.Instance.AddToContainer(ContainerTypes.Projectile, laserBeam.gameObject);
            laserBeam.ThrowLaser(initial, target, 15.0f, 2.0f, 0.8f);
            laserBeam.AssociatedEnemy = this;

        }

        /// <summary>
        /// Release everything when release attack
        /// <example> Example(s):
        /// <code>
        ///     darkWizard.ReleaseAttack();
        /// </code>
        /// </example>
        /// </summary>
        public void ReleaseAttack()
        {
            if (laserBeam != null)
            {
                Destroy(laserBeam.gameObject);
            }
            IsAttacking = false;
            Anim.SetBool("isIceAttacking", false);
            Anim.SetBool("isFireAttacking", false);
        }
    }
}
