using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Aloha
{
    public class HealthPotion : Item
    {
        
        
        public int gain = 20;


        public override void effect()
        {
            Hero hero = GameManager.Instance.GetHero();
            hero.currentHealth += this.gain;
            if(hero.currentHealth > hero.GetStats().maxHealth)
            {
                hero.currentHealth = hero.GetStats().maxHealth;
            }

        } 
    }
}

