using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// Class for the vortex spell
    /// </summary>
    public class Vortex : MonoBehaviour {

        public Wizard Wizard;
        public int Power;

        /// <summary>
        /// If the vortex touches an Object
        /// </summary>
        public void OnTriggerEnter(Collider collider)
        {
            if (collider.tag == "Enemy")
            {
                collider.gameObject.GetComponent<Entity>().TakeDamage(0);
                Wizard.BumpEntity(collider.GetComponent<Entity>());

                Wizard.RegenerateSecondary((float)this.Power / (float)Wizard.GetStats().MaxMana);
                Destroy(gameObject);
            }
        }
    }

}
