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
                //TODO
                //Enemy father = transform.parent.GetComponent<Enemy>();
                wasTriggered = true;
                transform.parent.GetComponent<Lancer>().DetachFromParent();
                transform.parent.GetComponent<Lancer>().SetAI(true);
            }
        }
    }
}
