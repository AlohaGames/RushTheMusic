using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha {
    public class Fireball : MonoBehaviour
    {
        public Wizard Wizard;
        public int Power;

        public void Launch()
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * 5, ForceMode.Impulse);
            transform.parent = null;
            Destroy(gameObject, 3f);
        }

        // If the fireball touch an Object
        public void OnTriggerEnter(Collider collider)
        {
            if (collider.tag == "Enemy")
            {
                collider.gameObject.GetComponent<Entity>().TakeDamage(this.Power);
                Wizard.BumpEntity(collider.GetComponent<Entity>());
                Destroy(gameObject);
            }
        }

    }
}