using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Aloha
{
    public class Enemy : Entity
    {
        protected EnemyStats enemyStats {
            get {
                return this.stats as EnemyStats;
            }
        }
        public new EnemyStats GetStats() {
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
