using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// Invoke Event when collider enter ActionZone
    /// </summary>
    public class ActionZone : MonoBehaviour
    {
        public bool WasTriggered = false;

        /// <summary>
        /// Call when other collider trigger this collider
        /// </summary>
        /// <param name="other">Other Collider</param>
        public void OnTriggerEnter(Collider other)
        {
            if (!WasTriggered && other.tag == "Player")
            {
                WasTriggered = true;
                transform.parent.GetComponent<Enemy>().NearHeroTrigger.Invoke();
            }
        }
    }
}
