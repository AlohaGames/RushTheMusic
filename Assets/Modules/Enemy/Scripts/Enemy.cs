using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Aloha.EntityStats;

namespace Aloha
{
    public class Enemy<T> : Entity<T> where T : EnemyStats
    {
        protected bool AIActivated = false;

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
    public class Enemy : Enemy<EnemyStats> { }
}
