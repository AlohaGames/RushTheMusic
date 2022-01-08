using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// Class for a canonball
    /// </summary>
    public class CanonBall : MonoBehaviour
    {
        public Enemy AssociatedEnemy;

        /// <summary>
        /// Send the canon forward
        /// <example> Example(s):
        /// <code>
        ///     CanonBall canonball = Instantiate(canonBallPrefab);
        ///     canonball.Launch();
        /// </code>
        /// </example>
        /// </summary>
        public void Launch(Vector3 heroPosition)
        {
            StartCoroutine(Movement(heroPosition, 1f, 1.5f));
            transform.parent = null;
        }

        /// <summary>
        /// Make a gravity movement 
        /// <example> Example(s):
        /// <code>
        ///     StartCoroutine(Movement(heroPosition, 1f));
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="heroPosition"></param>
        /// <param name="speed"></param>
        public virtual IEnumerator Movement(Vector3 heroPosition, float speed = 2f, float actionTime = 2f)
        {
            float temps = 0;
            Vector3 posInit = gameObject.transform.position;
            Vector3 posFinal = heroPosition;

            while (temps < actionTime)
            {
                temps += speed * Time.deltaTime;

                Vector3 tmpPos = Vector3.Lerp(posInit, posFinal, temps / actionTime);
                tmpPos.y = posInit.y + Mathf.Sin(temps / actionTime * Mathf.PI) * (posInit.z - posFinal.z) / 8; ;
                gameObject.transform.position = tmpPos;

                yield return null;
            }
            gameObject.transform.position = posFinal;
            yield return null;
        }

        /// <summary>
        /// Method called when object enter in collision with a player
        /// <example> Example(s):
        /// <code>
        ///     canonBall.OnTriggerEnter(anotherCollider);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="collider"></param>
        public void OnTriggerEnter(Collider collider)
        {
            if (collider.tag == "Player")
            {
                AssociatedEnemy.Attack(collider.gameObject.GetComponent<Entity>());
                Destroy(gameObject);
            } else if (collider.tag == "AttackBlocker")
            {
                Destroy(gameObject);
            }
        }
    }
}
