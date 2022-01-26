using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// Class for the dark wizard's laser
    /// </summary>
    public class Laser : MonoBehaviour
    {
        private Coroutine actionCoroutine;
        private float currentSize;
        private bool canDamage;
        private Vector3 center;
        public DarkWizard DarkWizard;

        [HideInInspector]
        public Vector3 Origin;

        [HideInInspector]
        public Vector3 End;
        
        [HideInInspector]
        public float Speed;

        [HideInInspector]
        public float Duration;

        /// <summary>
        /// Is called on the frame when a script is enabled just before any of the Update methods are called the first time.
        /// </summary>
        void Awake()
        {
            this.Origin = Vector3.zero;
            this.End = Vector3.zero;
            this.Speed = 2;
            this.Duration = 2;
            this.canDamage = true;
        }

        /// <summary>
        /// Coroutine called to extend the laser
        /// </summary>
        /// <param name="delay"></param>
        private IEnumerator Extend(float delay = 0.0f)
        {
            // Set to default values
            float distance = Vector3.Distance(this.Origin, this.End);
            this.currentSize = 0;
            this.center = this.Origin;
            transform.position = this.Origin;
            Vector3 localScale = transform.localScale;
            transform.localScale = Vector3.zero;
            yield return null;

            // Rotate in target direction
            transform.LookAt(this.End);
            transform.Rotate(new Vector3(90, 0, 0));

            yield return new WaitForSeconds(delay);

            // First step : extension from origin to end
            float time = 0;
            transform.localScale = localScale;
            while (time < (distance / 2))
            {
                time += Time.deltaTime * this.Speed;

                // Update size
                this.currentSize = time;
                Vector3 currentScale = transform.localScale;
                currentScale.y = this.currentSize;
                transform.localScale = currentScale;

                // Update position
                this.center = this.Origin + transform.up * this.currentSize;
                transform.localPosition = this.center;

                yield return null;
            }

            // Second step : Wait for a defined duration
            yield return new WaitForSeconds(this.Duration);

            // Third step : diminution from end to origin
            while (time < (distance))
            {
                time += Time.deltaTime * this.Speed;

                // Update size
                this.currentSize = distance - time;
                Vector3 currentScale = transform.localScale;
                currentScale.y = this.currentSize;
                transform.localScale = currentScale;

                // Update position
                this.center = this.Origin + transform.up * time;
                transform.localPosition = this.center;
                yield return null;
            }

            this.DarkWizard.ReleaseAttack();
        }

        /// <summary>
        /// Method to call to attack with the laser
        /// </summary>
        /// <param name="collider"></param>
        private IEnumerator Damage(Collider collider)
        {
            this.canDamage = false;
            DarkWizard.Attack(collider.gameObject.GetComponent<Entity>());
            yield return new WaitForSeconds(Duration / 10);
            this.canDamage = true;
        }

        /// <summary>
        /// Method to call to throw the laser in a specific direction
        /// <example> Example(s):
        /// <code>
        ///     Vector3 initial = transform.position;
        ///     initial.x += 0.75f;
        ///     initial.y -= 0.5f;
        ///     Vector3 target = new Vector3(0.0f, 1.0f, 0.0f);
        ///     laser.ThrowLaser(initial, target, 15.0f, 2.0f, 0.8f)
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="end"></param>
        /// <param name="speed"></param>
        /// <param name="duration"></param>
        /// <param name="delay"></param>
        public void ThrowLaser(Vector3 origin, Vector3 end, float speed, float duration, float delay = 0.0f)
        {
            this.Origin = origin;
            this.End = end;
            this.Speed = speed;
            this.Duration = duration;
            actionCoroutine = StartCoroutine(Extend(delay));
        }
        
        /// <summary>
        /// Method called when enter in collision with a player
        /// <example> Example(s):
        /// <code>
        ///     fireball.OnTriggerEnter(collider);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="collider"></param>
        public void OnTriggerStay(Collider collider)
        {
            if (collider.tag == "Player")
            {
                if (canDamage)
                {
                    StartCoroutine(Damage(collider));
                }
            }
        }

        /// <summary>
        /// Method called with the objectif is destroyed
        /// </summary>
        private void OnDestroy()
        {
            DarkWizard.ReleaseAttack();
            StopCoroutine(actionCoroutine);
        }
    }
}