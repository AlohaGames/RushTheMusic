using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha {
    public class Fireball : MonoBehaviour
    {
        public Wizard wizard;
        private bool isAutonomous = false;
        
        private void Start()
        {
            //warrior = GameManager.Instance.GetHero() as Wizard;
        }

        private void Update()
        {
            if(isAutonomous)
            {
                transform.localPosition += new Vector3(0, 1 * Time.deltaTime, 0);
            }
        }

        public void GoForward()
        {
            isAutonomous = true;
            GameObject parent = transform.parent.gameObject;
            //transform.parent = null;
            //transform.rotation = parent.transform.rotation.eulerAngles;

            //transform.position = parent.transform.position;
            Vector3 rotation = transform.rotation.eulerAngles;
            Debug.Log(rotation.x);
            Debug.Log(transform.eulerAngles.y);
            Debug.Log(rotation.z);
            transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y+90, rotation.z);
            Debug.Log("");
            Vector3 velocity = transform.rotation * parent.transform.forward;
            GetComponent<Rigidbody>().AddForce(velocity, ForceMode.Impulse);

            transform.parent = null;
            //GetComponent<Rigidbody>().AddForce(new Vector3(0, -1, 0));
        }
    }
}