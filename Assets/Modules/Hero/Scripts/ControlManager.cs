using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    public class ControlManager : MonoBehaviour
    {
        //TODO Set mode in gameManager
        private bool leapMode = true;

        // Start is called before the first frame update
        void Start()
        {
            leapMode = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (!leapMode && GameManager.Instance.GetIsPlaying())
            {
                // Get camera rotation
                float ry = Input.GetAxis("Mouse Y");
                float rx = Input.GetAxis("Mouse X");

                // Rotate hands on y axis if it's in the camera angle
                if ((transform.rotation.y > -0.5f && rx < 0) || (transform.rotation.y < 0.5f && rx > 0))
                {
                    transform.RotateAround(this.transform.parent.transform.position, this.transform.parent.transform.up, rx);
                }

                // Rotate hands on x axis if it's in the camera angle
                if ((transform.rotation.x > -0.25f && ry > 0) || (transform.rotation.x < 0.1f && ry < 0))
                {
                    transform.RotateAround(this.transform.parent.transform.position, this.transform.parent.transform.right, -ry);
                }
                
                CheckInputs();
            }
        }

        void CheckInputs()
        {
            if (Input.GetKeyDown(InputBinding.Instance.attack))
            {
                PrepareAttack();
            }
            else if (Input.GetKeyUp(InputBinding.Instance.attack))
            {
                ReleaseAttack();
            }
            else if (Input.GetKeyDown(InputBinding.Instance.defense))
            {
                PrepareDefense();
            }
            else if (Input.GetKeyUp(InputBinding.Instance.defense))
            {
                ReleaseDefense();
            }
        }

        protected virtual void PrepareAttack() { }

        protected virtual void ReleaseAttack() { }

        protected virtual void PrepareDefense() { }

        protected virtual void ReleaseDefense() { }
    }
}
