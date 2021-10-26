using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using Aloha.Events;

namespace Aloha.Test
{

    public class HorizontalBarTest
    {

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [Test]
        public void HorizonalBarTestSimplePasses()
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

            float expectedBarAfter = (float) healthBar.GetComponent<RectTransform>().sizeDelta.x * ((float) (myHero.currentHealth - damageGiven) / (float) myHero.GetStats().maxHealth);


            myHero.TakeDamage(damageGiven);
            HorizontalBar horizontalBar = updateBar.GetComponent<HorizontalBar>();
            IntIntEvent monEvent = new IntIntEvent();
            // horizontalBar.Init(monEvent);
            horizontalBar.UpdateBar(myHero.currentHealth, myHero.GetStats().maxHealth);

            
            float widthBarAfter = (float) healthBar.GetComponent<RectTransform>().sizeDelta.x;

            Assert.IsTrue(Utils.EqualFloat(expectedBarAfter, widthBarAfter));
            Assert.IsTrue(widthBarAfter < widthBarBefore);

            Object.Destroy(updateBar);
            Object.Destroy(healthBar);
            Object.Destroy(heroObject);

        } // IEnumerator
    } // class
} // namespace
