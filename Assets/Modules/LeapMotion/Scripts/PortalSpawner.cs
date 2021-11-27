using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    public class PortalSpawner : MonoBehaviour
    {
        [SerializeField] 
        private Vortex vortexPrefab;

        [SerializeField] 
        private Material raycastMaterial;

        private LineRenderer targetPreview;
        private Vector3 origin;
        private Vector3? endPoint;
        private bool preparingPortal;
        public Wizard Wizard;

        /// <summary>
        /// Is called on the frame when a script is enabled just before any of the Update methods are called the first time.
        /// </summary>
        void Start()
        {
            Wizard = GameManager.Instance.GetHero() as Wizard;

            preparingPortal = false;
            targetPreview = this.gameObject.AddComponent<LineRenderer>();
            targetPreview.material = raycastMaterial;
            targetPreview.startWidth = 0.02f;
            targetPreview.endWidth = 0.02f;
        }

        /// <summary>
        /// Is called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        void Update()
        {
            if (preparingPortal)
            {
                checkLaser();
            }
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
        public void preparePortal()
        {
            preparingPortal = true;
        }

        /// <summary>
        /// Spawn a new vortex at the laser position
        /// <example> Example(s):
        /// <code>
        ///     SpawnPortal()
        /// </code>
        /// </example>
        /// </summary>
        public void SpawnPortal()
        {
            if (preparingPortal && endPoint != null)
            {
                int manaUsed = Wizard.ChargeVortex();

                if (manaUsed != 0)
                {
                    // Set vortex position
                    Vector3 vortexPos = (Vector3)endPoint;
                    vortexPos.y = 1;

                    // Instantiate the vortex
                    Vortex vortex = Instantiate(vortexPrefab, vortexPos, Quaternion.identity);
                    vortex.Wizard = this.Wizard;
                    vortex.Power = manaUsed;

                    // Reset variables
                    preparingPortal = false;
                    targetPreview.enabled = false;
                }
            }
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
        void checkLaser()
        {
            // Find the origin and end point of the laser
            origin = transform.position;
            endPoint = origin + this.transform.forward * 9f;

            // Find direction of laser
            Vector3 dir = (Vector3)endPoint - origin;
            dir.Normalize();

            // Get laser collision
            RaycastHit hit;
            if (Physics.Raycast(origin, dir, out hit, 300f))
            {
                endPoint = hit.point;

                // Set origin and end point of the laser
                targetPreview.SetPosition(0, origin);
                targetPreview.SetPosition(1, (Vector3)endPoint);

                // Draw the laser
                targetPreview.enabled = true;
            } else
            {
                endPoint = null;
                targetPreview.enabled = false;
            }
        }
    }
}
