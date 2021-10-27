using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Aloha.EntityStats;

namespace Aloha
{
    public class Assassin : Enemy<AssassinStats> 
    {
        private Hero hero;

        private void Start()
        {
            hero = GameManager.Instance.GetHero();
        }

        private void Update()
        {
            if(transform.position.z < -1)
            {
                this.Attack(hero);
                this.Disappear();
                Debug.Log(hero.currentHealth);
            }
        }
        protected override IEnumerator AI()
        {
            return base.AI();
        }
    }
}
