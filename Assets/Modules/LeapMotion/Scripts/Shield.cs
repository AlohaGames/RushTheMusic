using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Hero;

namespace Aloha
{
    public class Shield : MonoBehaviour
    {
        Warrior warrior;

        // If the Shield touch an Object
        void OnTriggerEnter(Collider collider)
        {
            Debug.Log("has collide");
            if (collider.tag == "Enemy")
            {
                Debug.Log("Block the enemy attack");
                //TODO
            }
        }
    }
}