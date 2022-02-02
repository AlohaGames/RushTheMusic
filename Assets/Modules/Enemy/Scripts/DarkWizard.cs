using System.Collections;
using UnityEngine;
using Aloha.EntityStats;

namespace Aloha
{
    /// <summary>
    /// Class for the dark wizard
    /// </summary>
    public class DarkWizard : Enemy<DarkWizardStats>
    {
        private Laser laserBeam;

        [Header("Lasers Prefabs")]
        [SerializeField]
        private Laser iceLaserPrefab;

        [SerializeField]
        private Laser fireLaserPrefab;

        [HideInInspector]
        public Animator Anim;
        
        [HideInInspector]
        public bool IsAttacking;

        /// <summary>
        /// Is called on the frame when a script is enabled just before any of the Update methods are called the first time.
        /// </summary>
        void Start()
        {
            Anim = GetComponent<Animator>();
            IsAttacking = false;
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
        ///     darkWizard.IceLaser();
        /// </code>
        /// </example>
        /// </summary>
        public void IceLaser()
        {
            IsAttacking = true;
            Anim.SetBool("isIceAttacking", true);
            Vector3 initial = transform.position;
            initial.x -= 0.85f;
            initial.y -= 0.5f;
            Vector3 target = new Vector3(0.0f, 1.0f, 0.0f);

            this.laserBeam = Instantiate(iceLaserPrefab, initial, Quaternion.identity);
            ContainerManager.Instance.AddToContainer(ContainerTypes.Projectile, laserBeam.gameObject);
            laserBeam.ThrowLaser(initial, target, 15.0f, 2.0f, 0.8f);
            laserBeam.AssociatedEnemy = this;

            SoundEffectManager.Instance.Play(
                SoundEffectManager.Instance.Sounds.dark_wizard_ice_laser, this.laserBeam.gameObject, 0.8f, true
            );
        }

        /// <summary>
        /// Throw an fire laser on the hero
        /// <example> Example(s):
        /// <code>
        ///     darkWizard.FireLaser();
        /// </code>
        /// </example>
        /// </summary>
        public void FireLaser()
        {
            IsAttacking = true;
            Anim.SetBool("isFireAttacking", true);
            Vector3 initial = transform.position;
            initial.x += 0.75f;
            initial.y -= 0.5f;
            Vector3 target = new Vector3(0.0f, 1.0f, 0.0f);

            this.laserBeam = Instantiate(fireLaserPrefab, initial, Quaternion.identity);
            ContainerManager.Instance.AddToContainer(ContainerTypes.Projectile, laserBeam.gameObject);
            laserBeam.ThrowLaser(initial, target, 15.0f, 2.0f, 0.8f);
            laserBeam.AssociatedEnemy = this;

            SoundEffectManager.Instance.Play(
                SoundEffectManager.Instance.Sounds.dark_wizard_fire_laser, this.laserBeam.gameObject, 0.8f, true
            );
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
