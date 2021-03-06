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
        IEnumerator Wink(int duration, float min=0.25f, float max=0.75f)
        {
            Warrior.CanDefend = false;

            bool on = true;

            for(int i = 0; i < (duration / 0.25f); i++)
            {
                changeOpacity(on ? max : min);
                on = !on;
                yield return new WaitForSeconds(0.25f);
            }

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
            if (Warrior.CanDefend && (Warrior.IsDefending || (GameManager.Instance.Config.LeapMode && Speed > minimumSpeedToProtect)))
            {
                if (collider.tag == "Enemy")
                {
                    SoundEffectManager.Instance.Play(
                        SoundEffectManager.Instance.Sounds.warrior_block, this.gameObject
                    );

                    // Change minimum speed if actual speed is to low
                    if (Speed < 1.5) Speed = 1.5f;
                    collider.gameObject.GetComponent<Entity>().TakeDamage(0);
                    Warrior.BumpEntity(collider.GetComponent<Entity>(), Speed);

                    StartCoroutine(Wink(1));
                }
                else if (collider.tag == "Boss")
                {
                    SoundEffectManager.Instance.Play(
                        SoundEffectManager.Instance.Sounds.warrior_block, this.gameObject
                    );

                    // Change minimum speed if actual speed is to low
                    if (Speed < 1.5) Speed = 2f;
                    collider.gameObject.GetComponent<Entity>().TakeDamage(0);
                    Warrior.BumpEntity(collider.GetComponent<Entity>(), Speed);

                    StartCoroutine(Wink(2));
                }
                else if (collider.tag == "EnemyAttack")
                {
                    SoundEffectManager.Instance.Play(
                        SoundEffectManager.Instance.Sounds.warrior_block, this.gameObject
                    );

                    StartCoroutine(Wink(1));
                    Destroy(collider.gameObject);
                }
                else if (collider.tag == "BossAttack")
                {
                    SoundEffectManager.Instance.Play(
                        SoundEffectManager.Instance.Sounds.warrior_block, this.gameObject
                    );

                    StartCoroutine(Wink(2));
                    Destroy(collider.gameObject);
                }
            }
        }
    }
}
