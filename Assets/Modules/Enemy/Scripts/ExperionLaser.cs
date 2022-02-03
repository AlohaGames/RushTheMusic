using System;
using System.Collections;
using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// Class for experion's laser
    /// </summary>
    public class ExperionLaser : MonoBehaviour
    {
        private float currentSize;
        private bool canDamage;
        private Vector3 center;
        private Vector3 origin;
        private Vector3 end;
        private float speed;
        private float duration;
        public Experion AssociatedEnemy;
        public ParticleSystem Particles;

        /// <summary>
        /// Is called on the frame when a script is enabled just before any of the Update methods are called the first time.
        /// </summary>
        void Awake()
        {
            this.origin = Vector3.zero;
            this.end = Vector3.zero;
            this.speed = 2;
            this.duration = 2;
            this.canDamage = true;
        }

        /// <summary>
        /// Coroutine called to extend the laser
        /// </summary>
        /// <param name="delay"></param>
        private IEnumerator Extend(float delay = 0.0f)
        {
            // Set to default values
            float distance = Vector3.Distance(this.origin, this.end);
            this.currentSize = 0;
            this.center = this.origin;
            transform.position = this.origin;
            Vector3 localScale = transform.localScale;
            transform.localScale = Vector3.zero;
            yield return null;

            // Rotate in target direction
            transform.LookAt(this.end);
            transform.Rotate(new Vector3(90, 0, 0));

            yield return new WaitForSeconds(delay);

            // First step : extension from origin to end
            float time = 0;
            transform.localScale = localScale;
            if (this.Particles)
            {
                this.Particles.Play();
            }
            while (time < (distance / 2))
            {
                time += Time.deltaTime * this.speed;

                // Update size
                this.currentSize = time;
                Vector3 currentScale = transform.localScale;
                currentScale.y = this.currentSize;
                transform.localScale = currentScale;

                // Update position
                this.center = this.origin + transform.up * this.currentSize;
                transform.localPosition = this.center;

                yield return null;
            }

            // Second step : Wait for a defined duration
            yield return new WaitForSeconds(this.duration);

            // Third step : diminution from end to origin
            while (time < (distance))
            {
                time += Time.deltaTime * this.speed;

                // Update size
                this.currentSize = distance - time;
                Vector3 currentScale = transform.localScale;
                currentScale.y = this.currentSize;
                transform.localScale = currentScale;

                // Update position
                this.center = this.origin + transform.up * time;
                transform.localPosition = this.center;
                yield return null;
            }

            AssociatedEnemy.ReleaseAttack();
        }

        /// <summary>
        /// Method to call to attack with the laser
        /// </summary>
        /// <param name="collider"></param>
        private IEnumerator Damage(Collider collider)
        {
            this.canDamage = false;
            AssociatedEnemy.Attack(collider.gameObject.GetComponent<Entity>());
            yield return new WaitForSeconds(this.duration / 10);
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
            this.origin = origin;
            this.end = end;
            this.speed = speed;
            this.duration = duration;
            StartCoroutine(Extend(delay));
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
            if (AssociatedEnemy != null)
            {
                AssociatedEnemy.ReleaseAttack();
            }
            StopAllCoroutines();
        }
    }
}
