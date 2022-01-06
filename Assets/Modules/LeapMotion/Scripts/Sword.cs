using UnityEngine;

namespace Aloha
{
    /// <summary>
    /// Class for the warrior's sword
    /// </summary>
    public class Sword : MonoBehaviour
    {
        private Vector3 presPos;
        private Vector3 newPos;

        [SerializeField]
        private float minimumSpeedToKill = 1f;

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
        /// Is called when a GameObject collides with another GameObject.
        /// </summary>
        /// <param name="other">other collider</param>
        public void OnTriggerEnter(Collider other)
        {
            bool leapActivated = GameManager.Instance ? GameManager.Instance.LeapMode : true;
            if (other.tag == "Enemy" && ((!leapActivated && Warrior.IsAttacking) || (leapActivated && Speed > minimumSpeedToKill)))
            {
                Debug.Log(Speed);
                Warrior.IsAttacking = false;
                Warrior.Attack(other.gameObject.GetComponent<Entity>());
                Warrior.BumpEntity(other.GetComponent<Entity>(), Speed);
            }
        }
    }
}
