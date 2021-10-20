using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Aloha
{
    public class Enemy<T> : Entity<T> where T : EnemyStats
    {
        public void Awake()
        {
            this.dieEvent.AddListener(Disappear);
        }

        public void Disappear()
        {
            Destroy(this.gameObject);
        }

        public void OnDestroy()
        {
            this.dieEvent.RemoveListener(Disappear);
        }
    }
    public class Enemy : Enemy<EnemyStats> { }
}
