using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    public class WyrmlingFireball : MonoBehaviour
    {
        public Enemy AssociatedEnemy;

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        ///     TODO
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
