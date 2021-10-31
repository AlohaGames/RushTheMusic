using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// TODO
    /// </summary>
    public class Sword : MonoBehaviour
    {
        public Warrior Warrior;
        public float Speed;
        private Vector3 presPos;
        private Vector3 newPos;
        
        [SerializeField] 
        private float minimumSpeedToKill = 1f;

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
            if (collider.tag == "Enemy" && Speed > minimumSpeedToKill)
            {
                Debug.Log(Speed);
                Warrior.Attack(collider.gameObject.GetComponent<Entity>());
                Warrior.BumpEntity(collider.GetComponent<Entity>(), Speed);
            }
        }
    }
}