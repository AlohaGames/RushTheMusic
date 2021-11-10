using UnityEngine;

namespace Aloha
{
    public class Shield : MonoBehaviour
    {
        public Warrior warrior;
        private Vector3 presPos;
        private Vector3 newPos;
        public float speed;
        [SerializeField] float minimumSpeedToProtect = 0.1f;

        private void Start()
        {
            warrior = GameManager.Instance.GetHero() as Warrior;
            presPos = transform.position;
            newPos = transform.position;
        }

        private void Update()
        {
            newPos = transform.position;
            speed = (newPos - presPos).magnitude * 100;
            presPos = newPos;
        }

        // If the Shield touch an Object
        public void OnTriggerEnter(Collider collider)
        {
            Debug.Log(speed);
            if (collider.tag == "Enemy" && speed > minimumSpeedToProtect)
            {
                // Change minimum speed if actual speed is to low
                if (speed < 1) speed = 1f;
                warrior.BumpEntity(collider.GetComponent<Entity>(), speed);
            }
        }
    }
}