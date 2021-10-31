using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    public class Shield : MonoBehaviour
    {
        public Warrior Warrior;
        public float Speed;
        private Vector3 presPos;
        private Vector3 newPos;

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// </code>
        /// </example>
        /// </summary>
        private void Start()
        {
            Warrior = GameManager.Instance.GetHero() as Warrior;
            presPos = transform.position;
            newPos = transform.position;
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// </code>
        /// </example>
        /// </summary>
        private void Update()
        {
            newPos = transform.position;
            Speed = (newPos - presPos).magnitude * 100;
            presPos = newPos;
        }

        /// <summary>
        /// TODO
        /// <example> Example(s):
        /// <code>
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="collider"></param>
        public void OnTriggerEnter(Collider collider)
        {
            if (collider.tag == "Enemy")
            {
                // Change minimum speed if actual speed is to low
                if (Speed < 1) Speed = 1f;
                Warrior.BumpEntity(collider.GetComponent<Entity>(),Speed);
            }
        }
    }
}
