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
    public class VerticalBarTest
    {
        /// <summary>
/// TODO
/// </summary>
        [Test]
        public void VerticalBarTestSimplePasses()
        {
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

            // Ici on fait les stats du hero
            HeroStats heroStats = ScriptableObject.CreateInstance<HeroStats>();
            heroStats.XP = 100;
            heroStats.MaxHealth = 100;

            //declaration du hero
            Hero myHero = heroObject.AddComponent<Hero>();
            myHero.Init(heroStats);

            int damageGiven = 25;

            float heightBarBefore = (float)healthBar.GetComponent<RectTransform>().sizeDelta.x;

            VerticalBar verticalBar = updateBar.GetComponent<VerticalBar>();
            //RectTransform updateBarRect = updateBar.GetComponent<RectTransform>();

            //TODO: peut-être faire une boucle for ici

            float expectedBarAfter = (float)updateBar.GetComponent<RectTransform>().rect.height * ((float)(myHero.CurrentHealth - damageGiven) / (float)myHero.GetStats().MaxHealth);
            myHero.TakeDamage(damageGiven);
            Assert.IsTrue(myHero.CurrentHealth == 75);
            verticalBar.UpdateBar(myHero.CurrentHealth, myHero.GetStats().MaxHealth);
            float heightBarAfter = (float)healthBar.GetComponent<RectTransform>().sizeDelta.y;
            Assert.IsTrue(Utils.IsEqualFloat(expectedBarAfter, heightBarAfter));
            Assert.IsTrue(heightBarAfter < heightBarBefore);
            Assert.IsTrue(Utils.IsEqualFloat(heightBarAfter, (float)updateBar.GetComponent<RectTransform>().rect.height * 0, 75));

            expectedBarAfter = (float)updateBar.GetComponent<RectTransform>().rect.height * ((float)(myHero.CurrentHealth - damageGiven) / (float)myHero.GetStats().MaxHealth);
            myHero.TakeDamage(damageGiven);
            Assert.IsTrue(myHero.CurrentHealth == 50);
            verticalBar.UpdateBar(myHero.CurrentHealth, myHero.GetStats().MaxHealth);
            heightBarAfter = (float)healthBar.GetComponent<RectTransform>().sizeDelta.y;
            Assert.IsTrue(Utils.IsEqualFloat(expectedBarAfter, heightBarAfter));
            Assert.IsTrue(heightBarAfter < heightBarBefore);
            Assert.IsTrue(Utils.IsEqualFloat(heightBarAfter, (float)updateBar.GetComponent<RectTransform>().rect.height * 0, 50));

            expectedBarAfter = (float)updateBar.GetComponent<RectTransform>().rect.height * ((float)(myHero.CurrentHealth - damageGiven) / (float)myHero.GetStats().MaxHealth);
            myHero.TakeDamage(damageGiven);
            Assert.IsTrue(myHero.CurrentHealth == 25);
            verticalBar.UpdateBar(myHero.CurrentHealth, myHero.GetStats().MaxHealth);
            heightBarAfter = (float)healthBar.GetComponent<RectTransform>().sizeDelta.y;
            Assert.IsTrue(Utils.IsEqualFloat(expectedBarAfter, heightBarAfter));
            Assert.IsTrue(heightBarAfter < heightBarBefore);
            Assert.IsTrue(Utils.IsEqualFloat(heightBarAfter, (float)updateBar.GetComponent<RectTransform>().rect.height * 0, 25));

            expectedBarAfter = (float)updateBar.GetComponent<RectTransform>().rect.height * ((float)(myHero.CurrentHealth - damageGiven) / (float)myHero.GetStats().MaxHealth);
            myHero.TakeDamage(damageGiven);
            Assert.IsTrue(myHero.CurrentHealth == 0);
            verticalBar.UpdateBar(myHero.CurrentHealth, myHero.GetStats().MaxHealth);
            heightBarAfter = (float)healthBar.GetComponent<RectTransform>().sizeDelta.y;
            Assert.IsTrue(Utils.IsEqualFloat(expectedBarAfter, heightBarAfter));
            Assert.IsTrue(heightBarAfter < heightBarBefore);
            Assert.IsTrue(Utils.IsEqualFloat(heightBarAfter, (float)updateBar.GetComponent<RectTransform>().rect.height * 0, 00));

            Assert.IsTrue(expectedBarAfter == 0);
            Assert.IsTrue(heightBarAfter == 0);

            Object.Destroy(updateBar);
            Object.Destroy(healthBar);
            Object.Destroy(heroObject);
        }
    }
}
