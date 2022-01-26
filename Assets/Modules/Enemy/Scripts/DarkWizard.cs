using System.Collections;
using UnityEngine;
using Aloha.EntityStats;

namespace Aloha
{
    /// <summary>
    /// Class for the default wyrmling
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
        
        public bool isAttacking;

        /// <summary>
        /// Is called on the frame when a script is enabled just before any of the Update methods are called the first time.
        /// </summary>
        void Start()
        {
            Anim = GetComponent<Animator>();
            isAttacking = false;
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

        public void IceLaser()
        {
            isAttacking = true;
            Anim.SetBool("isIceAttacking", true);
            Vector3 initial = transform.position;
            initial.x -= 0.85f;
            initial.y -= 0.5f;
            Vector3 target = new Vector3(0.0f, 1.0f, 0.0f);

            this.laserBeam = Instantiate(iceLaserPrefab, initial, Quaternion.identity);
            ContainerManager.Instance.AddToContainer(ContainerTypes.Projectile, laserBeam.gameObject);
            laserBeam.ThrowLaser(initial, target, 15.0f, 2.0f, 0.8f);
            laserBeam.DarkWizard = this;
        }

        public void FireLaser()
        {
            isAttacking = true;
            Anim.SetBool("isFireAttacking", true);
            Vector3 initial = transform.position;
            initial.x += 0.75f;
            initial.y -= 0.5f;
            Vector3 target = new Vector3(0.0f, 1.0f, 0.0f);

            this.laserBeam = Instantiate(fireLaserPrefab, initial, Quaternion.identity);
            ContainerManager.Instance.AddToContainer(ContainerTypes.Projectile, laserBeam.gameObject);
            laserBeam.ThrowLaser(initial, target, 15.0f, 2.0f, 0.8f);
            laserBeam.DarkWizard = this;

        }

        public void ReleaseAttack()
        {
            if (laserBeam != null)
            {
                Destroy(laserBeam.gameObject);
            }
            isAttacking = false;
            Anim.SetBool("isIceAttacking", false);
            Anim.SetBool("isFireAttacking", false);
        }
    }
}
