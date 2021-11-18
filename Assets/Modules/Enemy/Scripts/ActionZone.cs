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
        private bool wasTriggered = false;

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
            if (!wasTriggered && other.tag == "Player")
            {
                wasTriggered = true;
                transform.parent.GetComponent<Enemy>().DetachFromParent();
                transform.parent.GetComponent<Enemy>().SetAI(true);
            }
        }
    }
}
