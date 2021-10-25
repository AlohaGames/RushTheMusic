using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using Aloha.Heros;
using Aloha.EntityStats;

namespace Aloha.Test
{

    public class HealthBarTest
    {

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator HealthBarTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.

            // GameObject pour le hero
            GameObject heroObject = new GameObject();

            // Panel enfant qui est la barre de vie et qui a pour parent le panel avec le script UpdateBar.cs
            GameObject healthBar = new GameObject();
            healthBar.AddComponent<Image>();

            // Panel qui a le script UpdateBar.cs
            GameObject updateBar = new GameObject();
            healthBar.transform.SetParent(updateBar.transform);
            updateBar.AddComponent<HorizontalBar>();




            //Creation d'un hero

            // Ici on fait les stats du hero
            HeroStats heroStats = ScriptableObject.CreateInstance<HeroStats>();
            heroStats.xp = 100;
            heroStats.maxHealth = 100;

            //declaration du hero
            Hero myHero = heroObject.AddComponent<Hero>();
            myHero.Init(heroStats);

            int damageGiven = 75;

            float widthBarBefore = (float) healthBar.GetComponent<RectTransform>().sizeDelta.x;

            float expectedBarAfter = (float) healthBar.GetComponent<RectTransform>().sizeDelta.x * ((float) (myHero.currentHealth - damageGiven) / (float) myHero.stats.maxHealth);


            myHero.TakeDamage(damageGiven);
            updateBar.GetComponent<HorizontalBar>().UpdateBar(myHero.currentHealth, myHero.stats.maxHealth);

            
            float widthBarAfter = (float) healthBar.GetComponent<RectTransform>().sizeDelta.x;

            Assert.IsTrue(Utils.EqualFloat(expectedBarAfter, widthBarAfter));
            Assert.IsTrue(widthBarAfter < widthBarBefore);

            yield return null;


        }
    }

}
