using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha {
    public class Fireball : MonoBehaviour
    {
        public Wizard wizard;

        public void Launch()
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * 3, ForceMode.Impulse);
            transform.parent = null;
            Destroy(gameObject, 3f);
        }

        // If the Sword touch an Object
        public void OnTriggerEnter(Collider collider)
        {
            if (collider.tag == "Enemy")
            {
                Debug.Log("Coucou");
                wizard.Attack(collider.gameObject.GetComponent<Entity>());
                wizard.BumpEntity(collider.GetComponent<Entity>());
                Destroy(gameObject);
            }
        }

    }
}