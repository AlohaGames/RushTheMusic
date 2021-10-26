using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    public class Shield : MonoBehaviour
    {
        public Warrior warrior;
        private Vector3 presPos;
        private Vector3 newPos;
        public float speed;

        private void Start()
        {
            presPos = transform.position;
            newPos = transform.position;
        }

        private void Update()
        {
            newPos = transform.position;
            speed = (newPos - presPos).magnitude * 100;
            presPos = newPos;
        }

        // If the Shield touch an Object
        public void OnTriggerEnter(Collider collider)
        {
            if (collider.tag == "Enemy")
            {
                // Change minimum speed if actual speed is to low
                if (speed < 1) speed = 1f;
                warrior.BumpEntity(collider.GetComponent<Entity>(),speed);
            }
        }
    }
}