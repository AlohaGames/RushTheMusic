using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// Class for the item user
    /// </summary>
    public class ItemUser : MonoBehaviour
    {

        private bool canUseItem;
        private bool handUpdated;
        private Vector3 firstPosition;

        /// <summary>
        /// Is called on the frame when a script is enabled just before any of the Update methods are called the first time.
        /// </summary>
        void Start()
        {
            canUseItem = false;
            handUpdated = false;
            firstPosition = transform.position;
        }

        /// <summary>
        /// Update is called once per frame
        /// </summary>
        void Update()
        {
            // Prevent wrong instantiation of leap hands
            if (!handUpdated && firstPosition != transform.position)
                handUpdated = true;

            if (handUpdated)
            {
                // Use item if hand is in the right position
                if (transform.rotation.eulerAngles.z > 350 || transform.rotation.eulerAngles.z < 10)
                {
                    if (canUseItem)
                    {
                        InventoryManager.Instance.UseItem();
                        canUseItem = false;
                    }
                }
                else
                {
                    canUseItem = true;
                }
            }
        }
    }
}
