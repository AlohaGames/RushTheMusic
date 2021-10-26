using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aloha.Example
{

    public class TestBar : MonoBehaviour
    {

        public Bar H_Bar;
        public Bar V_Bar;
        public Hero hero;

        public void BarUsageExample()
        {
            // C'est juste parce qu'il faut un hero stats
            HeroStats heroStats = ScriptableObject.CreateInstance<HeroStats>();
            heroStats.xp = 100;
            heroStats.maxHealth = 100;

            //declaration du hero
            Hero myHero = hero.GetComponent<Hero>();
            myHero.Init(heroStats);
            myHero.TakeDamage(75);
            // H_Bar.updateEvent.Invoke(myHero.currentHealth, myHero.GetStats().maxHealth);
            // V_Bar.updateEvent.Invoke(myHero.currentHealth, myHero.GetStats().maxHealth);
        }
    }
}
