using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Aloha.EntityStats;

namespace Aloha
{
    public class Enemy<T> : Entity<T> where T : EnemyStats
    {
        public void Awake()
        {
            this.dieEvent.AddListener(() => { Disappear();});
        }
        public void Init(T stats)
        {
            base.Init(stats);
        }

        public override void Init()
        {
            this.Init(stats);
        }

        public void Disappear()
        {
            Destroy(this.gameObject);
        }
    }
    public class Enemy : Enemy<EnemyStats> { }
}
