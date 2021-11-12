using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    public class ActionZone : MonoBehaviour
    {
        public bool WasTriggered = false;

        public void OnTriggerEnter(Collider other)
        {
            if (!WasTriggered && other.tag == "Player")
            {
                WasTriggered = true;
                transform.parent.GetComponent<Enemy>().DetachFromParent();
                transform.parent.GetComponent<Enemy>().SetAI(true);
                transform.parent.GetComponent<Enemy>().NearHeroTrigger.Invoke();
            }
        }
    }
}
