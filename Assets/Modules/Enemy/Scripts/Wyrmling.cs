using System.Collections;
using UnityEngine;
using Aloha.EntityStats;

namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    public class Wyrmling : Enemy<WyrmlingStats>
    {
        [SerializeField] 
        private WyrmlingFireball fireballPrefab;

        private float initialY;

        /// <summary>
        /// Is called on the frame when a script is enabled just before any of the Update methods are called the first time.
        /// </summary>
        void Start()
        {
            initialY = transform.position.y;
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>
        /// TODO
        /// </returns>
        protected override IEnumerator AI()
        {
            while (true)
            {
                int rand = Utils.RandomInt(2, 4);
                for (int i = 0; i < rand; i++)
                {
                    yield return StartCoroutine(MoveXToAnimation(Utils.RandomFloat(-1.5f, 1.5f), 1));
                }
                yield return StartCoroutine(AttackAnimation());
            }
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="x"></param>
        /// <param name="speed"></param>
        /// <returns>
        /// TODO
        /// </returns>
        protected override IEnumerator MoveXToAnimation(float x, float speed)
        {
            float temps = 0;
            Vector3 posInit = gameObject.transform.position;
            Vector3 posFinal = posInit;
            posFinal.x = x;

            while (temps < 1f)
            {
                temps += speed * Time.deltaTime;
                posFinal.y = initialY + Mathf.Sin( Mathf.PI * gameObject.transform.position.x) * 0.1f;
                gameObject.transform.position = Vector3.Lerp(posInit, posFinal, temps);
                yield return null;
            }

            gameObject.transform.position = posFinal;
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        ///     TODO
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>
        /// TODO
        /// </returns>
        protected IEnumerator AttackAnimation()
        {
            // Config fireball's spawning position
            Vector3 fireballPos = transform.position;
            fireballPos.x -= 0.5f;

            // Spawn fireball
            WyrmlingFireball fireball = Instantiate(fireballPrefab, fireballPos, Quaternion.identity);
            fireball.associatedEnemy = this;
            yield return new WaitForSeconds(1f);

            // Launch fireball to the hero
            Hero hero = GameManager.Instance.GetHero();
            Vector3 dir = hero.transform.position - fireball.transform.position;
            dir.Normalize();
            fireball.GetComponent<Rigidbody>().AddForce(dir * 3, ForceMode.Impulse);
            
            yield return null;
        }

    }
}
