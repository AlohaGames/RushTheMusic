using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using Aloha.Events;

//TODO: explain your FUNCKING TEST (like youyou in 17-Add-Lancer-Prefab tests of lancer)

namespace Aloha.Test
{
    /// <summary>
    /// TODO
    /// </summary>
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

            float widthBarBefore = (float)healthBar.GetComponent<RectTransform>().sizeDelta.x;



            HorizontalBar horizontalBar = updateBar.GetComponent<HorizontalBar>();
            //RectTransform updateBarRect = updateBar.GetComponent<RectTransform>();


            // On répète le processus quatres fois avec 25 dégats de données

            float expectedBarAfter = (float)updateBar.GetComponent<RectTransform>().rect.width * ((float)(myHero.currentHealth - damageGiven) / (float)myHero.GetStats().maxHealth);
            myHero.TakeDamage(damageGiven);
            Assert.IsTrue(myHero.currentHealth == 75);
            horizontalBar.UpdateBar(myHero.currentHealth, myHero.GetStats().maxHealth);
            float widthBarAfter = (float)healthBar.GetComponent<RectTransform>().sizeDelta.x;
            Assert.IsTrue(Utils.EqualFloat(expectedBarAfter, widthBarAfter));
            Assert.IsTrue(widthBarAfter < widthBarBefore);
            Assert.IsTrue(Utils.EqualFloat(widthBarAfter, (float)updateBar.GetComponent<RectTransform>().rect.width * 0,75));

            expectedBarAfter = (float)updateBar.GetComponent<RectTransform>().rect.width * ((float)(myHero.currentHealth - damageGiven) / (float)myHero.GetStats().maxHealth);
            myHero.TakeDamage(damageGiven);
            Assert.IsTrue(myHero.currentHealth == 50);
            horizontalBar.UpdateBar(myHero.currentHealth, myHero.GetStats().maxHealth);
            widthBarAfter = (float)healthBar.GetComponent<RectTransform>().sizeDelta.x;
            Assert.IsTrue(Utils.EqualFloat(expectedBarAfter, widthBarAfter));
            Assert.IsTrue(widthBarAfter < widthBarBefore);
            Assert.IsTrue(Utils.EqualFloat(widthBarAfter, (float)updateBar.GetComponent<RectTransform>().rect.width * 0,50));

            expectedBarAfter = (float)updateBar.GetComponent<RectTransform>().rect.width * ((float)(myHero.currentHealth - damageGiven) / (float)myHero.GetStats().maxHealth);
            myHero.TakeDamage(damageGiven);
            Assert.IsTrue(myHero.currentHealth == 25);
            horizontalBar.UpdateBar(myHero.currentHealth, myHero.GetStats().maxHealth);
            widthBarAfter = (float)healthBar.GetComponent<RectTransform>().sizeDelta.x;
            Assert.IsTrue(Utils.EqualFloat(expectedBarAfter, widthBarAfter));
            Assert.IsTrue(widthBarAfter < widthBarBefore);
            Assert.IsTrue(Utils.EqualFloat(widthBarAfter, (float)updateBar.GetComponent<RectTransform>().rect.width * 0,25));

            expectedBarAfter = (float)updateBar.GetComponent<RectTransform>().rect.width * ((float)(myHero.currentHealth - damageGiven) / (float)myHero.GetStats().maxHealth);
            myHero.TakeDamage(damageGiven);
            Assert.IsTrue(myHero.currentHealth == 0);
            horizontalBar.UpdateBar(myHero.currentHealth, myHero.GetStats().maxHealth);
            widthBarAfter = (float)healthBar.GetComponent<RectTransform>().sizeDelta.x;
            Assert.IsTrue(Utils.EqualFloat(expectedBarAfter, widthBarAfter));
            Assert.IsTrue(widthBarAfter < widthBarBefore);
            Assert.IsTrue(Utils.EqualFloat(widthBarAfter, (float)updateBar.GetComponent<RectTransform>().rect.width * 0,00));

            // On verifie que la taille voulu et obtenu sont bien à 0 puisque la vie est à 0
            Assert.IsTrue(expectedBarAfter == 0);
            Assert.IsTrue(widthBarAfter == 0);

            Object.Destroy(updateBar);
            Object.Destroy(healthBar);
            Object.Destroy(heroObject);

        } // IEnumerator
    } // class
} // namespace
