using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Hero;

namespace Aloha
{
    public class Shield : MonoBehaviour
    {
        [SerializeField] Warrior warrior;
        private Vector3 presPos;
        private Vector3 newPos;
        private float speed;

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
        void OnTriggerEnter(Collider collider)
        {
            Debug.Log("has collide");
            if (collider.tag == "Enemy")
            {
                Debug.Log("Block the enemy attack");
                warrior.BumpEntity(collider.GetComponent<Entity>(),speed);
            }
        }
    }
}