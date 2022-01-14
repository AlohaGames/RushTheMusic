using System.Collections;
using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// Class for the shield
    /// </summary>
    public class Shield : MonoBehaviour
    {
        [SerializeField]
        private float minimumSpeedToProtect = 0.1f;

        [SerializeField]
        private SpriteRenderer sprite;

        private Vector3 presPos;
        private Vector3 newPos;
        public Warrior Warrior;
        public float Speed;

        /// <summary>
        /// Is called on the frame when a script is enabled just before any of the Update methods are called the first time.
        /// </summary>
        void Start()
        {
            if (!Warrior)
            {
                Warrior = GameManager.Instance.GetHero() as Warrior;
            }

            presPos = transform.position;
            newPos = transform.position;
        }

        /// <summary>
        /// Is called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        void Update()
        {
            newPos = transform.position;
            Speed = (newPos - presPos).magnitude * 100;
            presPos = newPos;
        }

        /// <summary>
        /// Change opacity of the shield
        /// <example> Example(s):
        /// <code>
        ///     this.changeOpacity(0.75f);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="opacity"></param>
        void changeOpacity(float opacity)
        {
            Color c = sprite.color;
            c.a = opacity;
            sprite.color = c;
        }

        /// <summary>
        /// Make the shield wink
        /// <example> Example(s):
        /// <code>
        ///     StartCoroutine(Wink());
        /// </code>
        /// </example>
        /// </summary>
        IEnumerator Wink()
        {
            Warrior.CanDefend = false;

            changeOpacity(0.75f);
            yield return new WaitForSeconds(0.25f);

            changeOpacity(0.25f);
            yield return new WaitForSeconds(0.25f);

            changeOpacity(0.75f);
            yield return new WaitForSeconds(0.25f);

            changeOpacity(0.25f);
            yield return new WaitForSeconds(0.25f);

            changeOpacity(1.0f);
            Warrior.CanDefend = true;

            yield return null;
        }

        /// <summary>
        /// Is called when a GameObject collides with another GameObject.
        /// <example> Example(s):
        /// <code>
        ///     aGameObject.OnTriggerEnter(anotherGameObject);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="collider"></param>
        public void OnTriggerEnter(Collider collider)
        {
            if (collider.tag == "Enemy" && Warrior.CanDefend && (Warrior.IsDefending || Speed > minimumSpeedToProtect))
            {

                SoundEffectManager.Instance.Play(
                    SoundEffectManager.Instance.Sounds.warrior_block, this.gameObject
                );

                // Change minimum speed if actual speed is to low
                if (Speed < 1.5) Speed = 1.5f;
                collider.gameObject.GetComponent<Entity>().TakeDamage(0);
                Warrior.BumpEntity(collider.GetComponent<Entity>(), Speed);

                StartCoroutine(Wink());
            }
            else if (collider.tag == "EnemyAttack" && Warrior.CanDefend && (Warrior.IsDefending || Speed > minimumSpeedToProtect))
            {

                SoundEffectManager.Instance.Play(
                    SoundEffectManager.Instance.Sounds.warrior_block, this.gameObject
                );

                StartCoroutine(Wink());
                Destroy(collider.gameObject);
            }
        }
    }
}
