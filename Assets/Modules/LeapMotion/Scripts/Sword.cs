using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Hero;

namespace Aloha {
    public class Sword : MonoBehaviour
    {
        Warrior warrior;
        private Vector3 presPos;
        private Vector3 newPos;
        private float speed;
        [SerializeField] float minimumSpeedToKill = 1f;

        private void Start()
        {
            presPos = transform.position;
            newPos = transform.position;
        }

        private void Update()
        {
            newPos = transform.position;
            speed = Mathf.Sqrt(Mathf.Pow((newPos.x - presPos.x),2) + Mathf.Pow((newPos.y - presPos.y),2) + Mathf.Pow((newPos.z - presPos.z),2))*100;
            presPos = newPos;
            //Debug.Log(velocity);
        }

        // If the Sword touch an Object
        void OnTriggerEnter(Collider collider)
        {
            Debug.Log("has collide with a speed of "+ speed);
            if (collider.tag == "Enemy" && speed> minimumSpeedToKill)
            {
                //warrior.Attack(collider.GetComponent<Entity<EntityStats>>());
                Debug.Log("Attack the Enemy");
                Destroy(collider.gameObject);
            }
        }
    }
}