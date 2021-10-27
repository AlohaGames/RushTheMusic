using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    public class ActionZone : MonoBehaviour
    {
        private bool wasTriggered = false;

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
