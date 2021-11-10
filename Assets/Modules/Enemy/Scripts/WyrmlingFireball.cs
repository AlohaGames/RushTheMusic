using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    public class WyrmlingFireball : MonoBehaviour
    {
        public Enemy associatedEnemy;

        public void OnTriggerEnter(Collider collider)
        {
            if (collider.tag == "Player")
            {
                associatedEnemy.Attack(collider.gameObject.GetComponent<Entity>());
                Debug.Log(collider.gameObject.GetComponent<Entity>().currentHealth);
                Destroy(gameObject);
            }
        }
    }
}
