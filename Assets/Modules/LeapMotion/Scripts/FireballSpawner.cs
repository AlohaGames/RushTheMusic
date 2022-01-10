using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha 
{
    /// <summary>
    /// Class for the fireball spawner attached to the wizard's arm
    /// </summary>
    public class FireballSpawner : MonoBehaviour
    {
        [SerializeField]
        private Fireball fireballPrefab;

        [SerializeField]
        private Material raycastMaterial;

        private LineRenderer targetPreview;
        private Vector3 origin;
        private Vector3? endPoint;
        private Fireball currentFireball;
        public Wizard Wizard;

        /// <summary>
        /// Is called on the frame when a script is enabled just before any of the Update methods are called the first time.
        /// </summary>
        void Start()
        {
            Wizard = GameManager.Instance.GetHero() as Wizard;

            targetPreview = this.gameObject.AddComponent<LineRenderer>();
            targetPreview.material = raycastMaterial;
            targetPreview.startWidth = 0.02f;
            targetPreview.endWidth = 0.02f;
        }

        /// <summary>
        /// Update is called once per frame
        /// </summary>
        void Update()
        {
            if (this.currentFireball)
            {
                CheckLaser();
            } 
            else
            {
                // Remove the laser
                targetPreview.enabled = false;
            }
        }

        /// <summary>
        /// Spawn a new fireball in front of the spawner according to wizard mana
        /// <example> Example(s):
        /// <code>
        ///     SpawnFireball()
        /// </code>
        /// </example>
        /// </summary>
        public void SpawnFireball()
        {
            if (!this.currentFireball)
            {
                int fireballPower = Wizard.ChargeFireball();

                if (fireballPower != 0)
                {
                    // Find a position to spawn a fireball
                    Vector3 fireballPos = transform.position;
                    fireballPos += this.transform.forward * 0.1f;

                    // Instantiate a new fireball
                    Fireball fireball = Instantiate(fireballPrefab, fireballPos, transform.rotation);
                    fireball.transform.parent = transform;

                    // Define size of the fireball
                    if (fireballPower != Wizard.GetStats().Attack)
                    {
                        float size = (float) fireballPower / Wizard.GetStats().Attack;
                        Vector3 defaultScale = fireball.transform.localScale;
                        fireball.transform.localScale = new Vector3(defaultScale.x * size, defaultScale.y * size, defaultScale.z * size);
                    }

                    // Define some parameters of the fireball
                    fireball.Wizard = this.Wizard;
                    fireball.Power = fireballPower;
                    this.currentFireball = fireball;
                }
            }
        }

        /// <summary>
        /// If a fireball have a fireball linked, it send it forward
        /// <example> Example(s):
        /// <code>
        ///     SendFireball()
        /// </code>
        /// </example>
        /// </summary>
        public void SendFireball()
        {
            if (this.currentFireball)
            {
                this.currentFireball.Launch();
                this.currentFireball = null;
            }
        }

        /// <summary>
        /// Update laser to help user aim
        /// <example> Example(s):
        /// <code>
        ///     CheckLaser()
        /// </code>
        /// </example>
        /// </summary>
        void CheckLaser()
        {
            // Find the origin and end point of the laser
            origin = transform.position;
            origin += this.transform.forward * 0.2f;
            endPoint = origin + this.transform.forward * 9f;

            // Set origin and end point of the laser
            targetPreview.SetPosition(0, origin);
            targetPreview.SetPosition(1, (Vector3)endPoint);

            // Draw the laser
            targetPreview.enabled = true;

        }
    }
}
