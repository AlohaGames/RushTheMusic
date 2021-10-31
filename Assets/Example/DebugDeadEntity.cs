using UnityEngine;
using Aloha;
using Aloha.Events;

namespace Aloha.Example
{
    public class DebugDeadEntity : MonoBehaviour
    {
        int deathCount = 0;
        public void Awake()
        {
            GlobalEvent.EntityDied.AddListener(CountDeath);
            GlobalEvent.EntityDied.AddListener(DebugDeath);
        }

        public void CountDeath(Entity entity)
        {
            deathCount++;
            Debug.Log("There is now " + deathCount + " deaths");
        }

        public void DebugDeath(Entity entity)
        {
            Debug.Log(entity.name + " is die");
        }

        public void OnDestroy()
        {
            GlobalEvent.EntityDied.RemoveListener(CountDeath);
            GlobalEvent.EntityDied.RemoveListener(DebugDeath);
        }
    }
}
