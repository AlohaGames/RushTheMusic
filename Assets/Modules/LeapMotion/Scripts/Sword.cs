using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Hero;

namespace Aloha {
    public class Sword : MonoBehaviour
    {
        [SerializeField] Warrior warrior;
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
            speed = (newPos - presPos).magnitude*100;
            presPos = newPos;
        }

        // If the Sword touch an Object
        void OnTriggerEnter(Collider collider)
        {
            if (collider.tag == "Enemy" && speed> minimumSpeedToKill)
            {
                warrior.Attack(collider.gameObject.GetComponent<Entity>());
                warrior.BumpEntity(collider.GetComponent<Entity>(), speed);
            }
        }
    }
}