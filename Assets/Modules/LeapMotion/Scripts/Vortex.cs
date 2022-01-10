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
            Debug.Log("Hey ! It's me ! Mario !");
            if (collider.tag == "Enemy")
            {
                // Affect entity
                collider.gameObject.GetComponent<Entity>().TakeDamage(0);
                Wizard.BumpEntity(collider.GetComponent<Entity>());

                // Auto destroy
                Wizard.RegenerateSecondary((float)this.Power / (float)Wizard.GetStats().MaxMana);
                Destroy(gameObject);
            } else if (collider.tag == "EnemyAttack")
            {
                Debug.Log("Hey ! It's me ! Mario ! 2");
                // Affect entity attack
                Destroy(collider.gameObject);

                // Auto destroy
                Wizard.RegenerateSecondary((float)this.Power / (float)Wizard.GetStats().MaxMana);
                Destroy(gameObject);
            }
        }
    }

}
