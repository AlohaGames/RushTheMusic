using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using Aloha.Events;

//TODO: explain your FUNCKING TEST (like youyou in Tests/PlayMode/Enemy/ActionZoneTest)

namespace Aloha.Test
{
    /// <summary>
    /// TODO
    /// </summary>
    public class HorizontalBarTest
    {

        /// <summary>
        /// TODO
        /// </summary>
        [Test]
        public void HorizonalBarTestSimplePasses()
        {
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

            // Ici on fait les stats du hero
            HeroStats heroStats = ScriptableObject.CreateInstance<HeroStats>();
            heroStats.XP = 100;
            heroStats.MaxHealth = 100;

            //declaration du hero
            Hero myHero = heroObject.AddComponent<Hero>();
            myHero.Init(heroStats);

            int damageGiven = 25;

            float widthBarBefore = (float)healthBar.GetComponent<RectTransform>().sizeDelta.x;

            HorizontalBar horizontalBar = updateBar.GetComponent<HorizontalBar>();

            //TODO: peut-être faire un for

            // On répète le processus quatres fois avec 25 dégats de données

            float expectedBarAfter = (float)updateBar.GetComponent<RectTransform>().rect.width * ((float)(myHero.CurrentHealth - damageGiven) / (float)myHero.GetStats().MaxHealth);
            myHero.TakeDamage(damageGiven);
            Assert.IsTrue(myHero.CurrentHealth == 75);
            horizontalBar.UpdateBar(myHero.CurrentHealth, myHero.GetStats().MaxHealth);
            float widthBarAfter = (float)healthBar.GetComponent<RectTransform>().sizeDelta.x;
            Assert.IsTrue(Utils.IsEqualFloat(expectedBarAfter, widthBarAfter));
            Assert.IsTrue(widthBarAfter < widthBarBefore);
            Assert.IsTrue(Utils.IsEqualFloat(widthBarAfter, (float)updateBar.GetComponent<RectTransform>().rect.width * 0, 75));

            expectedBarAfter = (float)updateBar.GetComponent<RectTransform>().rect.width * ((float)(myHero.CurrentHealth - damageGiven) / (float)myHero.GetStats().MaxHealth);
            myHero.TakeDamage(damageGiven);
            Assert.IsTrue(myHero.CurrentHealth == 50);
            horizontalBar.UpdateBar(myHero.CurrentHealth, myHero.GetStats().MaxHealth);
            widthBarAfter = (float)healthBar.GetComponent<RectTransform>().sizeDelta.x;
            Assert.IsTrue(Utils.IsEqualFloat(expectedBarAfter, widthBarAfter));
            Assert.IsTrue(widthBarAfter < widthBarBefore);
            Assert.IsTrue(Utils.IsEqualFloat(widthBarAfter, (float)updateBar.GetComponent<RectTransform>().rect.width * 0, 50));

            expectedBarAfter = (float)updateBar.GetComponent<RectTransform>().rect.width * ((float)(myHero.CurrentHealth - damageGiven) / (float)myHero.GetStats().MaxHealth);
            myHero.TakeDamage(damageGiven);
            Assert.IsTrue(myHero.CurrentHealth == 25);
            horizontalBar.UpdateBar(myHero.CurrentHealth, myHero.GetStats().MaxHealth);
            widthBarAfter = (float)healthBar.GetComponent<RectTransform>().sizeDelta.x;
            Assert.IsTrue(Utils.IsEqualFloat(expectedBarAfter, widthBarAfter));
            Assert.IsTrue(widthBarAfter < widthBarBefore);
            Assert.IsTrue(Utils.IsEqualFloat(widthBarAfter, (float)updateBar.GetComponent<RectTransform>().rect.width * 0, 25));

            expectedBarAfter = (float)updateBar.GetComponent<RectTransform>().rect.width * ((float)(myHero.CurrentHealth - damageGiven) / (float)myHero.GetStats().MaxHealth);
            myHero.TakeDamage(damageGiven);
            Assert.IsTrue(myHero.CurrentHealth == 0);
            horizontalBar.UpdateBar(myHero.CurrentHealth, myHero.GetStats().MaxHealth);
            widthBarAfter = (float)healthBar.GetComponent<RectTransform>().sizeDelta.x;
            Assert.IsTrue(Utils.IsEqualFloat(expectedBarAfter, widthBarAfter));
            Assert.IsTrue(widthBarAfter < widthBarBefore);
            Assert.IsTrue(Utils.IsEqualFloat(widthBarAfter, (float)updateBar.GetComponent<RectTransform>().rect.width * 0, 00));

            Assert.IsTrue(expectedBarAfter == 0);
            Assert.IsTrue(widthBarAfter == 0);

            Object.DestroyImmediate(updateBar);
            Object.DestroyImmediate(healthBar);
            Object.DestroyImmediate(heroObject);

            Aloha.Utils.ClearCurrentScene(true);

        }
    } // class
} // namespace
