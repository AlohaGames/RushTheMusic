using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Aloha.EntityStats;
using Aloha.Heros;

namespace Aloha
{
    public class Assassin : Enemy<AssassinStats> 
    {
        private Hero hero;

        private void Start()
        {
            // TODO Change this by the hero in HeroManager
            hero = (Hero) FindObjectOfType<Warrior>();
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
    }
}
