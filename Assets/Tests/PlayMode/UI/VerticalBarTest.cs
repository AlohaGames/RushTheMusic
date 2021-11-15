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
            updateBar.AddComponent<RectTransform>();




            //Creation d'un hero

            // Ici on fait les stats du hero
            HeroStats heroStats = ScriptableObject.CreateInstance<HeroStats>();
            heroStats.xp = 100;
            heroStats.maxHealth = 100;

            //declaration du hero
            Hero myHero = heroObject.AddComponent<Hero>();
            myHero.Init(heroStats);

            int damageGiven = 25;

            float heightBarBefore = (float)healthBar.GetComponent<RectTransform>().sizeDelta.x;



            VerticalBar verticalBar = updateBar.GetComponent<VerticalBar>();
            //RectTransform updateBarRect = updateBar.GetComponent<RectTransform>();


            // On répète le processus quatres fois avec 25 dégats de données

            float expectedBarAfter = (float)updateBar.GetComponent<RectTransform>().rect.height * ((float)(myHero.currentHealth - damageGiven) / (float)myHero.GetStats().maxHealth);
            myHero.TakeDamage(damageGiven);
            Assert.IsTrue(myHero.currentHealth == 75);
            verticalBar.UpdateBar(myHero.currentHealth, myHero.GetStats().maxHealth);
            float heightBarAfter = (float)healthBar.GetComponent<RectTransform>().sizeDelta.y;
            Assert.IsTrue(Utils.EqualFloat(expectedBarAfter, heightBarAfter));
            Assert.IsTrue(heightBarAfter < heightBarBefore);
            Assert.IsTrue(Utils.EqualFloat(heightBarAfter, (float)updateBar.GetComponent<RectTransform>().rect.height * 0, 75));

            expectedBarAfter = (float)updateBar.GetComponent<RectTransform>().rect.height * ((float)(myHero.currentHealth - damageGiven) / (float)myHero.GetStats().maxHealth);
            myHero.TakeDamage(damageGiven);
            Assert.IsTrue(myHero.currentHealth == 50);
            verticalBar.UpdateBar(myHero.currentHealth, myHero.GetStats().maxHealth);
            heightBarAfter = (float)healthBar.GetComponent<RectTransform>().sizeDelta.y;
            Assert.IsTrue(Utils.EqualFloat(expectedBarAfter, heightBarAfter));
            Assert.IsTrue(heightBarAfter < heightBarBefore);
            Assert.IsTrue(Utils.EqualFloat(heightBarAfter, (float)updateBar.GetComponent<RectTransform>().rect.height * 0, 50));

            expectedBarAfter = (float)updateBar.GetComponent<RectTransform>().rect.height * ((float)(myHero.currentHealth - damageGiven) / (float)myHero.GetStats().maxHealth);
            myHero.TakeDamage(damageGiven);
            Assert.IsTrue(myHero.currentHealth == 25);
            verticalBar.UpdateBar(myHero.currentHealth, myHero.GetStats().maxHealth);
            heightBarAfter = (float)healthBar.GetComponent<RectTransform>().sizeDelta.y;
            Assert.IsTrue(Utils.EqualFloat(expectedBarAfter, heightBarAfter));
            Assert.IsTrue(heightBarAfter < heightBarBefore);
            Assert.IsTrue(Utils.EqualFloat(heightBarAfter, (float)updateBar.GetComponent<RectTransform>().rect.height * 0, 25));

            expectedBarAfter = (float)updateBar.GetComponent<RectTransform>().rect.height * ((float)(myHero.currentHealth - damageGiven) / (float)myHero.GetStats().maxHealth);
            myHero.TakeDamage(damageGiven);
            Assert.IsTrue(myHero.currentHealth == 0);
            verticalBar.UpdateBar(myHero.currentHealth, myHero.GetStats().maxHealth);
            heightBarAfter = (float)healthBar.GetComponent<RectTransform>().sizeDelta.y;
            Assert.IsTrue(Utils.EqualFloat(expectedBarAfter, heightBarAfter));
            Assert.IsTrue(heightBarAfter < heightBarBefore);
            Assert.IsTrue(Utils.EqualFloat(heightBarAfter, (float)updateBar.GetComponent<RectTransform>().rect.height * 0, 00));

            // On verifie que la taille voulu et obtenu sont bien à 0 puisque la vie est à 0
            Assert.IsTrue(expectedBarAfter == 0);
            Assert.IsTrue(heightBarAfter == 0);

            Object.Destroy(updateBar);
            Object.Destroy(healthBar);
            Object.Destroy(heroObject);
        }

    }
}
