using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Heros;
using Aloha.EntityStats;

public class HorizontalBar : Bar
{

    override public void UpdateBar(int current, int max)
    {
        
        RectTransform barTransform = bar.GetComponent<RectTransform>();
        barTransform.sizeDelta = new Vector2(barTransform.sizeDelta.x * ((float) current / (float) max), barTransform.sizeDelta.y);
    }

    public void test()
    {
        // C'est juste parce qu'il faut un hero stats
        HeroStats heroStats = ScriptableObject.CreateInstance<HeroStats>();
        heroStats.xp = 100;
        heroStats.maxHealth = 100;

        //declaration du hero
        Hero myHero = hero.GetComponent<Hero>();
        myHero.Init(heroStats);
        myHero.TakeDamage(75);
        UpdateBar(myHero.currentHealth, myHero.stats.maxHealth);
    }
}
