using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha 
{
    /// <summary>
    /// TODO
    /// </summary>
    public class Fireball : MonoBehaviour
    {
        public Wizard Wizard;
        public int Power;

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
        public void Launch()
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * 5, ForceMode.Impulse);
            transform.parent = null;
            Destroy(gameObject, 3f);
        }

        /// <summary>
        /// If the fireball touch an Object
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
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
