using UnityEngine;

namespace Aloha
{
    public class Sword : MonoBehaviour
    {
        public Warrior warrior;
        private Vector3 presPos;
        private Vector3 newPos;
        public float speed;
        [SerializeField] float minimumSpeedToKill = 1f;

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

        // If the Sword touch an Object
        public void OnTriggerEnter(Collider collider)
        {
            if (collider.tag == "Enemy" && speed > minimumSpeedToKill)
            {
                Debug.Log(speed);
                warrior.Attack(collider.gameObject.GetComponent<Entity>());
                warrior.BumpEntity(collider.GetComponent<Entity>(), speed);
            }
        }
    }
}