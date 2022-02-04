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
            if (collider.tag == "Enemy" || collider.tag == "Boss")
            {
                // Affect entity
                collider.gameObject.GetComponent<Entity>().TakeDamage(0);
                Wizard.BumpEntity(collider.GetComponent<Entity>());

                // Auto destroy
                Wizard.RegenerateSecondary((float)this.Power / (float)Wizard.GetStats().MaxMana);
                Destroy(gameObject);
            } else if (collider.tag == "EnemyAttack" || collider.tag == "BossAttack")
            {
                // Affect entity attack
                Destroy(collider.gameObject);

                // Auto destroy
                Wizard.RegenerateSecondary((float)this.Power / (float)Wizard.GetStats().MaxMana);
                Destroy(gameObject);
            }
        }
    }

}
