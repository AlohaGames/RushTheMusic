using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// Class for the fireball of a wyrmling
    /// </summary>
    public class WyrmlingFireball : MonoBehaviour
    {
        public Enemy AssociatedEnemy;

        /// <summary>
        /// Method called when enter in collision with a player
        /// <example> Example(s):
        /// <code>
        ///     fireball.OnTriggerEnter(collider);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="collider"></param>
        public void OnTriggerEnter(Collider collider)
        {
            if (collider.tag == "Player")
            {
                AssociatedEnemy.Attack(collider.gameObject.GetComponent<Entity>());
                Destroy(gameObject);
            }
        }
    }
}
