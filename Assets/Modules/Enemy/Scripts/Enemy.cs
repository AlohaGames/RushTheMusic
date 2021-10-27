using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Aloha
{
    public class Enemy<T> : Enemy where T : EnemyStats
    {
        private T enemyStats
        {
            get
            {
                return this.stats as T;
            }
        }

        public override EnemyStats GetStats()
        {
            return this.enemyStats;
        }
    }
    public class Enemy : Entity
    {
        protected bool AIActivated = false;

        private EnemyStats enemyStats {
            get {
                return this.stats as EnemyStats;
            }
        }
        public virtual EnemyStats GetStats() {
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

        public void DetachFromParent()
        {
            transform.parent = null;
        }

        public void SetAI(bool value)
        {
            AIActivated = value;
            if (AIActivated) StartCoroutine(AI());
        }

        protected virtual IEnumerator AI()
        {
            while(this.AIActivated)
            {
                yield return StartCoroutine(MoveXToAnimation(Utils.RandomFloat(-1.5f, 1.5f), 1));
            }
        }

        protected virtual IEnumerator MoveXToAnimation(float x, float speed)
        {
            float temps = 0;
            Vector3 posInit = gameObject.transform.position;
            Vector3 posFinal = posInit;
            posFinal.x = x;

            while (temps < 1f)
            {
                temps += speed * Time.deltaTime;
                gameObject.transform.position = Vector3.Lerp(posInit, posFinal, temps);
                yield return null;
            }

            gameObject.transform.position = posFinal;
        }
    }
}
