using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// Manager that allow to control mouse hands
    /// </summary>
    public class ControlManager : MonoBehaviour
    {
        [SerializeField]
        protected GameObject rightHand;
        [SerializeField]
        protected GameObject leftHand;

        /// <summary>
        /// Update is called once per frame
        /// </summary>
        void Update()
        {
            // if mouse mode activated, play with mouse and keyboard
            if (!GameManager.Instance.LeapMode && !GameManager.Instance.IsGamePaused() && GameManager.Instance.IsPlaying())
            {
                MoveHandsWithMouse();
                CheckInputs();
            }
        }

        /// <summary>
        /// Move hands according to mouse movements
        /// <example> Example(s):
        /// <code>
        ///     MoveHandsWithMouse()
        /// </code>
        /// </example>
        /// </summary>
        void MoveHandsWithMouse()
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
        }

        /// <summary>
        /// Check user inputs to interact with the Hero with mouse and keyboard 
        /// <example> Example(s):
        /// <code>
        ///     CheckInputs()
        /// </code>
        /// </example>
        /// </summary>
        void CheckInputs()
        {
            if (Input.GetKeyDown(InputBinding.Instance.Attack))
            {
                PrepareAttack();
            }
            else if (Input.GetKeyUp(InputBinding.Instance.Attack))
            {
                ReleaseAttack();
            }
            else if (Input.GetKeyDown(InputBinding.Instance.Defense))
            {
                PrepareDefense();
            }
            else if (Input.GetKeyUp(InputBinding.Instance.Defense))
            {
                ReleaseDefense();
            }
            else if (Input.GetKeyUp(InputBinding.Instance.UseItem))
            {
                // TODO Add use item
            }
        }

        /// <summary>
        /// Prepare Hero's attack
        /// <example> Example(s):
        /// <code>
        ///     PrepareAttack()
        /// </code>
        /// </example>
        /// </summary>
        protected virtual void PrepareAttack() { }

        /// <summary>
        /// Release Hero's attack
        /// <example> Example(s):
        /// <code>
        ///     ReleaseAttack()
        /// </code>
        /// </example>
        /// </summary>
        protected virtual void ReleaseAttack() { }

        /// <summary>
        /// Prepare Hero's defense
        /// <example> Example(s):
        /// <code>
        ///     PrepareDefense()
        /// </code>
        /// </example>
        /// </summary>
        protected virtual void PrepareDefense() { }

        /// <summary>
        /// Release Hero's defense
        /// <example> Example(s):
        /// <code>
        ///     PrepareDefense()
        /// </code>
        /// </example>
        /// </summary>
        protected virtual void ReleaseDefense() { }
    }
}