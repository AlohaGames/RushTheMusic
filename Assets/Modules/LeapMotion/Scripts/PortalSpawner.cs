using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    public class PortalSpawner : MonoBehaviour
    {
        public Wizard wizard;
        [SerializeField] private Vortex vortexPrefab;
        [SerializeField] private Material raycastMaterial;
        private LineRenderer targetPreview;
        private Vector3 origin;
        private Vector3? endPoint;
        private bool preparingPortal;

        // Start is called before the first frame update
        void Start()
        {
            // TODO Change this
            //wizard = GameManager.Instance.GetHero() as Wizard;
            wizard = FindObjectOfType<Wizard>();

            preparingPortal = false;
            targetPreview = this.gameObject.AddComponent<LineRenderer>();
            targetPreview.material = raycastMaterial;
            targetPreview.startWidth = 0.02f;
            targetPreview.endWidth = 0.02f;
        }

        // Update is called once per frame
        void Update()
        {
            if (preparingPortal)
            {
                checkLaser();
            }
        }

        public void preparePortal()
        {
            preparingPortal = true;
        }

        public void SpawnPortal()
        {
            if (preparingPortal && endPoint != null)
            {
                Vector3 vortexPos = (Vector3)endPoint;
                vortexPos.y = 1;
                Vortex vortex = Instantiate(vortexPrefab, vortexPos, Quaternion.identity);
                preparingPortal = false;
                targetPreview.enabled = false;
            }
        }

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