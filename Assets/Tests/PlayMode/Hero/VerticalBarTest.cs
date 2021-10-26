using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using Aloha.Events;


namespace Aloha.Test
{
    public class VerticalBarTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void VerticalBarTestSimplePasses()
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

            updateBar.AddComponent<VerticalBar>();




            //Creation d'un hero

            // Ici on fait les stats du hero
            HeroStats heroStats = ScriptableObject.CreateInstance<HeroStats>();
            heroStats.xp = 100;
            heroStats.maxHealth = 100;

            //declaration du hero
            Hero myHero = heroObject.AddComponent<Hero>();
            myHero.Init(heroStats);

            int damageGiven = 75;

            float heightBarExpected = (float)healthBar.GetComponent<RectTransform>().sizeDelta.y;

            float expectedBarAfter = (float)healthBar.GetComponent<RectTransform>().sizeDelta.y * ((float)(myHero.currentHealth - damageGiven) / (float)myHero.stats.maxHealth);


            myHero.TakeDamage(damageGiven);
            VerticalBar verticalBar = updateBar.GetComponent<VerticalBar>();
            IntIntEvent monEvent = new IntIntEvent();
            verticalBar.Init(monEvent);
            verticalBar.UpdateBar(myHero.currentHealth, myHero.stats.maxHealth);


            float heightBarAfter = (float)healthBar.GetComponent<RectTransform>().sizeDelta.y;

            Assert.IsTrue(Utils.EqualFloat(expectedBarAfter, heightBarAfter));
            Assert.IsTrue(heightBarAfter < heightBarExpected);

            Object.Destroy(updateBar);
            Object.Destroy(healthBar);
            Object.Destroy(heroObject);
        }

    }
}
