using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Aloha.EntityStats;
using Aloha.Events;

namespace Aloha
{
    /// <summary>
    /// Class for experion
    /// </summary>
    public class Experion : Enemy<ExperionStats>
    {
        [SerializeField]
        private ExperionFireball fireballPrefab;

        [SerializeField]
        private ExperionFireball iceballPrefab;

        private ExperionFireball fireball;
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

        /// <summary>
        /// Default Awake function
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            SoundEffectManager.Instance.Play(
                SoundEffectManager.Instance.Sounds.experion_idle, this.gameObject, loop: true
            );
        }

        /// <summary>
        /// Function for experion to take damage
        /// </summary>
        /// <param name="damage"></param>
        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
            OnHealthUpdate.Invoke(this.CurrentHealth, this.GetStats().MaxHealth);
            if (this.CurrentHealth > 0)
            {
                SoundEffectManager.Instance.Play(
                    SoundEffectManager.Instance.Sounds.experion_hurt, this.gameObject
                );
            } else
            {
                SoundEffectManager.Instance.Play(
                    SoundEffectManager.Instance.Sounds.experion_dying, this.gameObject
                );
            }
        }

        /// <summary>
        /// Function to bump the lancer
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="speed"></param>
        public override IEnumerator GetBump(Vector3 direction, float speed = 2)
        {
            ReleaseAttack();
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

            SoundEffectManager.Instance.Play(
                SoundEffectManager.Instance.Sounds.experion_ice_laser, this.laserBeam.gameObject, 0.8f, true
            );
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

            SoundEffectManager.Instance.Play(
                SoundEffectManager.Instance.Sounds.experion_fire_laser, this.laserBeam.gameObject, 0.8f, true
            );
        }

        /// <summary>
        /// Instantiate a fireball in front of experion
        /// <example> Example(s):
        /// <code>
        ///     this.InstantiateFireball()
        /// </code>
        /// </example>
        /// </summary>
        public void InstantiateFireball()
        {
            Vector3 fireballPos = transform.position;
            fireballPos.x += gameObject.GetComponentsInChildren<SpriteRenderer>()[0].flipX ? -0.75f : 0.75f;
            fireballPos.y += 1.1f;

            // Spawn fireball
            this.fireball = Instantiate(fireballPrefab, fireballPos, Quaternion.identity);
            ContainerManager.Instance.AddToContainer(ContainerTypes.Projectile, fireball.gameObject);
            this.fireball.AssociatedEnemy = this;
        }

        /// <summary>
        /// Instantiate an iceball in front of experion
        /// <example> Example(s):
        /// <code>
        ///     this.InstantiateFireball()
        /// </code>
        /// </example>
        /// </summary>
        public void InstantiateIceball()
        {
            Vector3 fireballPos = transform.position;
            fireballPos.x += gameObject.GetComponentsInChildren<SpriteRenderer>()[0].flipX ? 1.2f : -1.2f;
            fireballPos.y += 0.15f;

            // Spawn fireball
            this.fireball = Instantiate(iceballPrefab, fireballPos, Quaternion.identity);
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
                Vector3 dir = Hero.transform.position - this.fireball.transform.position;
                dir.Normalize();
                this.fireball.GetComponent<Rigidbody>().AddForce(dir * fireballSpeed, ForceMode.Impulse);
                this.fireball = null;
            }
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
            if (this.fireball != null)
            {
                Destroy(this.fireball.gameObject);
            }
            IsAttacking = false;
            Anim.SetBool("isIceAttacking", false);
            Anim.SetBool("isFireAttacking", false);
            Anim.SetBool("isDashing", false);
            Anim.ResetTrigger("Teleport");
            Anim.ResetTrigger("TeleportBack");
        }

        override public void Die()
        {
            this.Anim.SetTrigger("Dying");
            GameManager.Instance.VictoryWithDelay(2);
            base.Die();
        }
    }
}
