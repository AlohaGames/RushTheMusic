using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aloha.Events;
using Aloha.Hero;
using Aloha.EntityStats;

public class HealthBarHero : MonoBehaviour
{
    GameObject barObject;
    GameObject objectHero;

    public void Awake()
    {
        GlobalEvent.HeroHealth.AddListener(updateHealthBar);
    }

    public void updateHealthBar(Hero<HeroStats> hero)
    {
        Debug.Log("current: " + hero.currentHealth);
        Debug.Log("max: " + hero.stats.maxHealth);
        barObject = transform.GetChild(0).gameObject;
        RectTransform bar = barObject.GetComponent<RectTransform>();
        Debug.Log("current: " + hero.currentHealth);
        Debug.Log("max: " + hero.stats.maxHealth);
        Debug.Log(bar.sizeDelta.x);
        Debug.Log(hero.currentHealth / hero.stats.maxHealth);
        Debug.Log(bar.sizeDelta.x * (hero.currentHealth / hero.stats.maxHealth));
        bar.sizeDelta = new Vector2(bar.sizeDelta.x * ((float) hero.currentHealth / (float) hero.stats.maxHealth), bar.sizeDelta.y);
    }

    public void test()
    {
        // C'est juste parce qu'il faut un hero stats
        HeroStats heroStats = ScriptableObject.CreateInstance<HeroStats>();
        heroStats.xp = 100;
        heroStats.maxHealth = 100;

        //declaration du hero
        Hero myHero = gameObject.AddComponent<Hero>();
        myHero.Init(heroStats);
        myHero.TakeDamage(75);
        updateHealthBar(myHero);
    }


    public void OnDestroy()
    {
        GlobalEvent.HeroHealth.RemoveListener(updateHealthBar);
    }
}
