using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Aloha
{
    public class Enemy : Entity
    {
        private EnemyStats enemyStats {
            get {
                return this.stats as EnemyStats;
            }
        }
        public EnemyStats GetStats() {
            return this.enemyStats;
        }
        public void Awake()
        {
            this.dieEvent.AddListener(Disappear);
        }

        public void Disappear()
        {
            Destroy(this.gameObject);
        }

        public void OnDestroy() {
            this.dieEvent.RemoveListener(Disappear);
        }
    }
}
