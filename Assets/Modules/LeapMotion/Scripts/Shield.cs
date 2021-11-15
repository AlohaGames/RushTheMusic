using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    public class Shield : MonoBehaviour
    {
        [SerializeField] 
        float minimumSpeedToProtect = 0.1f;

        private Vector3 presPos;
        private Vector3 newPos;
        public Warrior Warrior;
        public float Speed;

        /// <summary>
        /// Is called on the frame when a script is enabled just before any of the Update methods are called the first time.
        /// </summary>
        void Start()
        {
            Warrior = GameManager.Instance.GetHero() as Warrior;
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
            if (collider.tag == "Enemy" && Speed > minimumSpeedToProtect)
            {
                // Change minimum speed if actual speed is to low
                if (Speed < 1) Speed = 1f;
                Warrior.BumpEntity(collider.GetComponent<Entity>(),Speed);
            }
        }
    }
}
