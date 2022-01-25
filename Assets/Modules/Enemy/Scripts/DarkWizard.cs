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
        [Header("Lasers Prefabs")]
        [SerializeField]
        private Laser iceLaserPrefab;

        [SerializeField]
        private Laser fireLaserPrefab;

        [HideInInspector]
        public Animator Anim;

        /// <summary>
        /// Is called on the frame when a script is enabled just before any of the Update methods are called the first time.
        /// </summary>
        void Start()
        {
            Anim = GetComponent<Animator>();

            /*iceLaserPreview = new GameObject().AddComponent<LineRenderer>();
            //iceLaserPreview.material = raycastMaterial;
            iceLaserPreview.startWidth = 0.02f;
            iceLaserPreview.endWidth = 0.02f;

            //    |
            //    |
            //   \|/
            //    '   Le problème est là wesh
            fireLaserPreview = this.gameObject.AddComponent<LineRenderer>();
            //fireLaserPreview.material = raycastMaterial;
            fireLaserPreview.startWidth = 0.02f;
            fireLaserPreview.endWidth = 0.02f;*/

        }

        /// <summary>
        /// Function to bump the lancer
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="speed"></param>
        public override IEnumerator GetBump(Vector3 direction, float speed = 2)
        {
            Anim.SetBool("isIceAttacking", false);
            Anim.SetBool("isFireAttacking", false);
            IceLaser();
            //FireLaser();
            yield return base.GetBump(direction, speed);
        }

        public void IceLaser()
        {
            //iceLaserPreview.enabled = true;

            //Vector3 initial = transform.position;
            //initial.x -= 0.5f;
            /*iceLaserPreview.SetPosition(0, initial);

            Vector3 target = new Vector3(0.0f, 1.0f, 0.0f);
            iceLaserPreview.SetPosition(1, target);*/

            Vector3 initial = transform.position;
            initial.x -= 0.5f;
            Vector3 target = new Vector3(0.0f, 1.0f, 0.0f);
            Debug.Log(initial);

            Laser iceLaser = Instantiate(iceLaserPrefab, initial, Quaternion.identity);

            //this.fireball = Instantiate(fireballPrefab, fireballPos, Quaternion.identity);
            ContainerManager.Instance.AddToContainer(ContainerTypes.Projectile, iceLaser.gameObject);

            //iceLaser.ThrowLaser(initial, target, 2, 4);

            //iceLaser.ThrowLaser(new Vector3(0, 1, 4.4f), new Vector3(0, 1, 0), 4f, 3);
            iceLaser.ThrowLaser(new Vector3(0, 1, 4.4f), new Vector3(0, 1, 0), 4f, 3);

            //iceLaserPreview.enabled = false;
        }

        public void FireLaser()
        {
            /*fireLaserPreview.enabled = true;

            Vector3 initial = transform.position;
            initial.x += 0.5f;
            fireLaserPreview.SetPosition(0, initial);

            Vector3 target = new Vector3(0.0f, 1.0f, 0.0f);
            fireLaserPreview.SetPosition(1, target);*/

            Vector3 initial = transform.position;
            initial.x += 0.5f;
            Vector3 target = new Vector3(0.0f, 1.0f, 0.0f);

            Laser fireLaser = Instantiate(fireLaserPrefab, initial, new Quaternion());
            fireLaser.ThrowLaser(initial, target, 2, 4);



            //iceLaserPreview.enabled = false;
        }
    }
}
