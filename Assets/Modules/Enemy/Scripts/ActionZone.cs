using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    public class ActionZone : MonoBehaviour
    {
        public bool WasTriggered = false;

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="other"></param>
        public void OnTriggerEnter(Collider other)
        {
            if (!WasTriggered && other.tag == "Player")
            {
                WasTriggered = true;
                //transform.parent.GetComponent<Enemy>().DetachFromParent();
                //transform.parent.GetComponent<Enemy>().SetAI(true);
                transform.parent.GetComponent<Enemy>().NearHeroTrigger.Invoke();
            }
        }
    }
}
